using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using Webzine.Business;
using Webzine.Business.Contracts;
using Webzine.EntitiesContext;
using Webzine.Models;
using Webzine.Repository.Contracts;
using Webzine.Repository.Local;
using Webzine.Repository.Db;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddControllers();

#endregion

#region Database

var database = builder.Configuration.GetSection("DatabaseType");

switch (database.Value)
{
    case "SQLITE":
        builder.Services.AddDbContext<WebzineDbContext>(
            options => options.UseSqlite(builder.Configuration.GetConnectionString("WebzineDbContext"))
        );
        break;

    case "POSTGRES":
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        builder.Services.AddDbContext<WebzineDbContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("WebzinePostgres"))
        );
    break;
}

#endregion

#region Container IOC

var dataContext = builder.Configuration.GetSection("DataContext");

// Seed la base de données
switch (dataContext.Value)
{
    case "DB":
        builder.Services.AddScoped<IArtisteRepository, DbArtisteRepository>();
        builder.Services.AddScoped<ITitreRepository, DbTitreRepository>();
        builder.Services.AddScoped<IStyleRepository, DbStyleRepository>();
        builder.Services.AddScoped<ICommentaireRepository, DbCommentaireRepository>();
        builder.Services.AddScoped<IRechercheService, RechercheService>();
    break;

    case "LOCAL":
        builder.Services.AddScoped<IArtisteRepository, LocalArtisteRepository>();
        builder.Services.AddScoped<ITitreRepository, LocalTitreRepository>();
        builder.Services.AddScoped<IStyleRepository, LocalStyleRepository>();
        builder.Services.AddScoped<ICommentaireRepository, LocalCommentaireRepository>();
        builder.Services.AddScoped<IRechercheService, RechercheService>();
    break;
}

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
        // Supprime et crÃ©Ã© la base de donnÃ©es.
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    catch (Exception)
    {
        throw;
    }

    var configuration = app.Configuration;

    var useDeezerApi = builder.Configuration.GetSection("UseDeezerApi");

    if (dataContext.Value == "DB")
    {
        // Seed la base de données
        switch (useDeezerApi.Value)
        {
            case "false" :
                DeezerSeedData.Initialize(services, configuration, false);
            break;

            default:
                DeezerSeedData.Initialize(services, configuration, true);
            break;
        }
    }

}

#endregion

app.UseRouting();
app.UseEndpoints(endpoints =>
{


    #region Administration

    #region Artiste
    endpoints.MapControllerRoute(
        name: "administrationArtistes",
        pattern: "administration/artistes",
        defaults: new { area = "administration", controller = "artiste", action = "index" });

    endpoints.MapControllerRoute(
        name: "administrationArtisteDelete",
        pattern: "administration/artiste/delete/{idArtiste}",
        defaults: new { area = "administration", controller = "artiste", action = "delete" });

    endpoints.MapControllerRoute(
        name: "administrationArtisteEdit",
        pattern: "administration/artiste/edit/{idArtiste}",
        defaults: new { area = "administration", controller = "artiste", action = "edit" });
    #endregion

    #region Titre
    endpoints.MapControllerRoute(
        name: "administrationTitres",
        pattern: "administration/titres",
        defaults: new { area = "administration", controller = "titre", action = "index" });


    endpoints.MapControllerRoute(
        name: "administrationTitreDelete",
        pattern: "administration/titre/delete/{idTitre}",
        defaults: new { area = "administration", controller = "titre", action = "delete" });

    endpoints.MapControllerRoute(
        name: "administrationTitreEdit",
        pattern: "administration/titre/edit/{idTitre}",
        defaults: new { area = "administration", controller = "titre", action = "edit" });
    #endregion

    #region Style
    endpoints.MapControllerRoute(
        name: "administrationStyles",
        pattern: "administration/styles",
        defaults: new { area = "administration", controller = "style", action = "index" });

    endpoints.MapControllerRoute(
        name: "administrationStyleDelete",
        pattern: "administration/style/delete/{idStyle}",
        defaults: new { area = "administration", controller = "style", action = "delete" });

    endpoints.MapControllerRoute(
        name: "administrationStyleEdit",
        pattern: "administration/style/edit/{idStyle}",
        defaults: new { area = "administration", controller = "style", action = "edit" });
    #endregion

    #region Commentaire
    endpoints.MapControllerRoute(
        name: "administrationCommentaires",
        pattern: "administration/commentaires",
        defaults: new { area = "administration", controller = "commentaire", action = "index" });

    endpoints.MapControllerRoute(
        name: "administrationCommentaireDelete",
        pattern: "administration/commentaire/delete/{idCommentaire}",
        defaults: new { area = "administration", controller = "commentaire", action = "delete" });
    #endregion

    #endregion

    #region Artiste
    endpoints.MapControllerRoute(
        name: "artiste",
        pattern: "artiste/{nomArtiste}",
        defaults: new { controller = "artiste", action = "index"});
    #endregion

    #region Titre
    endpoints.MapControllerRoute(
        name: "commenter",
        pattern: "titre/commenter",
        defaults: new { controller = "titre", action = "commenter" });

    endpoints.MapControllerRoute(
    name: "liker",
    pattern: "titre/liker",
    defaults: new { controller = "titre", action = "liker" });

    endpoints.MapControllerRoute(
        name: "titre",
        pattern: "titre/{idTitre}",
        defaults: new { controller = "titre", action = "index" });
    #endregion

    #region Style
    endpoints.MapControllerRoute(
        name: "style",
        pattern: "titres/styles/{libelle}",
        defaults: new { controller = "stylesearch", action = "index" });
    #endregion

    endpoints.MapControllerRoute(
        name: "home",
        pattern: "page/{numeroPage}",
        defaults: new { controller = "home", action = "index" });

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
