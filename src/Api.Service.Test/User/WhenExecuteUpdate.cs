using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteUpdate : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "This possible execute Update method")]
        public async Task Execute_Update_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(UserNameUpdate, resultUpdate.Name);
            Assert.Equal(UserEmailUpdate, resultUpdate.Email);
        }
    }
}