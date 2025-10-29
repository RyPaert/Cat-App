using Catblog.Domain;
using Catblog.Models.Comments;
using Catblog.Dto;

namespace Catblog.ServiceInterface
{
    public interface IPostServices
    {
        Task<Post> AddNewPost(PostDto dto);
        Task<Post> PostDetailsAsync(Guid id);
        Task<Post> Delete(Guid id);
        Task<IEnumerable<Comment>> GetComment();
        Task AddComment(Comment comment);
    }
}
