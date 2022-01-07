using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Webzine.EntitiesContext;
using Webzine.Entity.Factory;

namespace Webzine.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebzineDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WebzineDbContext>>()))
            {
                if (context.Artistes.Any())
                {
                    return;
                } else
                {
                    context.Artistes.AddRange(ArtistFactory.CreateArtists());
                }

                context.SaveChanges();
            }
        }
    }
}
