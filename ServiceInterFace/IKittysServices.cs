using Catblog.Domain;
using Catblog.Dto;

namespace Catblog.ServiceInterFace
{
    public interface IKittysServices
    {
        Task<Kitty> DetailsAsync(Guid id);
        Task<Kitty> Create(KittyDto dto);

    }
}
