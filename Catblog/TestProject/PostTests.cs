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
        [Fact]
        public async Task ShouldNot_CreatePost_WhenAgeNegative()
        {
            //ülesseade
            PostDto dto = new PostDto
            {
                Age = -10,
                Name = "Test",
                Description = "bla bla cat",
                Gender = "male",
                Species = "krants",
                Title = "Test", 
            };

            //tegevus
            var result = await Svc<IPostServices>().AddNewPost(dto);

            //kontrollimine
            Assert.NotNull(result);
           
        }
        [Fact]
        public async Task ShouldHaveUniqueID_WhenPostCreated()
        {
            //ülesseadistus
            PostDto dto1 = MockDataPost();
            PostDto dto2 = MockDataPost();

            //tegevus
            var create1 = await Svc<IPostServices>().AddNewPost(dto1);
            var create2 = await Svc<IPostServices>().AddNewPost(dto2);

            //kontrollimine
            Assert.NotEqual(create1.Id, create2.Id);
        }

        private static PostDto MockDataPost()
        {
                return new()
                {
                    Id = Guid.NewGuid(),
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