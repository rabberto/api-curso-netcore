using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.DTOs.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Models;
using Api.Domain.Services;
using AutoMapper;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repoditory;
        private readonly IMapper _mapper;
        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repoditory = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repoditory.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            // return _mapper.Map<UserDto>(await _repoditory.SelectAsync(id));
            var entity = await _repoditory.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            // return _mapper.Map<IEnumerable<UserDto>>(await _repoditory.SelectAllAsync());
            var listEntity = await _repoditory.SelectAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            // return _mapper.Map<UserDtoCreateResult>(
            //     await _repoditory.InsertAsync(
            //         _mapper.Map<UserEntity>(
            //             _mapper.Map<UserModel>(user
            //             )
            //         )
            //     )
            // );

            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repoditory.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repoditory.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}