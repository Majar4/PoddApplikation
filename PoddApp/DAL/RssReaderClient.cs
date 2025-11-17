using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using Models;


namespace DAL
{
    

    public class RssReaderClient
    {

        private HttpClient httpClient;

        public RssReaderClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Podcast>> GetPodcastByRssAsync(string rss)
        {
            Stream stream = await this.httpClient.GetStreamAsync(rss);
            XmlReader xmlReader = new XmlTextReader(stream);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);

            List<Podcast> podcasts = new List<Podcast>();

            Podcast aPodcast = new Podcast(rss)
            {
                Name = syndicationFeed.Title?.Text ?? "No title",
                //valfritt om vi vill ha beskrivning för podden, inget krav
                Description = syndicationFeed.Description?.Text ?? "",
                Episodes = new List<Episode>()
            };


            foreach (SyndicationItem item in syndicationFeed.Items)
            {
                Episode episode = new Episode
                {
                    Title = item.Title?.Text ?? "No title",
                    Description = item.Summary?.Text ?? "",
                    PublicationDate = item.PublishDate.DateTime,
                    // tror episodenumber är onödigt, vi kan ta bort
                    EpisodeNumber = item.Id
                };

                aPodcast.Episodes.Add(episode);
            }

            podcasts.Add(aPodcast);

            return podcasts;
        }
    }


}
