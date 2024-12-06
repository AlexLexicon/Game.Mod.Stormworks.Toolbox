using CommunityToolkit.Mvvm.ComponentModel;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Validators;
using Lexicom.Validation;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class SettingsDatabaseViewModel : ObservableObject
{
    public SettingsDatabaseViewModel(IRuleSetValidator<FilePathRuleSet, string?> filePathValidator)
    {
        FilePathValidator = filePathValidator;
    }

    [ObservableProperty]
    private string? _filePath;

    [ObservableProperty]
    private IRuleSetValidator<FilePathRuleSet, string?> _filePathValidator;

    public Task LoadAsync()
    {
        return Task.CompletedTask;
    }
}
