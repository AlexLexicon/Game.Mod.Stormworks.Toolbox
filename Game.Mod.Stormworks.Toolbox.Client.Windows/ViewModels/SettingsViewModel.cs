using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Notifications;
using MediatR;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class SettingsViewModel : ObservableObject, INotificationHandler<SettingsVisibilityNotification>
{
    private readonly IMediator _mediator;

    public SettingsViewModel(
        IMediator mediator,
        SettingsPreferencesViewModel settingsPreferencesViewModel,
        SettingsDatabaseViewModel settingsDatabaseViewModel)
    {
        _mediator = mediator;

        SettingsPreferencesViewModel = settingsPreferencesViewModel;
        SettingsDatabaseViewModel = settingsDatabaseViewModel;
    }

    [ObservableProperty]
    private bool _isVisible;

    [ObservableProperty]
    private SettingsPreferencesViewModel _settingsPreferencesViewModel;

    [ObservableProperty]
    private SettingsDatabaseViewModel _settingsDatabaseViewModel;

    public async Task LoadAsync()
    {
        await SettingsPreferencesViewModel.LoadAsync();
        await SettingsDatabaseViewModel.LoadAsync();
    }

    public Task Handle(SettingsVisibilityNotification notification, CancellationToken cancellationToken)
    {
        IsVisible = notification.IsVisible;

        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task HideAsync()
    {
        await _mediator.Publish(new SettingsVisibilityNotification(IsVisible: false));
    }
}
