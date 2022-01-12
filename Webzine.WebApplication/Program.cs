using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using Webzine.Business;
using Webzine.Business.Contracts;
using Webzine.EntitiesContext;
using Webzine.Models;
using Webzine.Repository.Contracts;
using Webzine.Repository.Factory;
using Webzine.Repository.Local;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddControllers();

#endregion

#region EFCore / SQLite

builder.Services.AddDbContext<WebzineDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
);

#endregion

#region Container IOC

builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();


builder.Services.AddScoped<IRechercheService, RechercheService>();

//builder.Services.AddScoped<IArtisteRepository, FactoryArtisteRepository>();
//builder.Services.AddScoped<ITitreRepository, FactoryTitreRepository>();
//builder.Services.AddScoped<IStyleRepository, FactoryStyleRepository>();
//builder.Services.AddScoped<ICommentaireRepository, FactoryCommentaireRepository>();

#endregion

#region NLog

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

#endregion

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();



#region Database Seeding

var context = new WebzineDbContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
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
