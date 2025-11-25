using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using Models;
using System.Linq.Expressions;


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
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            //Hämta podcasts bild url
            string imageUrl = null;
            //vanlig rss image url
            if (feed.ImageUrl != null)
            {
                imageUrl = feed.ImageUrl.ToString();
            }
            //itunes image url
            var itunesImage = feed.ElementExtensions
                 .FirstOrDefault(ext =>
                 ext.OuterName == "image" &&
                     ext.OuterNamespace == "http://www.itunes.com/dtds/podcast-1.0.dtd");
            if (itunesImage != null)
            {
                var reader = itunesImage.GetReader();
                if (reader.MoveToAttribute("href"))
                {
                    imageUrl = reader.Value;
                }
            }

            List<Podcast> podcasts = new List<Podcast>();

            Podcast aPodcast = new Podcast(rss)
            {
                Name = feed.Title?.Text ?? "No title",
                //valfritt om vi vill ha beskrivning för podden, inget krav
                Description = feed.Description?.Text ?? "",
                ImageUrl = imageUrl,
                Episodes = new List<Episode>()
            };


            foreach (SyndicationItem item in feed.Items)
            {
                Episode episode = new Episode
                {
                    Title = item.Title?.Text ?? "No title",
                    Description = item.Summary?.Text ?? "",
                    PublicationDate = item.PublishDate.DateTime,
                    // tror episodenumber är onödigt, vi kan ta bort
                    EpisodeNumber = item.Id
                };

                //Hämta avsnittsbilden från itunes:image om den finns
                var itunesEpisodeImage = item.ElementExtensions
                    .FirstOrDefault(ext =>
                    ext.OuterName == "image" &&
                    ext.OuterNamespace == "http://www.itunes.com/dtds/podcast-1.0.dtd");
                
                if (itunesEpisodeImage != null)
                {
                    var reader = itunesEpisodeImage.GetReader();
                    if (reader.MoveToAttribute("href"))
                    {
                        episode.ImageUrl = reader.Value;
                    }
                }

                aPodcast.Episodes.Add(episode);
            }

        podcasts.Add(aPodcast);
        return podcasts;
            
        }

    }
}
