using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Models;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Notifications;
using MediatR;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class DomainToggleButtonViewModel : ObservableObject, INotificationHandler<DomainSelectedNotification>
{
    private readonly IMediator _mediator;

    public DomainToggleButtonViewModel(
        Domains domain,
        IMediator mediator)
    {
        _mediator = mediator;

        Domain = domain;
    }

    [ObservableProperty]
    private Domains _domain;

    [ObservableProperty]
    private bool _isSelected;

    [ObservableProperty]
    private bool _isHover;

    public Task Handle(DomainSelectedNotification notification, CancellationToken cancellationToken)
    {
        IsSelected = notification.SelectedDomain == Domain;

        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task LoadedAsync()
    {
        await SelectAsync();
    }

    [RelayCommand]
    private async Task SelectAsync()
    {
        await _mediator.Publish(new DomainSelectedNotification(Domain));
    }

    [RelayCommand]
    private void HoverEnter()
    {
        IsHover = true;
    }

    [RelayCommand]
    private void HoverLeave()
    {
        IsHover = false;
    }
}
