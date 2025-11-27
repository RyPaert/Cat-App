using System.Diagnostics.Metrics;
using Catblog.Data;
using Catblog.Domain;
using Catblog.Dto;
using Catblog.ServiceInterface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly CatblogDb _context;
        public FileServices(CatblogDb context, IHostEnvironment webHost)
        { 
            _context = context; 
            _webHost = webHost;
        }
        public void UploadFilesToDatabase(PostDto dto, Post domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            ID = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            PostId = domain.Id
                        };

                        image.CopyTo(target);
                        files.ImageData = target.ToArray();
                        _context.FileToDatabase.Add(files);

                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var imageID = await _context.FileToDatabase
                .FirstOrDefaultAsync(x => x.ID == dto.ID);
            var filePath = _webHost.ContentRootPath + "\\multipleFileUpload\\" + imageID.ImageData;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToDatabase.Remove(imageID);
            await _context.SaveChangesAsync();

            return null;

        }
    }
}
