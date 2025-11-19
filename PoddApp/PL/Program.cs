using DAL;
using Models;
using BL;
namespace PL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            HttpClient http = new HttpClient();
            var client = new RssReaderClient(http);
            var dbString = "mongodb+srv://OruMongoDBAdmin:<HRkIURZpQ7xJl0Kp>@orumongodb.vv4muwv.mongodb.net/?appName=OruMongoDB";
            var dbName = "PodcastDB";

            var podcastRepo = new PodcastRepository(dbString, dbName);
            var categoryRepo = new CategoryRepository(dbString, dbName);

            var podcastService = new PodcastService(podcastRepo, client);
            var categoryService = new CategoryService(categoryRepo);
            
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPoddApp(podcastService, categoryService));

        }
    }
}