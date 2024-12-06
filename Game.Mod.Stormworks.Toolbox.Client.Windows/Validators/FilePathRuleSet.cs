using FluentValidation;
using Lexicom.Validation;
using Lexicom.Validation.Amenities.Extensions;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Validators;
public class FilePathRuleSet : AbstractRuleSet<string?>
{
    public override void Use<T>(IRuleBuilderOptions<T, string?> ruleBuilder)
    {
        ruleBuilder
            .NotNull()
            .NotSimplyEmpty()
            .NotAllWhitespaces()
            .FilePath()
            .FileExists()
            .AnyDigits()
            .AnyLowerCaseCharacters()
            .AnyUpperCaseCharacters();
    }
}
