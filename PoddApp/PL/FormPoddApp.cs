using BL;
using Models;
using System.Security.Policy;
using System.Threading.Tasks;

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

            this.Load += FormPoddApp_Load;
            cbCategory.SelectedIndex = -1;
            LoadPodcastsAsync();
            
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

        private async Task LoadPodcastsAsync()
        {
            try
            {
                var allPodcasts = await _podcastService.GetAllPodcastsAsync();
                var allCategories = await _categoryService.GetAllCategoriesAsync();
                var categoryNames = allCategories.Select(c => c.Name).ToList();
                categoryNames.Add("Ingen kategori");

                dataGridView1.Columns.Clear();

                dataGridView1.Columns.Add("Name", "Namn");
                dataGridView1.Columns.Add("PCID", "PCID");
                dataGridView1.Columns["PCID"].Visible = false;

                var comboColumn = new DataGridViewComboBoxColumn();
                comboColumn.Name = "Category";
                comboColumn.HeaderText = "Kategori";
                comboColumn.DataSource = categoryNames;
                dataGridView1.Columns.Add(comboColumn);

                foreach (var podcast in allPodcasts)
                {
                    var categoryName = allCategories.FirstOrDefault(c => c.CategoryID == podcast.CategoryID)?.Name ?? "Ingen kategori";
                    dataGridView1.Rows.Add(podcast.Name, podcast.PCID, categoryName);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

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

                if (cbCategory.SelectedItem is Category SelectedCategory)
                {
                    fetchedPodcast.CategoryID = SelectedCategory.CategoryID;
                }
                else
                {
                    fetchedPodcast.CategoryID = null;
                }

                await _podcastService.AddPodcastAsync(fetchedPodcast);
                MessageBox.Show("Podcast sparad!");

                txtName.Clear();
                cbCategory.SelectedIndex = -1;

                await LoadPodcastsAsync();
               
            }
            catch (Exception ex)
            {
                throw new Exception("Det uppstod ett fel när podcasten skulle sparas.", ex);

            }
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            try { 
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Markera en ruta för att radera");
                return;
            }
            var selectedRow = dataGridView1.SelectedRows[0];

            string podcastId = selectedRow.Cells["PCID"].Value?.ToString();
                string podcastName = selectedRow.Cells["Name"].Value?.ToString() ?? "Okänt namn";


                var popup = MessageBox.Show("Är du säker på att du vill radera"
                    + podcastName + "?",
                    "Bekräfta radering",
                MessageBoxButtons.YesNo
                );

                if (popup == DialogResult.Yes)
                
                {
                    await _podcastService.DeletePodcastAsync(podcastId);
                    await LoadPodcastsAsync();
                    MessageBox.Show(podcastName + " har raderats!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();

            cbCategory.DataSource = null;
            cbCategory.DataSource = categories;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryID";
        }

        private async void FormPoddApp_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }
    }
}
