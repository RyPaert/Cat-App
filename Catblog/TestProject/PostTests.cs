using Catblog.Dto;
using Catblog.ServiceInterface;

namespace TestProject
{
    public class PostTests : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyPost_WhenPost()
        {
            //ülesseade
            PostDto testDto = MockDataPost();

            //läbiviimine
            var result = await Svc<IPostServices>().AddNewPost(testDto);

            //kontrollime
            Assert.NotNull(result);
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