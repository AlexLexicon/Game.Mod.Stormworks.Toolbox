using Game.Mod.Stormworks.Toolbox.Application.Database.Options;
using Game.Mod.Stormworks.Toolbox.Application.Database.Validators;
using Lexicom.Validation.Options.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Game.Mod.Stormworks.Toolbox.Application.Database.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddDatabase(this IServiceCollection services)
    {
        services
            .AddOptions<DatabaseOptions>()
            .PostConfigure<IConfiguration>((o, c) =>
            {
                o.ConnectionString = c.GetConnectionString("SwToolsDbContext");
            })
            .Validate<DatabaseOptions, DatabaseOptionsValidator>()
            .ValidateOnStart();

        services.AddDbContextFactory<SwToolboxDbContext>((sp, dbc) =>
        {
            var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOptions>>();

            dbc.UseSqlite(databaseOptions.Value.ConnectionString);
        });
    }
}
