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
            _categories = new BindingList<Category>();
            dgvCategoryList.DataSource = _categories;

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

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            var DBcategories = await _categoryService.GetAllCategoriesAsync();
            _categories = new BindingList<Category>(DBcategories);
            dgvCategoryList.DataSource = _categories;

            CorrectColumnSettings();
        }
    }
}
