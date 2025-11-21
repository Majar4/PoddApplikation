using BL;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private List<Category> _categories = new List<Category>();

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
            _categories = await _categoryService.GetAllCategoriesAsync();
            dgvCategoryList.DataSource = null;
            dgvCategoryList.DataSource = _categories;
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
        {
            var currentCell = dgvCategoryList.CurrentCell;
            if (currentCell == null || currentCell.Value == null)
            {
                MessageBox.Show("Vänligen skriv in ett kategorinamn");
                return;
            }
            string categoryName = currentCell.Value.ToString().Trim();

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Vänligen skriv in ett kategorinamn");
                return;
            }
            await _categoryService.AddCategoryAsync(categoryName);

            await LoadCategoriesAsync();
            MessageBox.Show("Kategori sparad");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
