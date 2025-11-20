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
    public partial class FormEpisodes : Form
    {
        private readonly Podcast _podcast;

        public FormEpisodes(Podcast podcast)
        {
            InitializeComponent();
            _podcast = podcast;
            lblPodCastName.Text = _podcast.Name;

            foreach (var e in _podcast.Episodes)
            {
                dgvEpisodeList.Rows.Add(e.Title, e.Description, e.PublicationDate);
            }
        }
    }
}
