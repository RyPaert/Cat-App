using System.Diagnostics.Metrics;
using Catblog.Domain;
using Catblog.Dto;

namespace Catblog.ServiceInterface
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(PostDto dto, Post domain);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto);
    }
}
