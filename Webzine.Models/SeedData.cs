using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Webzine.EntitiesContext;
using Webzine.Entity.Factory;

namespace Webzine.Models
{
    public static class SeedData
    {
        // Fonction qui seed la base de données grâce aux factories créées.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebzineDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebzineDbContext>>()))
            {
                if (context.Titres.Any())
                {
                    return;
                }
                else
                {
                    context.Titres.AddRange(TitleFactory.CreateTitles());
                }

                // Save des changements effectués.
                context.SaveChanges();
            }
        }
    }
}
