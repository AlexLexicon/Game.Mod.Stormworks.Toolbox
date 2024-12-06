using Game.Mod.Stormworks.Toolbox.Client.Windows.Models;
using MediatR;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Notifications;
public record class DomainSelectedNotification(Domains SelectedDomain) : INotification;