using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Services;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private readonly IWindowService _windowService;

    public MainWindowViewModel(
        IWindowService windowService,
        SettingsViewModel settingsViewModel,
        RibbonViewModel ribbonViewModel,
        StatusBarViewModel statusBarViewModel)
    {
        _windowService = windowService;

        SettingsViewModel = settingsViewModel;
        RibbonViewModel = ribbonViewModel;
        StatusBarViewModel = statusBarViewModel;
    }

    [ObservableProperty]
    private double _top;

    [ObservableProperty]
    private double _left;

    [ObservableProperty]
    private double _width;

    [ObservableProperty]
    private double _height;

    [ObservableProperty]
    private bool _isMaximized;

    [ObservableProperty]
    private SettingsViewModel _settingsViewModel; 

    [ObservableProperty]
    private RibbonViewModel _ribbonViewModel;

    [ObservableProperty]
    private StatusBarViewModel _statusBarViewModel;

    [RelayCommand]
    private async Task LoadAsync()
    {
        var getTopTask = _windowService.GetTopAsync();
        var getLeftTask = _windowService.GetLeftAsync();
        var getWidthTask = _windowService.GetWidthAsync();
        var getHeightTask = _windowService.GetHeightAsync();

        Top = await getTopTask;
        Left = await getLeftTask;
        Width = await getWidthTask;
        Height = await getHeightTask;

        await SettingsViewModel.LoadAsync();
        await RibbonViewModel.LoadAsync();
    }

    [RelayCommand]
    private async Task CloseAsync()
    {
        await _windowService.SaveAsync(Top, Left, Width, Height);
    }
}
