using Catblog.Dto;
using Catblog.ServiceInterface;

namespace TestProject
{
    public class PostTests : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyPost_WhenPost()
        {
            PostDto testDto = MockDataPost();

            var result = await Svc<IPostServices>().AddNewPost(testDto);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Should_DeleteByIdPost_WhenDeletePost()
        {
            PostDto dto = MockDataPost();

            var addPost = await Svc<IPostServices>().AddNewPost(dto);
            addPost.Id = Guid.NewGuid();
            var deletePost = await Svc<IPostServices>().Delete((Guid)addPost.Id);

            Assert.Equal(addPost.Id, deletePost.Id);
        }
        [Fact]
        public async Task ShouldNot_DeleteByIdPost_DifferentPost()
        {
            PostDto dto = MockDataPost();

            var re1 = await Svc<IPostServices>().AddNewPost(dto);
            var re2 = await Svc<IPostServices>().AddNewPost(dto);

            var result = await Svc<IPostServices>().Delete((Guid)re2.Id);

            Assert.NotEqual(re1.Id, result.Id);
        }

        private static PostDto MockDataPost()
        {
                return new()
                {
                    Name = "test",
                    Species = "wjejiou",
                    Age = 1,
                    Gender = "ew",
                    Title = "test",
                    Description = "test",
                };
        }
    }
}