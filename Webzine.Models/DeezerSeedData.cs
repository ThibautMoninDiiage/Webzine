using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Webzine.Business;
using Webzine.EntitiesContext;
using Webzine.Entity;
using Webzine.Entity.DTO;
using Webzine.Entity.Interfaces;
using Webzine.Repository.Contracts;

namespace Webzine.Models
{
    public class DeezerSeedData
    {


        /// <summary>
        /// Initialise les données de l'application avec les data de l'api de deezer.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public async static void Initialize(IServiceProvider serviceProvider, bool useDeezerApi = true)
        {
            using (var context = new WebzineDbContext(serviceProvider.GetRequiredService<DbContextOptions<WebzineDbContext>>()))
            {
                // if there is no titles on the application
                if (context.Titres.Any())
                {
                    return;
                }
                else
                {
                    JsonService jsonService = new JsonService();
                    PictureService pictureService = new PictureService();

                    IEnumerable<TitreDTO> allTitres;
                    IEnumerable<StyleDTO> allStyles;

                    if (useDeezerApi)
                    {
                        allTitres = await GetPlaylistDeezer();
                        allStyles = await GetStylesDeezer();

                        allTitres.ToList().ForEach(t => t.AlbumDTO.CoverXl = pictureService.SavePicture(t.AlbumDTO.CoverXl, t.IdTitre.ToString()));


                        jsonService.WriteJsonFile<List<TitreDTO>>(@"TitresFromDeezer.json", allTitres.ToList());
                        jsonService.WriteJsonFile<List<StyleDTO>>(@"StylesFromDeezer.json", allStyles.ToList());

                    }
                    else
                    {
                        allTitres = jsonService.ReadJsonFile<List<TitreDTO>>("TitresFromDeezer.json");
                        allStyles = jsonService.ReadJsonFile<List<StyleDTO>>("StylesFromDeezer.json");
                    }


                    // Remplace "/" par " " pour éviter les problèmes dans les url
                    IEnumerable<Style> styles = allStyles.Select(s => new Style { IdStyle = s.Id, Libelle = s.Name.Replace("/", " ") });
                    context.Styles.AddRange(styles);


                    IEnumerable<Artiste> artistes = allTitres.Select(t => new Artiste(
                        t.Artiste.Id,
                        t.Artiste.Name,
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        DateTime.Now,
                        t.Artiste.Link
                        ));

                    context.AddRange(artistes.DistinctBy(a => a.Nom));

                    var random = new Random();

                    IEnumerable<Titre> titres = allTitres.Select(t => new Titre(
                        t.IdTitre,
                        t.Artiste.Id,
                        context.Artistes.Find(t.Artiste.Id),
                        t.Libelle,
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        DateTime.Now,
                        t.Duree,
                        DateTime.Now,
                        t.AlbumDTO.CoverXl ?? t.AlbumDTO.Cover ?? "",
                        t.UrlEcoute,
                        t.NbLectures,
                        t.NbLectures / 7,
                        t.AlbumDTO.Title,
                        context.Styles.Local.Skip(1).OrderBy(s => random.Next()).Take(random.Next(1, 4)).ToList()
                        ));

                    context.AddRange(titres);
                }
                
                // Save des changements effectués.
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Cette méthode envoie une requète http et retourne le résultat déserialise
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


        /// <summary>
        /// Methode qui recupere les titres d'une playlist depuis l'api de deezer
        /// </summary>
        /// <returns>retourne tous les titres d'une plylist</returns>
        public async static Task<IEnumerable<TitreDTO>> GetPlaylistDeezer(int numeroPlaylist = 1109890291)
        {
            var deezerRequest = await HttpCall<DeezerRequestTitreDTO>("https://api.deezer.com/playlist/"+ numeroPlaylist +"/tracks");


            return deezerRequest.Titres;
        }


        /// <summary>
        /// Methode pour recuperer les styles de l'api de deezer
        /// </summary>
        /// <returns>La liste de tous les styles de deezer</returns>
        public async static Task<IEnumerable<StyleDTO>> GetStylesDeezer()
        {
            var deezerRequest = await HttpCall<DeezerRequestStyleDTO>("https://api.deezer.com/genre");
            return deezerRequest.Styles;
        }
    }
}
