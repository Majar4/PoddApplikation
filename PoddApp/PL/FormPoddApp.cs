using BL;
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
            await _podcastService.LoadFromRssAsync(textUrl);
            MessageBox.Show("Funkar");
        }
    }
}
