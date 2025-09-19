using System.Diagnostics.Metrics;
using Catblog.Domain;
using Catblog.Dto;

namespace Catblog.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(CatDto dto, Cat domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
