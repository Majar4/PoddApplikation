using BL;
using Models;
using System.Security.Policy;

namespace PL
{
    public partial class FormPoddApp : Form
    {
        private readonly PodcastService _podcastService;
        private readonly CategoryService _categoryService;
        private Podcast? fetchedPodcast;

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
            fetchedPodcast = thePodcast;
            MessageBox.Show("Funkar");
            txtName.Text = thePodcast.Name;
        }

        private void btnCategorys_Click(object sender, EventArgs e)
        {
            FormCategorys form = new FormCategorys(_categoryService);
            form.ShowDialog();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (fetchedPodcast == null)
                {
                    MessageBox.Show("Fyll i sökrutan!");
                    return;
                }

                fetchedPodcast.Name = txtName.Text;

                await _podcastService.AddPodcastAsync(fetchedPodcast);
                MessageBox.Show("Podcast sparad!");
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle sparas.", ex);

            }


        }
    }
}
