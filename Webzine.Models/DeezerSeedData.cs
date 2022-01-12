using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.DTO;
using Webzine.Repository.Contracts;

namespace Webzine.Models
{
    public class DeezerSeedData
    {


        public async static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new WebzineDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebzineDbContext>>()))
            {
                if (context.Titres.Any())
                {
                    return;
                }
                else
                {

                    var resultTitres = await SeedTitre();
                    IEnumerable<ArtistDTO> artistes;
                    artistes = resultTitres.Select(t => t.Artist).DistinctBy(a => a.Name);


                    foreach (var artiste in artistes)
                    {
                        context.Artistes.Add(new Artiste
                        {
                            IdArtiste = artiste.Id,
                            Biographie = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Nom = artiste.Name,
                            UrlSite = artiste.Link
                        });
                    }

                    context.SaveChanges();

                    foreach (var titre in resultTitres)
                    {
                        context.Titres.AddRange(new Titre
                        {
                            IdTitre = titre.Id,
                            Album = titre.Album.Title,
                            Artiste = context.Artistes.Find(titre.Artist.Id),
                            Duree = titre.Duration,
                            UrlJaquette = titre.Album.Cover,
                            DateSortie = DateTime.Now,
                            Libelle = titre.Title,
                            NbLikes = 0,
                            NbLectures = titre.Rank,
                            Chronique = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            IdArtiste = titre.Artist.Id,
                            DateCreation = DateTime.Now,
                            UrlEcoute = titre.Preview
                        });
                    }
                }

                // Save des changements effectués.
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Cette méthode envoie une requète http et retourne le résultat déserialisé
        /// </summary>
        /// <typeparam name="T">Une classe</typeparam>
        /// <param name="url">Une url qui retourne du JSON</param>
        /// <returns>Une instance d'objet</returns>
        public async static Task<T> HttpCall<T>(string url)
        {
            // Instance de client HTTP.
            var httpClient = new HttpClient();
            // Définition de l'URL de base.
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            var entity = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(entity);
        }

        public async static Task<IEnumerable<TitreDTO>> SeedTitre()
        {
            var deezerRequest = await HttpCall<DeezerRequestRootDTO>("https://api.deezer.com/playlist/1109890291/tracks");


            return deezerRequest.Data;
        }

    }
}
