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
        private readonly CategoryService _categoryService;
        private BindingList<Category> _categories = new BindingList<Category>();
        private List<Category> _renamedCategories = new();
        private List<Category> _newCategories = new();

        public FormCategorys(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            dgvCategoryList.DataSource = _categories;
            _categories.ListChanged += category_ListChanged; // subscribe to method about list being changed (add/update)

            CorrectColumnSettings();
        }

        private void CorrectColumnSettings()
        {
            if (dgvCategoryList.Columns["CategoryID"] != null)
            {
                dgvCategoryList.Columns["CategoryID"].Visible = false;
            }
            if (dgvCategoryList.Columns["Name"] != null)
            {
                dgvCategoryList.Columns["Name"].HeaderText = "Benämning";
            }
        }

        private void category_ListChanged(object sender, ListChangedEventArgs e)
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
                        if (catInDb != null && !string.Equals(catInDb.Name, cat.Name.Trim(), StringComparison.OrdinalIgnoreCase));
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
            CorrectColumnSettings();
        }
    }
}
