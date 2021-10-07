using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOs.User;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User
{
    public class WhenGet
    {
        private UsersController _controller;
        [Fact(DisplayName = "Get Return Ok")]
        public async Task Get_Return_Ok()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
               new UserDto
               {
                   Id = Guid.NewGuid(),
                   Name = nome,
                   Email = email,
                   CreateAt = DateTime.UtcNow
               }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
        }

        [Fact(DisplayName = "Get Return BadRequest")]
        public async Task Get_Return_BadReques()
        {
            var serviceMock = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
               new UserDto
               {
                   Id = Guid.NewGuid(),
                   Name = nome,
                   Email = email,
                   CreateAt = DateTime.UtcNow
               }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Invalid format");
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

    }
}