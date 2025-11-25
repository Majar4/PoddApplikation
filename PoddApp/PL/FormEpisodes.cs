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
                string cleanDescription = RemoveHtmlTags(e.Description).Trim();
                dgvEpisodeList.Rows.Add(e.Title, cleanDescription, e.PublicationDate);
            }
        }

        private string RemoveHtmlTags(string html)
        {
            return System.Text.RegularExpressions.Regex.Replace(html, "<.*?>", "");
        }

        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            if (dgvEpisodeList.SelectedRows.Count == 1)
            {
                var selectedRow = dgvEpisodeList.SelectedRows[0];
                string title = selectedRow.Cells["colEpisodeName"].Value?.ToString() ?? "";
                string description = selectedRow.Cells["colDescription"].Value?.ToString() ?? "";
                string date = selectedRow.Cells["colDate"].Value?.ToString() ?? "";

                lblTitle.Text = "Titel: " + title;
                lblDate.Text = "Datum: " + date;
                tbDescription.Text = RemoveHtmlTags(description);

                //hämta bild till episode om finns
                var episode = _podcast.Episodes.FirstOrDefault(ep => ep.Title == title);
                string imageToShow = null;

                if (episode != null && !string.IsNullOrEmpty(episode.ImageUrl))
                {
                    imageToShow = episode.ImageUrl;
                }
                else if (!string.IsNullOrEmpty(_podcast.ImageUrl))
                {
                    imageToShow = _podcast.ImageUrl;
                }
                if (!string.IsNullOrEmpty(imageToShow)) {
                    try
                    {
                        picEpisode.Load(imageToShow);
                        picEpisode.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch
                    {
                        picEpisode.Image = null;
                    }
                }
                else
                {
                    picEpisode.Image = null; // ingen bild
                }
            }

            else
            {
                MessageBox.Show("Du måste välja ett avsnitt");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
