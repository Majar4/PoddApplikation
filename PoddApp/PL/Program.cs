//using DAL;
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

            var dbString = Environment.GetEnvironmentVariable("MONGO_CONNECTION_STRING");
            var dbName = "PodcastDB";

            IMongoDBService mongoService = new MongoDBService(dbString, dbName);

            var podcastService = mongoService.createPodcastService();
            var categoryService = mongoService.createCategoryService();

                ApplicationConfiguration.Initialize();
            Application.Run(new FormPoddApp(podcastService, categoryService));

        }
    }
}