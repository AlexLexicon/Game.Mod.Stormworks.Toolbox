using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Concentrate.Wpf.Amenities;
using Microsoft.Extensions.Options;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private readonly IOptions<WindowOptions> _windowsOptions;

    public MainWindowViewModel(IOptions<WindowOptions> windowsOptions)
    {
        _windowsOptions = windowsOptions;
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

    [RelayCommand]
    private async Task LoadAsync()
    {
        Top = _windowsOptions.Value?.Top ?? 0;
        Left = _windowsOptions.Value?.Left ?? 0;
        Width = _windowsOptions.Value?.Width ?? 0;
        Height = _windowsOptions.Value?.Height ?? 0;
    }
}
