using DAL;
using Models;
using System.Linq.Expressions;

namespace BL
{
    public class PodcastService : IPodcastService
    {
        // Håller koppling till DAL.
        private readonly IRepository<Podcast> podcastRepo;
        // Håller koppling till RSS-läsaren i DAL.
        private readonly RssReaderClient rssClient;

        
        public PodcastService(IRepository<Podcast> podcastRepo, RssReaderClient rssClient)
        {
            this.podcastRepo = podcastRepo;// gör repositoryt tillgängligt i hela klassen
            this.rssClient = rssClient; // gör RSS-klienten tillgänglig i hela klassen
        }

        public async Task<Podcast> LoadFromRssAsync(string url) // hämta poddflöde. Läser in en podcast från en RSS-url via RssReaderClient
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Du måste ange en RSS-länk.");
            try
            {
                // Hämtar podcast-data från RSS genom DAL-klassen RssReaderClient
                var podcasts = await rssClient.GetPodcastByRssAsync(url);

                if (podcasts == null || podcasts.Count == 0) 
                    throw new Exception("Det gick inte att hitta någon podcast i RSS-flödet. Kontrollera RSS-länken."); //UI tar emot detta
                // Returnerar första podcasten 
                return podcasts.FirstOrDefault();
            }
            catch (Exception ex) 
            {
                throw new Exception("Det gick inte att läsa RSS-flödet. Kontrollera RSS-länken och försök igen.",ex);
            }
        }

        //C (All info om avsnitt kommer från RssReaderClient)Sparar en podcast i databasen (-spara poddflöde)
        public async Task AddPodcastAsync(Podcast podcast)  
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

        //R Hämtar alla poddar (-visa lista över sparade poddar)

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
        //Hämtar en podd via ID(-välja ett poddflöde)
        public async Task<Podcast> GetPodcastByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Ingen podcast valdes.");
            try
            {
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

        //U Uppdaterar podcast (ändra namn / ändra kategori)
        public async Task UpdatePodcastAsync(Podcast podcast)
        {
            if (podcast == null)
                throw new ArgumentException("Ingen podcast har valts för uppdatering.");

            if (string.IsNullOrWhiteSpace(podcast.PCID))
                throw new ArgumentException("Podcast saknas, kan inte uppdateras.");

            //var hasAnythingChanged = false;

            //var existingPodcast = await GetPodcastByIdAsync(podcast.PCID);

            //if(podcast.Name != existingPodcast.Name)
            //{
            //    hasAnythingChanged = true;
            //}

            try
            {
                bool updated = await podcastRepo.UpdateAsync(podcast);

                if (!updated)
                    throw new Exception("Podcasten kunde inte uppdateras.");
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle uppdateras.", ex);
            }
        }

        //D Tar bort podcast (-radera poddflöde)
        public async Task DeletePodcastAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Ingen podcast har valts för borttagning."); 
            
            try
            {
                await podcastRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle tas bort.", ex);
            }
        }
    }
}
