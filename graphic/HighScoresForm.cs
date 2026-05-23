using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    public partial class HighScoresForm : Form
    {
        public HighScoresForm()
        {
            InitializeComponent();
            SetupListViewColumns();
            LoadMockHighScores();
        }

        private void SetupListViewColumns()
        {
            lvHighScores.Columns.Add("Rank", 100, HorizontalAlignment.Center);
            lvHighScores.Columns.Add("Player Name", 350, HorizontalAlignment.Left);
            lvHighScores.Columns.Add("Score", 200, HorizontalAlignment.Center);
        }

        private void LoadMockHighScores()
        {
            lvHighScores.Items.Clear();

            var topPlayers = new List<Tuple<string, int>>()
            {
                new Tuple<string, int>("AlphaGamer", 5200),
                new Tuple<string, int>("Trivia_King", 4850),
                new Tuple<string, int>("CyberShield", 4100),
                new Tuple<string, int>("NoobMaster99", 3900),
                new Tuple<string, int>("Magshimim_Student", 3500)
            };

            int rank = 1;
            foreach (var player in topPlayers)
            {
                ListViewItem item = new ListViewItem(rank.ToString());
                item.SubItems.Add(player.Item1);
                item.SubItems.Add(player.Item2.ToString());

                if (rank == 1)
                {
                    item.ForeColor = Color.Gold;
                    item.Font = new Font(lvHighScores.Font, FontStyle.Bold);
                }

                lvHighScores.Items.Add(item);
                rank++;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}