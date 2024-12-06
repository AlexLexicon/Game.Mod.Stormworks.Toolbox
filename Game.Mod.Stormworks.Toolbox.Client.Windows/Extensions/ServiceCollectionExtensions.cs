using Game.Mod.Stormworks.Toolbox.Client.Windows.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddClient(this IServiceCollection services)
    {
        services.AddSingleton<IWindowService, WindowService>();
    }
}
