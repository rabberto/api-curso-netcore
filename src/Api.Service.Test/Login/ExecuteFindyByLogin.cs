using System;
using System.Threading.Tasks;
using Api.Domain.DTOs;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class ExecuteFindyByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;
        [Fact(DisplayName = "This possible execute FindByLogin method")]
        public async Task Execute_FindByLogin_Method()
        {
            var email = Faker.Internet.Email();
            var objectReturn = new
            {
                authentication = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userEmail = email,
                message = "Login Success"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objectReturn);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);

        }
    }
}