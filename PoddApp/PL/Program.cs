using DAL;
using Models;
using BL;
using System.Threading.Tasks;
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

            var dbString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var dbName = "PodcastDB";

            var podcastRepo = new PodcastRepository(dbString, dbName);
            var categoryRepo = new CategoryRepository(dbString, dbName);

            IPodcastService podcastService = new PodcastService(podcastRepo, client);
            ICategoryService categoryService = new CategoryService(categoryRepo);

                ApplicationConfiguration.Initialize();
            Application.Run(new FormPoddApp(podcastService, categoryService));

        }
    }
}