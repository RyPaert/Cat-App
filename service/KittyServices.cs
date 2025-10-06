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
            var result = await _catContext.Kittys
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }
        public async Task<Kitty> Create(KittyDto dto)
        {
            Kitty cat = new();
            cat.ID = Guid.NewGuid();
            cat.AdminCatGender = dto.AdminCatGender;
            cat.AdminCatDescription = dto.AdminCatDescription;
            cat.AdminCatName = dto.AdminCatName;
            cat.AdminCatAge = dto.AdminCatAge;


        }

       
    }
}
