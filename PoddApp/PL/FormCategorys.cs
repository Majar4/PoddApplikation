using BL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{

    public partial class FormCategorys : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IPodcastService _podcastService;
        private BindingList<Category> _categories = new BindingList<Category>();
        private List<Category> _renamedCategories = new();
        private List<Category> _newCategories = new();

        public FormCategorys(ICategoryService categoryService, IPodcastService podcastService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _podcastService = podcastService;
            dgvCategoryList.DataSource = _categories;
            _categories.ListChanged += category_ListChanged; 

            CorrectColumnSettings();
        }

        private void CorrectColumnSettings()
        {
            var categoryIDColumn = dgvCategoryList.Columns["CategoryID"];

            if (categoryIDColumn != null)
            {
                categoryIDColumn.Visible = false;
            }
            var nameColumn = dgvCategoryList.Columns["Name"];

            if (nameColumn != null)
            {
                nameColumn.HeaderText = "Benämning";
            }
        }

        private void category_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                int index = e.NewIndex;
                var addedCategory = _categories[index];
                _newCategories.Add(addedCategory);
            }
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                int index = e.NewIndex;
                var renamedCategory = _categories[index];
                _renamedCategories.Add(renamedCategory);
            }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (var cat in _newCategories)
            {
                if (!string.IsNullOrWhiteSpace(cat.Name) && string.IsNullOrWhiteSpace(cat.CategoryID))
                {
                    try
                    {
                        await _categoryService.AddCategoryAsync(cat.Name);
                        MessageBox.Show("Kategori sparad");
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            foreach (var cat in _renamedCategories)
            {
                if (!string.IsNullOrWhiteSpace(cat.CategoryID))
                {
                    try
                    {
                        var catInDb = await _categoryService.GetCategoryByIdAsync(cat.CategoryID);
                        if (catInDb != null && !string.Equals(catInDb.Name, cat.Name.Trim(), StringComparison.OrdinalIgnoreCase)) ;
                        {
                            await _categoryService.RenameCategoryAsync(cat.CategoryID, cat.Name);
                            MessageBox.Show("Kategorinamn ändrad");
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newCategory = new Category();
            _categories.Add(newCategory);
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            var DBcategories = await _categoryService.GetAllCategoriesAsync();
            _categories.Clear();
            foreach (var cat in DBcategories)
            {
                _categories.Add(cat);
            }
            dgvCategoryList.DataSource = null;
            dgvCategoryList.DataSource = _categories;
            CorrectColumnSettings();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoryList.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Markera en rad för att radera kategorin");
                    return;
                }
                var selectedRow = dgvCategoryList.SelectedRows[0];
                string catID = selectedRow.Cells["CategoryID"].Value?.ToString();
                string catName = selectedRow.Cells["Benämning"].Value?.ToString();

                var popup = MessageBox.Show("Är du säker på att du vill radera " + catName + "?",
                    "Bekräfta radering",
                    MessageBoxButtons.YesNo);
                if (popup == DialogResult.Yes)
                {
                    var allPodcasts = await _podcastService.GetAllPodcastsAsync();
                    bool podcastUsesCategory = allPodcasts.Any(p => p.CategoryID == catID);

                    if (podcastUsesCategory)
                    {
                        MessageBox.Show("Denna kategori tillhör poddflöden, går ej att radera");
                        return;
                    }

                    await _categoryService.DeleteCategoryAsync(catID);
                    var DBcategories = await _categoryService.GetAllCategoriesAsync();
                    _categories.Clear();
                    foreach (var cat in DBcategories)
                    {
                        _categories.Add(cat);
                    }
                    CorrectColumnSettings();
                    MessageBox.Show(catName + " har raderats");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = tbNameSearch.Text.Trim().ToLower();
            if(string.IsNullOrWhiteSpace(searchText))
            {
                btnShowAll_Click(sender, e);
                return;
            }
            var filtered = _categories
                .Where(c => !string.IsNullOrWhiteSpace(c.Name) &&
                c.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            tbNameSearch.Clear();

            dgvCategoryList.DataSource = null;
            dgvCategoryList.DataSource = filtered;
            CorrectColumnSettings();
            
        }
        
    }
}
