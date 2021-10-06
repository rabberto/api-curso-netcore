using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteDelete : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "This possible execute Delete method")]
        public async Task Execute_Delete_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(UserId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var resultDelete = await _service.Delete(UserId);
            Assert.True(resultDelete);
        }
    }
}