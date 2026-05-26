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

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
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
                    else
                    {
                        //moving all the rest of the users to day mode
                        item.ForeColor = MenuForm.IsDarkMode ? Color.White : Color.Black;
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

        private void ApplyCurrentTheme()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ApplyCurrentTheme));
                return;
            }

            if (MenuForm.IsDarkMode)
            {
                this.BackColor = Color.FromArgb(35, 35, 35);

                lvHighScores.BackColor = Color.FromArgb(45, 45, 45);
                lvHighScores.ForeColor = Color.White;

                for (int i = 1; i < lvHighScores.Items.Count; i++)
                {
                    lvHighScores.Items[i].ForeColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);

                lvHighScores.BackColor = Color.White;
                lvHighScores.ForeColor = Color.Black;

                for (int i = 1; i < lvHighScores.Items.Count; i++)
                {
                    lvHighScores.Items[i].ForeColor = Color.Black;
                }
            }
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