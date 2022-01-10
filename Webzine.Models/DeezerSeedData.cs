using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.DTO;

namespace Webzine.Models
{
    public class DeezerSeedData
    {
        public async static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebzineDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebzineDbContext>>()))
            {
                if (context.Artistes.Any())
                {
                    return;
                }
                else
                {
                    context.Artistes.AddRange(await DeezerSeedData.SeedArtiste());
                }

                //if (context.Styles.Any())
                //{
                //    return;
                //}
                //else
                //{
                //    context.Styles.AddRange(await DeezerSeedData.SeedStyle());
                //}

                //if (context.Titres.Any())
                //{
                //    return;
                //}
                //else
                //{
                //    context.Titres.AddRange(await DeezerSeedData.SeedTitre());
                //}

                // Save des changements effectués.
                context.SaveChanges();
            }
        }

        public async static Task<T> HttpCall<T>(string baseURI, string endpoint)
        {
            // Instance de client HTTP.
            var httpClient = new HttpClient();
            // Définition de l'URL de base.
            httpClient.BaseAddress = new Uri(baseURI);
            HttpResponseMessage response = httpClient.GetAsync(endpoint).Result;
            response.EnsureSuccessStatusCode();
            var x = response.Content.ReadAsStringAsync().Result;
            T result = JsonConvert.DeserializeObject<T>(x);
            return result;
        }

        public async static Task<ArtisteDTO> SeedArtiste()
        {
            var artiste = await HttpCall<ArtisteDTO>("https://api.deezer.com/", "artist/zola");
            artiste.Biographie = "Ok";
            return artiste;
        }

        public async static Task<TitreDTO> SeedTitre()
        {
            var titre = await HttpCall<TitreDTO>("https://api.deezer.com/", "track/3000001");
            return titre;
        }

        public async static Task<StyleDTO> SeedStyle()
        {
            var style = await HttpCall<StyleDTO>("https://api.deezer.com/", "genre/5");
            return style;
        }

    }
}
