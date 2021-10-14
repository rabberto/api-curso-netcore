using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Data.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Domain.Repository;
using System;
using System.Collections;

namespace Api.CrossCuttin.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                serviceCollection.AddDbContext<MyContext>(
                   options => options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                   );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseMySql("Server=localhost;Port=3306;Database=dbCurso;Uid=root;Pwd=8&r1@NH@")
                    );
            }
        }
    }
}