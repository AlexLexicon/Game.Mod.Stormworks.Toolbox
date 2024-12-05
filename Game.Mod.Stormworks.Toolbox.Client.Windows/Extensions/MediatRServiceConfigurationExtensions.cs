using Microsoft.Extensions.DependencyInjection;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Extensions;
public static class MediatRServiceConfigurationExtensions
{
    public static void AddTileEditor(this MediatRServiceConfiguration configuration)
    {
        configuration.RegisterServicesFromAssemblyContaining<AssemblyScanMarker>();
    }
}
