using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catblog.Controllers;
using Catblog.Dto;
using Catblog.Models.Post;
using Catblog.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    public class ControllerTest : TestBase
    {
        //CONTROLLER
        [Fact]
        public async Task ShouldNot_AddEmptyPost_WhenPost()
        {
            Post test = MockDataPost();

            var result = await Svc<PostController>().AddNewPost(test);

            Assert.NotNull(result);
        }
        [Fact]
       public async Task Delete()
       {
            var result = await Svc<PostController>().DeleteConfirmation(Guid.Empty);

            Assert.IsType<BadRequestObjectResult>(result);
       }

        [Fact]
        public async Task NoImagePost()
        {
            var model = new Post { Files = null };

            var result = await Svc<PostController>().AddNewPost(model) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(model, result.Model);
            Assert.Equal("Palun lisa pilt!", result.ViewData["ErrorMessage"]);

        }
        [Fact]
        public async Task ShouldNot_CreatePost_WhenAgeNegative()
        {
            //ülesseade
            Post post = new Post
            {
                Age = -10,
                Name = "Test",
                Description = "bla bla cat",
                Gender = "male",
                Species = "krants",
                Title = "Test",
            };

            //tegevus
            var result = await Svc<PostController>().AddNewPost(post);

            //kontrollimine
            Assert.NotNull(result);

        }


        [Fact]
        public async Task ShouldHaveUniqueID_WhenPostCreated()
        {
            //ülesseadistus
            Post post1 = MockDataPost();
            Post post2 = MockDataPost();

           //tegevus
            Post create1 = (Post)await Svc<PostController>().AddNewPost(post1);
            Post create2 = (Post)await Svc<PostController>().AddNewPost(post2);

            //kontrollimine
            Assert.NotEqual(create1.Id, create2.Id);
        }
      
        private static Post MockDataPost()
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
