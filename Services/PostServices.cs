using Catblog.Data;
using Catblog.Domain;
using Catblog.Dto;
using Catblog.Models.Comment;
using Catblog.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace Catblog.Services
{
    public class PostServices :IPostServices
    {
        private readonly CatblogDb _context;
        private readonly IFileServices _fileServices;

        public PostServices(CatblogDb context, IFileServices fileServices)
        {
            _context = context;
            _fileServices = fileServices;
        }
        public async Task<Post> PostDetailsAsync(Guid id)
        {
            var result = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Post> AddNewPost(PostDto dto)
        {
            Post post = new Post();
            post.Id = Guid.NewGuid();
            post.Name = dto.Name;
            post.Description = dto.Description;
            post.Title = dto.Title;
            post.Species = dto.Species;
            post.Age = dto.Age;
            post.Gender = dto.Gender;
            post.User = dto.User;

            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, post);
            }

            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }
        public async Task<Post> Delete(Guid id)
        {
            var result = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Posts.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<Comment>> GetComment()
        {
            var comment = await _context.Comments.ToListAsync();
            return comment;
        }

        public async Task AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
