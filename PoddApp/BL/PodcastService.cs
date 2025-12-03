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


        public async Task AddPodcastAsync(Podcast podcast)//Uppdaterad förr att skydda mot duplicateKey 
        {
            if (podcast == null)
                throw new ArgumentException("Ingen podcast har hämtats. Hämta en podcast innan du sparar.");

            var savedPodcasts = await podcastRepo.GetAllAsync();
            // Kontrollerar om det redan finns en podcast med samma URL.
            // Finns sparad podcast där den sparade och den nya podcastens URL inte är null, och där URL:erna är identiska
            if (savedPodcasts.Any(p => 
                p?.Url != null && podcast.Url != null && string.Equals(p.Url, podcast.Url, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Podden finns redan sparad.");

            try
            {
                await podcastRepo.AddAsync(podcast);//Försök lägga till i databasen
            }
            catch (Exception ex)
            {
                throw new Exception("Det gick inte att spara podcasten", ex);// Om något ändå går fel, kasta fel
            }
        }


        public async Task<List<Podcast>> GetAllPodcastsAsync() 
        {
            var podcasts = await podcastRepo.GetAllAsync();
            return podcasts;  
        }
        
        public async Task<Podcast> GetPodcastByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Ingen podcast valdes.");
     
                var podcast = await podcastRepo.GetByIdAsync(id);

            if (podcast == null)
                    throw new Exception("Podcasten kunde inte hittas.");

            return podcast;
        }

        
        public async Task UpdatePodcastAsync(Podcast podcast)
        {
            if (podcast == null)
                throw new ArgumentException("Ingen podcast har valts för uppdatering.");

            if (string.IsNullOrWhiteSpace(podcast.PCID))
                throw new ArgumentException("Podcast saknas, kan inte uppdateras.");

            bool updated = await podcastRepo.UpdateAsync(podcast);

            if (!updated)
                    throw new Exception("Podcasten kunde inte uppdateras.");
        
        }

        
        public async Task DeletePodcastAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Ingen podcast har valts för borttagning."); 

            await podcastRepo.DeleteAsync(id);
          
        }
    }
}
