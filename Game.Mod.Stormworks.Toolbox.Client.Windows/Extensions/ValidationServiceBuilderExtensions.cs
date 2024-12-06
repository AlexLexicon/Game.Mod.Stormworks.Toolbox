using Lexicom.Validation;
using Lexicom.Validation.Extensions;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Extensions;
public static class ValidationServiceBuilderExtensions
{
    public static void AddClient(this IValidationServiceBuilder builder)
    {
        builder.AddRuleSets<AssemblyScanMarker>();
        builder.AddValidators<AssemblyScanMarker>();
    }
}
