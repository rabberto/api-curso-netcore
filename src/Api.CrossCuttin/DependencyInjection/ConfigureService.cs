using Api.Domain.Interfaces.Services.User;
using Api.Domain.Services;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCuttin.DependencyInjection
{
    public class ConfigureService
    {
        public static void CongifureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}