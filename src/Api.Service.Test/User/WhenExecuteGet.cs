using System;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Services;
using Api.Service.Test.User;
using Moq;
using Xunit;

namespace Api.Service.Test
{
    public class WhenExecuteGet : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "This possible execute Get method")]
        public async Task Execute_Get_Method()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(UserId);
            Assert.Null(_record);
        }
    }
}