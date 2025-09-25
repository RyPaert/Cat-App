using System.Diagnostics.Metrics;
using Catblog.Domain;
using Catblog.Dto;

namespace Catblog.ServiceInterface
{
    public interface ICatServices
    {
        Task<Cat> AddNewPost(CatDto dto);
        Task<Cat> PostDetailsAsync(Guid id);
        Task<Cat> Delete(Guid id);
    }
}
