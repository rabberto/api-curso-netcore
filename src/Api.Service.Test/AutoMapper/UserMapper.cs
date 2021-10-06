using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class UserMapper : BaseTestService
    {
        [Fact(DisplayName = "This possible Mapper the Model")]
        public void Mapper_Model()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listUser = new List<UserEntity>();
            for (int i = 0; i < 10; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listUser.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity => Dto
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);

            var listDto = Mapper.Map<List<UserDto>>(listUser);
            Assert.True(listDto.Count() == listUser.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].Id, listUser[i].Id);
                Assert.Equal(listDto[i].Name, listUser[i].Name);
                Assert.Equal(listDto[i].Email, listUser[i].Email);
                Assert.Equal(listDto[i].CreateAt, listUser[i].CreateAt);
            }

            var useDtoCreateResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(useDtoCreateResult.Id, entity.Id);
            Assert.Equal(useDtoCreateResult.Name, entity.Name);
            Assert.Equal(useDtoCreateResult.Email, entity.Email);
            Assert.Equal(useDtoCreateResult.CreateAt, entity.CreateAt);

            var useDtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(useDtoUpdateResult.Id, entity.Id);
            Assert.Equal(useDtoUpdateResult.Name, entity.Name);
            Assert.Equal(useDtoUpdateResult.Email, entity.Email);
            Assert.Equal(useDtoUpdateResult.UpdateAt, entity.UpdateAt);

            //Dto => Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, entity.Id);
            Assert.Equal(userModel.Name, entity.Name);
            Assert.Equal(userModel.Email, entity.Email);
            Assert.Equal(userModel.CreateAt, entity.CreateAt);

            var userDtoCreate = Mapper.Map<UserDtoCreate>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var UserDtoUpdate = Mapper.Map<UserDtoUpdate>(userModel);
            Assert.Equal(UserDtoUpdate.Id, userModel.Id);
            Assert.Equal(UserDtoUpdate.Name, userModel.Name);
            Assert.Equal(UserDtoUpdate.Email, userModel.Email);

        }
    }
}