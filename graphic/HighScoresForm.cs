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
            LoadHighScores();
        }

        private void SetupListViewColumns()
        {
            lvHighScores.Columns.Add("Rank", 100, HorizontalAlignment.Center);
            lvHighScores.Columns.Add("Player Name", 350, HorizontalAlignment.Left);
            lvHighScores.Columns.Add("Score", 200, HorizontalAlignment.Center);
        }

        private void LoadHighScores()
        {
            try
            {
                lvHighScores.Items.Clear();

                GetHighScoreResponse res = Communicator.SendAndReceive<GetHighScoreResponse>(109, new GetHighScoreRequest());

                if (res.status != 1 || res.statistics == null)
                {
                    MessageBox.Show("Failed to load high scores from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int rank = 1;
                foreach (string entry in res.statistics)
                {
                    string[] parts = entry.Split(':');
                    string playerName = parts[0].Trim();
                    string playerScore = parts.Length > 1 ? parts[1].Trim() : "0";

                    ListViewItem item = new ListViewItem(rank.ToString());
                    item.SubItems.Add(playerName);
                    item.SubItems.Add(playerScore);

                    if (rank == 1)
                    {
                        item.ForeColor = Color.Gold;
                        item.Font = new Font(lvHighScores.Font, FontStyle.Bold);
                    }

                    lvHighScores.Items.Add(item);
                    rank++;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading high scores: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }

    public struct GetHighScoreRequest
    {
    }

    public struct GetHighScoreResponse
    {
        public uint status { get; set; }
        public List<string> statistics { get; set; }
    }
}