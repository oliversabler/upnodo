using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Upnodo.Api.Installers.Interfaces
{
    public interface IInstaller
    {
        public int Order { get; set; }

        void AddServices(IServiceCollection services, IConfiguration configuration);
    }
}
