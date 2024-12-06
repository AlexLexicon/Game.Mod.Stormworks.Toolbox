using MediatR;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Notifications;
public record class SettingsVisibilityNotification(bool IsVisible) : INotification;