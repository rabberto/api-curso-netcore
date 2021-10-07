using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.DTOs.User;
using Api.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User
{
    public class WhenGetAll
    {
        private UsersController _controller;
        [Fact(DisplayName = "Get Return Ok")]
        public async Task GetAll_Return_Ok()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
               new List<UserDto>
               {
                   new UserDto{
                   Id = Guid.NewGuid(),
                   Name = Faker.Name.FullName(),
                   Email = Faker.Internet.Email(),
                   CreateAt = DateTime.UtcNow

                   },
                   new UserDto{
                   Id = Guid.NewGuid(),
                   Name = Faker.Name.FullName(),
                   Email = Faker.Internet.Email(),
                   CreateAt = DateTime.UtcNow

                   },
               }
            );

            _controller = new UsersController(serviceMock.Object);
            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.True(resultValue.Count() >= 2);
        }

        [Fact(DisplayName = "GetAll Return BadRequest")]
        public async Task GetAll_Return_BadReques()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
               new List<UserDto>
               {
                   new UserDto{
                   Id = Guid.NewGuid(),
                   Name = Faker.Name.FullName(),
                   Email = Faker.Internet.Email(),
                   CreateAt = DateTime.UtcNow

                   },
                   new UserDto{
                   Id = Guid.NewGuid(),
                   Name = Faker.Name.FullName(),
                   Email = Faker.Internet.Email(),
                   CreateAt = DateTime.UtcNow

                   },
               }
            );

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Email", "Invalid format");
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }

    }
}