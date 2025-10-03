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
            var result = await _catContext.AdminCats
                .FirstOrDefaultAsync(x => x.AdminCatId == id);
            return result;
        }

        Task<Kitty> IKittysServices.Create(KittyDto dto)
        {
            throw new NotImplementedException();
        }

        Task<Kitty> IKittysServices.DetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
