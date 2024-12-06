using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Concentrate.Wpf.Themes;
using System.Collections.ObjectModel;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class SettingsPreferencesViewModel : ObservableObject
{
    private readonly IThemeService _themeService;

    public SettingsPreferencesViewModel(IThemeService themeService)
    {
        _themeService = themeService;

        Themes = [];
    }

    [ObservableProperty]
    private ObservableCollection<string> _themes;

    [ObservableProperty]
    private string? _selectedTheme;



    public async Task LoadAsync()
    {
        var getThemeTask = _themeService.GetThemeAsync();
        var getThemesTask = _themeService.GetThemesAsync();

        SelectedTheme = await getThemeTask;
        var themes = await getThemesTask;

        Themes.Clear();
        foreach (string theme in themes)
        {
            Themes.Add(theme);
        }

        await ThemeSelectedAsync();
    }

    [RelayCommand]
    private async Task ThemeSelectedAsync()
    {
        if (SelectedTheme is not null)
        {
            await _themeService.SetThemeAsync(SelectedTheme);
        }
    }
}
