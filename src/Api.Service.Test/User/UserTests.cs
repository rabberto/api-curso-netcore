using System;
using System.Collections.Generic;
using Api.Domain.DTOs.User;

namespace Api.Service.Test.User
{
    public class UserTests
    {
        public static string UserName { get; set; }
        public string UserEmail { get; set; }
        public static string UserNameUpdate { get; set; }
        public string UserEmailUpdate { get; set; }
        public static Guid UserId { get; set; }

        public List<UserDto> userDtoList = new List<UserDto>();
        public UserDto userDto;
        public UserDtoCreate userDtoCreate;
        public UserDtoCreateResult userDtoCreateResult;
        public UserDtoUpdate userDtoUpdate;
        public UserDtoUpdateResult userDtoUpdateResult;

        public UserTests()
        {
            UserId = Guid.NewGuid();
            UserName = Faker.Name.FullName();
            UserEmail = Faker.Internet.Email();
            UserNameUpdate = Faker.Name.FullName();
            UserEmailUpdate = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                userDtoList.Add(dto);
            }

            userDto = new UserDto
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreate = new UserDtoCreate
            {
                Name = UserName,
                Email = UserEmail
            };

            userDtoCreateResult = new UserDtoCreateResult
            {
                Id = UserId,
                Name = UserName,
                Email = UserEmail,
                CreateAt = DateTime.UtcNow
            };

            userDtoUpdate = new UserDtoUpdate
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate
            };

            userDtoUpdateResult = new UserDtoUpdateResult
            {
                Id = UserId,
                Name = UserNameUpdate,
                Email = UserEmailUpdate,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}