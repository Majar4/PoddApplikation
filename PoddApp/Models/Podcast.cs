namespace Models
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PCID { get; set; }
        public string url { get; set; }
        public List<Episode> episodes { get; set; }
        public Podcast(string name)
        {
            Name = name;
            PCID = string.Empty;
            url = string.Empty;
        }

        public Podcast()
        {

        }
    }
}
