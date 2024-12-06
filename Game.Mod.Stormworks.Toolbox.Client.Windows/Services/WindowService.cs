using Lexicom.Concentrate.Wpf.Amenities;
using Lexicom.Configuration.Settings;
using Microsoft.Extensions.Options;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Services;
public interface IWindowService
{
    Task<double> GetTopAsync();
    Task<double> GetLeftAsync();
    Task<double> GetWidthAsync();
    Task<double> GetHeightAsync();
    Task SaveAsync(double top, double left, double width, double height);
}
public class WindowService : IWindowService
{
    //these default values match the default values in the 'Game.Mod.Stormworks.Toolbox.Client.Windows.Presentation.Properties.Settings.settings' file
    private const double DEFAULT_TOP = 128;
    private const double DEFAULT_LEFT = 128;
    private const double DEFAULT_WIDTH = 800;
    private const double DEFAULT_HEIGHT = 400;

    private readonly ISettingsWriter _settingsWriter;
    private readonly IOptions<WindowOptions> _windowsOptions;

    public WindowService(
        ISettingsWriter settingsWriter,
        IOptions<WindowOptions> windowsOptions)
    {
        _settingsWriter = settingsWriter;
        _windowsOptions = windowsOptions;
    }

    public Task<double> GetTopAsync()
    {
        double top = _windowsOptions.Value?.Top ?? DEFAULT_TOP;

        return Task.FromResult(top);
    }

    public Task<double> GetLeftAsync()
    {
        double left = _windowsOptions.Value?.Left ?? DEFAULT_LEFT;

        return Task.FromResult(left);
    }

    public Task<double> GetWidthAsync()
    {
        double width = _windowsOptions.Value?.Width ?? DEFAULT_WIDTH;

        return Task.FromResult(width);
    }

    public Task<double> GetHeightAsync()
    {
        double height = _windowsOptions.Value?.Height ?? DEFAULT_HEIGHT;

        return Task.FromResult(height);
    }

    public async Task SaveAsync(double top, double left, double width, double height)
    {
        await _settingsWriter.SaveAndBindAsync(new WindowOptions
        {
            Top = top,
            Left = left,
            Width = width,
            Height = height,
        });
    }
}
