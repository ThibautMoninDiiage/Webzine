using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Webzine.EntitiesContext;
using Webzine.Models;
using Webzine.Repository.Contracts;
using Webzine.Repository.Local;

var builder = WebApplication.CreateBuilder(args);

#region EFCore / SQLite

builder.Services.AddDbContext<WebzineDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
);

var context = new WebzineDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

#endregion

#region container IOC

builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();

#endregion

#region NLog

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

#endregion

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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
