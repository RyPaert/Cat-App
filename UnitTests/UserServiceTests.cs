using Catblog.ServiceInterface;
using Catblog.Services;
using NUnit.Framework;

namespace UnitTests
{
    public class UserServiceTests
    {
        PostServices postService;
        IPostServices ipostService;

        [SetUp]
        public void Setup()
        {
            postService = new PostServices();
        }

        [Test]
        public void PostDetailsAsync_Works()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
