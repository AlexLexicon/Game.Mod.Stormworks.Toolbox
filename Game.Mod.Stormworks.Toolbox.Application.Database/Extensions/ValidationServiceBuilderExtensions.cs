using Lexicom.Validation;
using Lexicom.Validation.Extensions;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Extensions;
public static class ValidationServiceBuilderExtensions
{
    public static void AddDatabase(this IValidationServiceBuilder builder)
    {
        builder.AddValidators<AssemblyScanMarker>();
    }
}
