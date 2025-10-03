using Catblog.Domain;
using Catblog.Dto;


namespace Catblog.ServiceInterFace
{
    public interface IFileServices
    {
        void UploadFilesToDatabase(KittyDto dto, Kitty kitty);
        Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabase dto);
    }
}
