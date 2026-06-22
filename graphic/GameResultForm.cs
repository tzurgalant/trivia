using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class GameResultForm : Form
    {
        private bool _isBackButtonClicked = false;
        private System.Windows.Forms.Timer _refreshTimer;
        public GameResultForm()
        {
            InitializeComponent();
            InitGrid();

            InitRefreshTimer();

            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            //Night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => {
                MenuForm.ThemeChanged -= ApplyCurrentTheme;
                StopTimer();
            };
            ApplyCurrentTheme();
        }

        private void InitRefreshTimer()
        {
            _refreshTimer = new System.Windows.Forms.Timer();
            _refreshTimer.Interval = 1000; 
            _refreshTimer.Tick += (s, e) => LoadGameResult();
            _refreshTimer.Start(); 

            lblWinner.Text = "Waiting for other players to finish...";
        }

        private void StopTimer()
        {
            if (_refreshTimer != null)
            {
                _refreshTimer.Stop();
                _refreshTimer.Dispose();
                _refreshTimer = null;
            }
        }

        private void LoadGameResult()
        {
            try
            {
                GetGameResultsResponse res = Communicator.SendAndReceive<GetGameResultsResponse>((Byte)CodeR.GetGameResultsResponseCmd);

                if (res.status == 0)
                {
                    lblWinner.Text = "Waiting for other players to finish...";
                    return; 
                }

                StopTimer();

                if (res.results == null || res.results.Count == 0)
                {
                    MessageBox.Show("No results available.");
                    lblWinner.Text = "No results available";
                    return;
                }

                var winner = res.results
                    .OrderByDescending(p => p.correctAnswersCount) 
                    .ThenBy(p => p.averageAnswersTime)             
                    .First();

                lblWinner.Text = $"👑 Winner: {winner.userName} 👑";

                lvResults.Items.Clear();
                foreach (var player in res.results.OrderByDescending(p => p.correctAnswersCount).ThenBy(p => p.averageAnswersTime))
                {
                    var item = new ListViewItem(player.userName);

                    item.SubItems.Add(player.correctAnswersCount.ToString());
                    item.SubItems.Add(player.wrongAnswersCount.ToString());

                    item.SubItems.Add($"{player.averageAnswersTime}s");


                    lvResults.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                StopTimer(); 
                MessageBox.Show("Error loading GameResult: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvResults.Items.Clear();
                lblWinner.Text = "Error loading results";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Communicator.SendAndReceive<LeaveGameResponse>((Byte)CodeR.LeaveGameCmd);
            _isBackButtonClicked = true;
            StopTimer();
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

            lvResults.Columns.Add("Username", 195);
            lvResults.Columns.Add("Correct Answers", 195);
            lvResults.Columns.Add("Wrong Answers", 195);
            lvResults.Columns.Add("Avgerage Time", 195);

            lvResults.View = View.Details;
            lvResults.FullRowSelect = true;
            lvResults.GridLines = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_isBackButtonClicked)
            {
                StopTimer();
                Application.Exit();
            }
            base.OnFormClosing(e);
        }

        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblWinner_Click(object sender, EventArgs e) { }
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