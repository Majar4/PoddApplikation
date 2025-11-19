using Models;

namespace BL
{
    public interface IPodcastService
    {
        Task<Podcast> LoadFromRssAsync(string url);
        //C
        Task AddPodcastAsync(Podcast podcast);
        //R
        Task<List<Podcast>> GetAllPodcastsAsync();
        Task<Podcast> GetPodcastByIdAsync(string id);
        //U
        Task UpdatePodcastAsync(Podcast podcast);
        //D
        Task DeletePodcastAsync(string id);
    }
}
