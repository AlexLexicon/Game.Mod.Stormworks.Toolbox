using FluentValidation;
using Game.Mod.Stormworks.Toolbox.Application.Database.Options;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.Options;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Validators;
public class DatabaseOptionsValidator : AbstractOptionsValidator<DatabaseOptions>
{
    public DatabaseOptionsValidator()
    {
        RuleFor(o => o.ConnectionString)
            .NotNull()
            .NotSimplyEmpty()
            .NotAllWhitespaces();
    }
}
