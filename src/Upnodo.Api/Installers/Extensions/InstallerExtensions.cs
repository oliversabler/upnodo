using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Upnodo.Api.Installers.Interfaces;

namespace Upnodo.Api.Installers.Extensions
{
    internal static class InstallerExtensions
    {
        internal static void AddInstallersFromAssemblyContaining<TMarker>(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            AddInstallersFromAssembliesContaining(
                services,
                configuration,
                new[] { typeof(TMarker) });
        }

        internal static void AddInstallersFromAssembliesContaining(
            this IServiceCollection services,
            IConfiguration configuration,
            params Type[] assemblyMarkers)
        {
            var assemblies = assemblyMarkers.Select(t => t.Assembly).ToArray();

            AddInstallersFromAssemblies(services, configuration, assemblies);
        }

        internal static void AddInstallersFromAssemblies(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var installerTypes = assembly.DefinedTypes.Where(t =>
                    typeof(IInstaller).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract);

                var installers = installerTypes.Select(Activator.CreateInstance).Cast<IInstaller>();

                foreach (var installer in installers.OrderBy(o => o.Order))
                {
                    installer.AddServices(services, configuration);
                }
            }
        }
    }
}
