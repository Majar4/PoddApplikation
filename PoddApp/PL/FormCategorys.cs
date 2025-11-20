using BL;
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

        public FormCategorys(CategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
