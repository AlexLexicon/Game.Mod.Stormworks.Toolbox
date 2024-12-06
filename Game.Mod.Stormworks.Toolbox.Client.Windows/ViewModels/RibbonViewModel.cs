using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Models;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Notifications;
using Lexicom.Mvvm;
using MediatR;
using System.Collections.ObjectModel;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
public partial class RibbonViewModel : ObservableObject
{
    private readonly IMediator _mediator;
    private readonly IViewModelFactory _viewModelFactory;

    public RibbonViewModel(
        IMediator mediator,
        IViewModelFactory viewModelFactory)
    {
        _mediator = mediator;
        _viewModelFactory = viewModelFactory;

        DomainToggleButtonViewModels = [];
    }

    [ObservableProperty]
    private ObservableCollection<DomainToggleButtonViewModel> _domainToggleButtonViewModels;

    public Task LoadAsync()
    {
        DomainToggleButtonViewModels.Clear();
        foreach (Domains domain in Enum.GetValues<Domains>())
        {
            var domainToggleButtonViewModel = _viewModelFactory.Create<DomainToggleButtonViewModel, Domains>(domain);

            DomainToggleButtonViewModels.Add(domainToggleButtonViewModel);
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    private async Task ShowSettingsAsync()
    {
        await _mediator.Publish(new SettingsVisibilityNotification(IsVisible: true));
    }
}
