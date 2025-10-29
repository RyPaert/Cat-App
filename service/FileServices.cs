using Catblog.Data;
using Catblog.Domain;
using Catblog.Dto;
using Catblog.ServiceInterFace;
using Microsoft.EntityFrameworkCore;

namespace Catblog.service
{
    public class FileServices : IFileServices
    {
        private readonly AdminCatContext _context;
        private readonly IHostEnvironment _environment;
        

        public FileServices
            (
                AdminCatContext context,
                IHostEnvironment hostEnvironment
            )
        {
            _context = context;
            _environment = hostEnvironment;
        }
        public void UploadFilesToDatabase(KittyDto dto, Kitty kitty)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            AdminCatID = kitty.Id

                        };
                        image.CopyTo( target );
                        files.ImageData = target.ToArray();
                        _context.FileToDatabase.Add( files );
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabase dto)
        {
            var imageID = await _context.FileToDatabase
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            var filePath = _environment.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FileToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;
        }


    }
}
