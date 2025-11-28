using Models;

namespace BL
{
    public interface IPodcastService
    {
        Task<Podcast> LoadFromRssAsync(string url);
        
        Task AddPodcastAsync(Podcast podcast);
        
        Task<List<Podcast>> GetAllPodcastsAsync();
        Task<Podcast> GetPodcastByIdAsync(string id);
        
        Task UpdatePodcastAsync(Podcast podcast);
        
        Task DeletePodcastAsync(string id);
    }
}
