using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catblog.Controllers;
using Catblog.Data;
using Catblog.Dto;
using Catblog.Models.Post;
using Catblog.ServiceInterface;
using Catblog.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestProject
{
    public class ControllersTests : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyPost_WhenPost()
        {
            Post test = MockDataPost1();

            var result = await Svc<PostController>().AddNewPost(test);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_CreatePost_WhenAgeNegative()
        {
            Post dto = new Post
            {
                Age = -10,
                Name = "Test",
                Description = "Test",
                Gender = "test",
                Species = "test",
                Title = "Test",
            };

            var result = await Svc<PostController>().AddNewPost(dto);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task DeleteConfirmWithInvalidId()
        {
            var result = await Svc<PostController>().DeleteConfirmation(Guid.Empty);

            Assert.IsType<BadRequestObjectResult>(result);
        }
        [Fact]
        public async Task AddNewPostWithoutImageFile()
        {
            var model = new Post { Files = null };

            var result = await Svc<PostController>().AddNewPost(model) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(model, result.Model);
            Assert.Equal("Palun lisa pilt!", result.ViewData["ErrorMessage"]);
        }
        [Fact]
        public async Task Get_AddNewPost()
        {
            var result = Svc<PostController>().AddNewPost() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<Post>(result.Model);
        }
        [Fact]
        public async Task PostDetails()
        {
            var result = await Svc<PostController>().PostDetails(Guid.Empty);

            Assert.Null(result);
        }
        private static Post MockDataPost1()
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
        private static Post MockDataPost2()
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
