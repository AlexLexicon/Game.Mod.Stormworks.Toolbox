using Game.Mod.Stormworks.Toolbox.Application.Database.Extensions;
using Game.Mod.Stormworks.Toolbox.Application.Extensions;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Extensions;
using Game.Mod.Stormworks.Toolbox.Client.Windows.Presentation.Views;
using Game.Mod.Stormworks.Toolbox.Client.Windows.ViewModels;
using Lexicom.Concentrate.Supports.Wpf.Extensions;
using Lexicom.Concentrate.Wpf.Amenities.Extensions;
using Lexicom.Concentrate.Wpf.Themes.Extensions;
using Lexicom.Configuration.Settings.For.Wpf.Extensions;
using Lexicom.DependencyInjection.Primitives.Extensions;
using Lexicom.DependencyInjection.Primitives.For.Wpf.Extensions;
using Lexicom.Logging.For.Wpf.Extensions;
using Lexicom.Mvvm.Amenities.Extensions;
using Lexicom.Mvvm.Extensions;
using Lexicom.Mvvm.For.Wpf.Extensions;
using Lexicom.Supports.Wpf.Extensions;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.For.Wpf.Extensions;
using Lexicom.Wpf.Amenities.Extensions;
using Lexicom.Wpf.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Mod.Stormworks.Toolbox.Client.Windows.Presentation;
public partial class App : System.Windows.Application
{
    public App()
    {
        var builder = WpfApplication.CreateBuilder(this);

        builder.Services.AddDatabase();
        builder.Services.AddApplication();
        builder.Services.AddClient();

        builder.Lexicom(l =>
        {
            l.AddSettings(Presentation.Properties.Settings.Default);

            l.AddLogging(builder.Configuration);

            l.AddAmenities();

            l.AddMvvm(mvvm =>
            {
                mvvm.AddMediatR(mr =>
                {
                    mr.AddTileEditor();
                });

                mvvm.AddViewModel<DomainToggleButtonViewModel>(ServiceLifetime.Transient);
                mvvm.AddViewModel<MainWindowViewModel>(vm =>
                {
                    vm.ForWindow<MainWindowView>();
                });
                mvvm.AddViewModel<RibbonViewModel>();
                mvvm.AddViewModel<SettingsDatabaseViewModel>();
                mvvm.AddViewModel<SettingsPreferencesViewModel>();
                mvvm.AddViewModel<SettingsViewModel>();
                mvvm.AddViewModel<StatusBarViewModel>();
            });

            l.AddPrimitives(p =>
            {
                p.AddGuidProvider();
                p.AddTimeProvider();
            });

            l.AddValidation(v =>
            {
                v.AddAmenities();
                v.AddDatabase();
                v.AddClient();
            });

            l.Concentrate(lc =>
            {
                lc.AddAmenities();
                lc.AddTheming();
            });
        });

        var app = builder.Build();

        app.StartupWindow<MainWindowView>();
    }
}
