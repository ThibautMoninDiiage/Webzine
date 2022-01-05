using Webzine.Repository.Contracts;
using Webzine.Repository.Factory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

# region container IOC

builder.Services.AddScoped<IArtisteRepository, FactoryArtisteRepository>();
builder.Services.AddScoped<ITitreRepository, FactoryTitreRepository>();
builder.Services.AddScoped<IStyleRepository, FactoryStyleRepository>();
builder.Services.AddScoped<ICommentaireRepository, FactoryCommentaireRepository>();

#endregion

#region NLog

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

#endregion

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var app = builder.Build();

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
