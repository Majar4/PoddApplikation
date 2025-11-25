using BL;
using Models;
using System.ComponentModel;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PL
{
    public partial class FormPoddApp : Form
    {
        private readonly PodcastService _podcastService;
        private readonly CategoryService _categoryService;
        private Podcast? fetchedPodcast;
        private BindingList<Category> _categoriescb = new BindingList<Category>();
        private BindingList<Category> _categoriesdg = new BindingList<Category>();


        public FormPoddApp(PodcastService podcastService, CategoryService categoryService)
        {
            InitializeComponent();
            _podcastService = podcastService;
            _categoryService = categoryService;

            this.Load += FormPoddApp_Load;
            LoadPodcastsAsync();
            LoadCategoriesAsync();
            
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string textUrl = txtUrl.Text;

                string error = Validator.RssIsValid(textUrl);

                if (error != null)
                {
                    MessageBox.Show(error);
                    txtUrl.Clear();
                    return;
                }

                Podcast thePodcast = await _podcastService.LoadFromRssAsync(textUrl);
                fetchedPodcast = thePodcast;

                txtName.Text = thePodcast.Name;
                txtUrl.Clear();

                //Visa bilden för sökt podcast, laddas direkt i picboxen
 
                if (!string.IsNullOrEmpty(thePodcast.ImageUrl))
                {
                    try
                    {
                        picPod.Load(thePodcast.ImageUrl);
                    }
                    catch
                    {
                        picPod.Image = null;
                    }

                }
                else
                {
                    picPod.Image = null;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCategorys_Click(object sender, EventArgs e)
        {
            FormCategorys form = new FormCategorys(_categoryService);
            form.ShowDialog();
            await LoadCategoriesAsync();
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
                comboColumn.DataSource = _categoriesdg;
                comboColumn.DisplayMember = "Name";
                comboColumn.ValueMember = "CategoryID";
                dataGridView1.Columns.Add(comboColumn);

                foreach (var podcast in allPodcasts)
                {

                    string categoryId = podcast.CategoryID ?? null;
                    dataGridView1.Rows.Add(podcast.Name, podcast.PCID, categoryId);
                }
            }
            catch (Exception ex)
            {
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
                string setName = fetchedPodcast.Name;

                string error = Validator.NameIsValid(setName);

                if (error != null)
                {
                    MessageBox.Show(error);
                    return;
                }

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
            try
            {
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
            var DBcategories = await _categoryService.GetAllCategoriesAsync();

            _categoriescb.Clear();
            _categoriesdg.Clear();

            foreach (var cat in DBcategories)
            {
                _categoriescb.Add(cat);
                _categoriesdg.Add(cat);

            }

            cbCategory.DataSource = _categoriescb;
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "CategoryID";

            cbCategory.SelectedIndex = -1;
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;  
        }

        private async void FormPoddApp_Load(object sender, EventArgs e)
        {
            
            await LoadCategoriesAsync();
            await LoadPodcastsAsync();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Välj en podcast.");
                    return;

                }

                var selectedRow = dataGridView1.SelectedRows[0];
                string podcastId = selectedRow.Cells["PCID"].Value?.ToString() ?? "";

                if (string.IsNullOrEmpty(podcastId))
                {
                    MessageBox.Show("Kunde inte läsa in podcast");
                    return;
                }
                Podcast podcast = await _podcastService.GetPodcastByIdAsync(podcastId);
                if (podcast == null)
                {
                    MessageBox.Show("Podcasten kunde inte hittas.");
                    return;
                }

                FormEpisodes form = new FormEpisodes(podcast);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
            }
        }

        private async void saveChangesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Markera en podcast för att ändra!");
                    return;
                }

                if (dataGridView1.IsCurrentCellInEditMode)
                {
                    dataGridView1.EndEdit();
                }

                var row = dataGridView1.SelectedRows[0];

                string pcid = row.Cells["PCID"].Value?.ToString();

                if (string.IsNullOrEmpty(pcid)) { 
                    MessageBox.Show("Kunde inte läsa in podcasten");
                    return;
                }

                string newName = row.Cells["Name"].Value?.ToString();

                string error = Validator.NameIsValid(newName);
                if (error != null)
                {
                    MessageBox.Show(error);
                    return;
                }
                
                string newCategoryId = row.Cells["Category"].Value?.ToString();
                

                Podcast podcast = await _podcastService.GetPodcastByIdAsync(pcid);
                podcast.Name = newName;
                podcast.CategoryID = string.IsNullOrEmpty(newCategoryId) ? null : newCategoryId;

                await _podcastService.UpdatePodcastAsync(podcast);
                MessageBox.Show("Informationen ändrad!");
                
                await LoadPodcastsAsync();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Fel: " + ex.Message);
                 
            }
        }
    }
}
