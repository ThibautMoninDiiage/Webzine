using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.Models;
using Webzine.Repository.Contracts;
using Webzine.Repository.Local;
using Webzine.Repository.Db;

var builder = WebApplication.CreateBuilder(args);

#region EFCore / SQLite

builder.Services.AddDbContext<WebzineDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
);

#endregion

#region Container IOC

builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();

//builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
//builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
//builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
//builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();

#endregion

#region NLog

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

#endregion

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

#region Database Seeding

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<WebzineDbContext>();
        // Supprime et créé la base de données.
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    catch (Exception)
    {
        throw;
    }

    // Seed la base de données
    SeedData.Initialize(services);
}

#endregion

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Administration",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
app.UseStaticFiles();

app.Run();
