using System.Diagnostics.Metrics;
using Catblog.Data;
using Catblog.Domain;
using Catblog.Dto;
using Catblog.ServiceInterface;

namespace Catblog.Services
{
    public class CatServices : ICatServices
    {
        private readonly CatblogDb _context;
        private readonly IFileServices _fileServices;

        public CatServices(CatblogDb context, IFileServices fileServices) 
        { 
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Cat> AddNewPost(CatDto dto)
        {
            Cat cat = new Cat();
            cat.Id = Guid.NewGuid();
            cat.Name = dto.Name;
            cat.Description = dto.Description;
            cat.Title = dto.Title;
            cat.Species = dto.Species;
            cat.Age = dto.Age;
            cat.Gender = dto.Gender;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, cat);
            }

            await _context.Cats.AddAsync(cat);
            await _context.SaveChangesAsync();

            return cat;
        }
    }
}
