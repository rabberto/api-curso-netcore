using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteCreate : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "This possible execute Create method")]
        public async Task Execute_Create_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }
    }
}