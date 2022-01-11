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
                    context.Artistes.AddRange(await SeedArtiste());
                }

                if (context.Styles.Any())
                {
                    return;
                }
                else
                {
                    context.Styles.AddRange(await SeedStyle());
                }

                if (context.Titres.Any())
                {
                    return;
                }
                else
                {
                    var titres = await SeedPlaylist();
                    foreach (var titre in titres)
                    {
                        context.Titres.Add(titre);
                    }
                }

                // Save des changements effectués.
                context.SaveChanges();
            }
        }

        public async static Task<T> HttpCall<T>(string endpoint)
        {
            var baseURI = "https://api.deezer.com/";
            // Instance de client HTTP.
            var httpClient = new HttpClient();
            // Définition de l'URL de base.
            httpClient.BaseAddress = new Uri(baseURI);
            HttpResponseMessage response = httpClient.GetAsync(endpoint).Result;
            response.EnsureSuccessStatusCode();
            var entity = response.Content.ReadAsStringAsync().Result;
            T result = JsonConvert.DeserializeObject<T>(entity);
            return result;
        }
        
        public async static Task<Artiste> SeedArtiste()
        {
            var artiste = await HttpCall<Artiste>("artist/zola");
            artiste.Biographie = "La biographie de cet artiste n'a pas pu être récupérée.";
            return artiste;
        }

        public async static Task<Titre> SeedTitre()
        {
            var titre = await HttpCall<Titre>("track/3135556");
            return titre;
        }

        public async static Task<Style> SeedStyle()
        {
            var style = await HttpCall<Style>("genre/5");
            return style;
        }

        public async static Task<List<Titre>> SeedPlaylist()
        {
            var playlist = await HttpCall<DeezerRequest>("user/2529/playlists");
            return playlist.Data;
        }

    }
}
