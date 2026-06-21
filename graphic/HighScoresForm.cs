using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class HighScoresForm : Form
    {
        private bool _isBackButtonClicked = false;

        public HighScoresForm()
        {
            InitializeComponent();
            SetupListViewColumns();
            LoadHighScores();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

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
                    string[] parts = entry.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string playerName = parts.Length > 0 ? parts[0].Trim() : "Unknown";
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
                        // Moving all the rest of the users to the correct theme mode
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
            _isBackButtonClicked = true;
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

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_isBackButtonClicked)
            {
                Application.Exit();
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