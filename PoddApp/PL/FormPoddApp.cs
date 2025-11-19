using BL;
using Models;
using System.Security.Policy;

namespace PL
{
    public partial class FormPoddApp : Form
    {
        private readonly PodcastService _podcastService;
        private readonly CategoryService _categoryService;

        public FormPoddApp(PodcastService podcastService, CategoryService categoryService)
        {
            InitializeComponent();
            _podcastService = podcastService;
            _categoryService = categoryService;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string textUrl = txtUrl.Text;
            Podcast thePodcast = await _podcastService.LoadFromRssAsync(textUrl);
            MessageBox.Show("Funkar");
            txtName.Text = thePodcast.Name;
        }
    }
}
