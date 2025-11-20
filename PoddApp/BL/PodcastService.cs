using DAL;
using Models;
using System.Linq.Expressions;

namespace BL
{
    public class PodcastService : IPodcastService
    {
        private readonly IRepository<Podcast> podcastRepo;
        private readonly RssReaderClient rssClient;

        
        public PodcastService(IRepository<Podcast> podcastRepo, RssReaderClient rssClient)
        {
            this.podcastRepo = podcastRepo;
            this.rssClient = rssClient; 
        }

        public async Task<Podcast> LoadFromRssAsync(string url) 
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Du måste ange en RSS-länk.");
            try
            {
                var podcasts = await rssClient.GetPodcastByRssAsync(url);

                if (podcasts == null || podcasts.Count == 0) 
                    throw new Exception("Det gick inte att hitta någon podcast i RSS-flödet. Kontrollera RSS-länken."); 
                
                return podcasts.FirstOrDefault();
            }
            catch (Exception ex) 
            {
                throw new Exception("Det gick inte att läsa RSS-flödet. Kontrollera RSS-länken och försök igen.",ex);
            }
        }

        //C 
        public async Task AddPodcastAsync(Podcast podcast)  
        {
            try
            {
                if (podcast == null)
                    throw new ArgumentException("Ingen podcast har hämtats. Hämta en podcast innan du sparar.");//Ska inte enbart förlita sig på att kanpp inte är klickbar i UI.
                
                await podcastRepo.AddAsync(podcast); 
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
                return podcasts;  
            }
            catch(Exception ex)
            {
                throw new Exception("Fel uppstod vid hämtning från databasen.", ex);
            }
        }
        
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

        //U 
        public async Task UpdatePodcastAsync(Podcast podcast)
        {
            if (podcast == null)
                throw new ArgumentException("Ingen podcast har valts för uppdatering.");

            if (string.IsNullOrWhiteSpace(podcast.PCID))
                throw new ArgumentException("Podcast saknas, kan inte uppdateras.");


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

        //D 
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
