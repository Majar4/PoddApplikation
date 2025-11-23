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

        public FormCategorys(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

            this.Load += FormCategorys_Load;
        }

        private async void FormCategorys_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            var DBcategories = await _categoryService.GetAllCategoriesAsync();
            _categories = new BindingList<Category>(DBcategories);
            dgvCategoryList.DataSource = _categories;
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            foreach (var cat in _categories)
            {
                if (!string.IsNullOrWhiteSpace(cat.Name) && string.IsNullOrWhiteSpace(cat.CategoryID))
                {
                    string catName = cat.Name.Trim();
                    await _categoryService.AddCategoryAsync(catName);
                }
            }
            await LoadCategoriesAsync();
            MessageBox.Show("Kategori sparad");
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
    }
}
