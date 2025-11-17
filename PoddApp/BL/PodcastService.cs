using DAL;
using Models;
using System.Linq.Expressions;

namespace BL
{
    public class PodcastService : IPodcastService
    {
        // Håller kopplingen till databasen (DAL).
        private readonly IRepository<Podcast> podcastRepo;
        // Håller kopplingen till RSS-läsaren i DAL.
        private readonly RssReaderClient rssClient;

        // Tar emot ett Repository från utsidan och sparar det i fältet ovan.
        public PodcastService(IRepository<Podcast> podcastRepo, RssReaderClient rssClient)
        {
            this.podcastRepo = podcastRepo;// gör repositoryt tillgängligt i hela klassen
            this.rssClient = rssClient; // gör RSS-klienten tillgänglig i hela klassen
        }

        public async Task<Podcast> LoadFromRssAsync(string url) // Läser in en podcast från en RSS-url via RssReaderClient
        {
            try
            {
                // Hämtar podcast-data från RSS genom DAL-klassen RssReaderClient
                var podcasts = await rssClient.GetPodcastByRssAsync(url);

                if (podcasts == null || podcasts.Count == 0) //Om returnerar null eller tom lista
                    throw new Exception("Det gick inte att hitta någon podcast i RSS-flödet. Kontrollera RSS-länken."); //UI tar emot detta
                // Returnerar första podcasten 
                return podcasts.FirstOrDefault();
            }
            catch (Exception ex) //Andra fel, nätverksfel mm
            {
                throw new Exception("Det gick inte att läsa RSS-flödet. Kontrollera RSS-länken och försök igen.",ex);
            }
        }

        //C (All info om avsnitt kommer från RssReaderClient)
        public async Task AddPodcastAsync(Podcast podcast) //Podcast-objekt från UI sparas till MongoDb via DAL. 
        {
            try
            {
                if (podcast == null)
                    throw new ArgumentException("Ingen podcast har hämtats. Hämta en podcast innan du sparar.");//Ska inte enbart förlita sig på att kanpp inte är klickbar i UI.
                
                // obs! Lägg till dublettkontroll och att url inte är blank.

                await podcastRepo.AddAsync(podcast); //Skickar till repositoryt som kör InsertOne
            }
            catch (Exception ex)
            { 
                throw new Exception("Det uppstod ett fel när podcasten skulle sparas.", ex);
            }
        }

        //R

        public async Task<List<Podcast>> GetAllPodcastsAsync() 
        {
            try
            {
                var podcasts = await podcastRepo.GetAllAsync();
                return podcasts; //Kan ej bli null, listan kan vara tom. 
            }
            catch(Exception ex)
            {
                throw new Exception("Fel uppstod vid hämtning från databasen.", ex);
            }
        }

        public async Task<Podcast?> GetPodcastByIdAsync(string id)
        {
            try
            {
                //Lägg till för om ID är tomt
                var podcast = await podcastRepo.GetByIdAsync(id);
                if (podcast == null)
                    throw new Exception("Podcasten kunde inte hittas.");

                return podcast;
            }
            catch (Exception ex)
            {
                throw new Exception("Det gick inte att hämta podcasten.", ex);
            }
        }

        //U
        public async Task UpdatePodcastAsync(Podcast podcast)
        {
            try
            {
                if (podcast == null)
                    throw new ArgumentException("Ingen podcast har valts för uppdatering.");

                bool updated = await podcastRepo.UpdateAsync(podcast);
                if (!updated)
                    throw new Exception("Podcasten kunde inte uppdateras.");
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle uppdateras.", ex);
            }
        }

        //D
        public async Task DeletePodcastAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Ingen podcast har valts för borttagning.");
                await podcastRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle tas bort.", ex);
            }
        }
    }
}
