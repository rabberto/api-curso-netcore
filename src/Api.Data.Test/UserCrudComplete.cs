using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Text;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UserCrudComplete : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProdiver;

        public UserCrudComplete(DbTest dbTest)
        {
            _serviceProdiver = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD User")]
        [Trait("CRUD", "UserEntity")]
        public async Task CRU_USER()
        {
            using (var context = _serviceProdiver.GetService<MyContext>())
            {
                UserImplementation _respotitory = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };
                var _registerCreated = await _respotitory.InsertAsync(_entity);
                Assert.NotNull(_registerCreated);
                Assert.Equal(_entity.Email, _registerCreated.Email);
                Assert.Equal(_entity.Name, _registerCreated.Name);
                Assert.False(_entity.CreateAt.Equals(null));
                Assert.False(_registerCreated.Id == System.Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registerUpdate = await _respotitory.UpdateAsync(_entity);
                Assert.NotNull(_registerUpdate);
                Assert.Equal(_entity.Email, _registerUpdate.Email);
                Assert.Equal(_entity.Name, _registerUpdate.Name);
                Assert.False(_entity.UpdateAt == null);

                var _registerSelect = await _respotitory.SelectAsync(_registerUpdate.Id);
                Assert.NotNull(_registerUpdate);
                Assert.Equal(_registerSelect.Email, _registerUpdate.Email);
                Assert.Equal(_registerSelect.Name, _registerUpdate.Name);

                var _allRegister = await _respotitory.SelectAllAsync();
                Assert.NotNull(_allRegister);
                Assert.True(_allRegister.Count() > 1);

                var _removeRegister = await _respotitory.DeleteAsync(_registerSelect.Id);
                Assert.True(_removeRegister);

                var _userDefault = await _respotitory.FindByLogin("rbbsolucoes@rbbsolucoes.com.br");
                var _userNameDefault = "Administrator";
                Assert.NotNull(_userDefault);
                Assert.Equal(_userDefault.Name, _userNameDefault);

            }
        }
    }
}