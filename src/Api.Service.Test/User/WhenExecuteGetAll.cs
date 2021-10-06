using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Services;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class WhenExecuteGetAll : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        [Fact(DisplayName = "This possible execute Get All method")]
        public async Task Execute_Get_All_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userDtoList);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Equals(userDtoList));
            Assert.True(result.Count() == 10);

        }
    }
}