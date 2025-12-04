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

namespace Catblog.Testing
{
	public class PostTests : TestBase
	{
		[Fact]
		public async Task Should_GetPostView_When_Triggered()
		{
			var result = Svc<PostController>().AddNewPost() as ViewResult;

			Assert.NotNull(result);
			Assert.IsType<Post>(result.Model);
		}
		[Fact]
		public async Task Should_ReturnError_When_NoImage()
		{
			var model = new Post { Files = null };

			var result = await Svc<PostController>().AddNewPost(model) as ViewResult;

			Assert.NotNull(result);
			Assert.Equal(model, result.Model);
			Assert.Equal("Palun lisa pilt!", result.ViewData["ErrorMessage"]);
		}
		[Fact]
		public async Task Should_ReturnError_When_NoId()
		{
			var result = await Svc<PostController>().DeleteConfirmation(Guid.Empty);

			Assert.IsType<BadRequestObjectResult>(result);
		}
		[Fact]
		public async Task ShouldNot_AddEmptyPost_When_Post()
		{
			Post test = MockDataPost();

			var result = await Svc<PostController>().AddNewPost(test);

			Assert.NotNull(result);
		}
		[Fact]
		public async Task ShouldNot_CreatePost_When_AgeNegative()
		{
			Post dto = new Post
			{
				Age = -10,
				Name = "Name",
				Description = "Description",
				Gender = "Gender",
				Species = "Species",
				Title = "Title",
			};

			var result = await Svc<PostController>().AddNewPost(dto);

			Assert.NotNull(result);
		}
		private static Post MockDataPost()
		{
			return new()
			{
				Id = Guid.NewGuid(),
				Name = "Name",
				Species = "Species",
				Age = 1,
				Gender = "Gender",
				Title = "Title",
				Description = "Description",
			};
		}
	}
}
