using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clientGraphic.MenuForm;


namespace clientGraphic
{
    public partial class GameResultForm : Form
    {
        public GameResultForm()
        {
            InitializeComponent();
            InitGrid();
            LoadGameResult();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void LoadGameResult()
        {
            try
            {
                GetGameResultsResponse res = Communicator.SendAndReceive<GetGameResultsResponse>((Byte)CodeR.GetGameResultsResponseCmd);

                if (res.status != 1 || res.results == null)
                {
                    MessageBox.Show("Failed to load game result from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (res.results != null && res.results.Count > 0)
                {
                    var winner = res.results
                        .OrderByDescending(p => p.correctAnswersCount)
                        .First();

                    lblWinner.Text = $"Winner: {winner.userName}";
                }

                lvResults.Items.Clear();

                foreach (var player in res.results)
                {
                    var item = new ListViewItem(player.userName);

                    item.SubItems.Add(player.correctAnswersCount.ToString());
                    item.SubItems.Add(player.wrongAnswersCount.ToString());
                    item.SubItems.Add(player.averageAnswersTime.ToString());

                    lvResults.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading GameResult: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void InitGrid()
        {
            lvResults.Columns.Clear();

            lvResults.Columns.Add("Username", 150);
            lvResults.Columns.Add("Correct", 100);
            lvResults.Columns.Add("Wrong", 100);
            lvResults.Columns.Add("Avg Time", 120);

            lvResults.View = View.Details;
            lvResults.FullRowSelect = true;
        }
    }
    public struct PlayerResult
    {
        public string userName { get; set; }
        public uint correctAnswersCount { get; set; }
        public uint wrongAnswersCount { get; set; }
        public uint averageAnswersTime { get; set; }
    };
    public struct GetGameResultsResponse
    {
        public uint status { get; set; }
        public List<PlayerResult> results { get; set; }
    }
}