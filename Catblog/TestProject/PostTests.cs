using Catblog.Dto;
using Catblog.ServiceInterface;

namespace TestProject
{
    public class PostTests : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyPost_WhenPost()
        {
            PostDto testDto = MockDataPost1();

            var result = await Svc<IPostServices>().AddNewPost(testDto);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task Should_DeleteByIdPost_WhenDeletePost()
        {
            PostDto dto = MockDataPost1();

            var addPost = await Svc<IPostServices>().AddNewPost(dto);
            var deletePost = await Svc<IPostServices>().Delete(addPost.Id);

            Assert.Equal(addPost.Id, deletePost.Id);
        }
        [Fact]
        public async Task ShouldNot_DeleteByIdPost_DifferentPost()
        {
            PostDto dto = MockDataPost1();

            var re1 = await Svc<IPostServices>().AddNewPost(dto);
            var re2 = await Svc<IPostServices>().AddNewPost(dto);

            var result = await Svc<IPostServices>().Delete((Guid)re2.Id);

            Assert.NotEqual(re1.Id, result.Id);
        }
        [Fact]
        public async Task ShouldNot_CreatePost_WhenAgeNegative()
        {
            PostDto dto = new PostDto
            {
                Age = -10,
                Name = "Test",
                Description = "Test",
                Gender = "test",
                Species = "test",
                Title = "Test",
            };

            var result = await Svc<IPostServices>().AddNewPost(dto);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldHaveUniqueID_WhenPostCreated()
        {
            PostDto dto1 = MockDataPost1();
            PostDto dto2 = MockDataPost1();

            var create1 = await Svc<IPostServices>().AddNewPost(dto1);
            var create2 = await Svc<IPostServices>().AddNewPost(dto2);

            Assert.NotEqual(create1.Id, create2.Id);
        }
        [Fact]
        public async Task Should_GetDetailsData()
        {
            PostDto dto = MockDataPost1();

            var post = await Svc<IPostServices>().AddNewPost(dto);
            var result = await Svc<IPostServices>().PostDetailsAsync(post.Id);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetWrongDetailsData()
        {
            PostDto dto1 = MockDataPost1();
            PostDto dto2 = MockDataPost2();

            var create1 = await Svc<IPostServices>().AddNewPost(dto1);
            var create2 = await Svc<IPostServices>().AddNewPost(dto2);

            var result1 = await Svc<IPostServices>().PostDetailsAsync(create1.Id);
            var result2 = await Svc<IPostServices>().PostDetailsAsync(create2.Id);

            Assert.NotEqual(result1.Name, result2.Name);
        }
        private static PostDto MockDataPost1()
        {
                return new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rex",
                    Species = "kass",
                    Age = 1,
                    Gender = "mees",
                    Title = "minu kass",
                    Description = "ta on kass",
                };
        }
        private static PostDto MockDataPost2()
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = "Max",
                Species = "koer",
                Age = 10,
                Gender = "naine",
                Title = "minu koer",
                Description = "ta on koer",
            };
        }
    }
}