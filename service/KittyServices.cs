using Catblog.Data;
using Catblog.Domain;
using Catblog.Dto;
using Catblog.ServiceInterFace;
using Microsoft.EntityFrameworkCore;

namespace Catblog.service
{
    public class KittyServices : IKittysServices
    {
        private readonly AdminCatContext _catContext;
        private readonly IFileServices _fileServices;

        public KittyServices(AdminCatContext catContext, IFileServices fileServices)
        {
            _catContext = catContext;
            _fileServices = fileServices;
        }
        public async Task<Kitty> DetailsAsync(Guid id)
        {
            var result = await _catContext.Kitties
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Kitty> Create(KittyDto dto)
        {
            Kitty kitty = new();

            kitty.Id = Guid.NewGuid();
            kitty.AdminCatGender = dto.AdminCatGender;
            kitty.AdminCatDescription = dto.AdminCatDescription;
            kitty.AdminCatName = dto.AdminCatName;
            kitty.AdminCatAge = dto.AdminCatAge;
            kitty.AdminCatSpecies = dto.AdminCatSpecies;
            kitty.AdminCatTitle = dto.AdminCatTitle;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, kitty);
            }
            await _catContext.Kitties.AddAsync(kitty);
            await _catContext.SaveChangesAsync();

            return kitty;
        }
        public async Task<Kitty> Delete(Guid id)
        {
            var result = await _catContext.Kitties
                .FirstOrDefaultAsync(x => x.Id == id);
            _catContext.Kitties.Remove(result);
            await _catContext.SaveChangesAsync();

            return result;
        }
    }
}
