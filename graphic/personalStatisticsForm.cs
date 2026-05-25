using System;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace clientGraphic
{
    public partial class personalStatisticsForm : Form
    {
        public personalStatisticsForm()
        {
            InitializeComponent();
            SetupChart();

            //nught/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void SetupChart()
        {
            try
            {
                GetPersonalStatsResponse res = Communicator.SendAndReceive<GetPersonalStatsResponse>(106, new GetPersonalStatsRequest());

                if (res.status != 1 || res.statistics == null || res.statistics.Count < 5)
                {
                    MessageBox.Show("Failed to load statistics from server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                double avgTime = double.Parse(res.statistics[0]);
                int correctAnswers = int.Parse(res.statistics[1]);
                int totalAnswers = int.Parse(res.statistics[2]);
                int gamesPlayed = int.Parse(res.statistics[3]);
                int score = int.Parse(res.statistics[4]);

                int wrongAnswers = totalAnswers - correctAnswers;

                double winRate = totalAnswers > 0 ? Math.Round(((double)correctAnswers / totalAnswers) * 100, 1) : 0;

                lblUsername.Text = $"Username: {Helper._currentUser.Name}";
                lblWins.Text = $"Total Games: {gamesPlayed} (Score: {score})";
                lblLosses.Text = $"Correct: {correctAnswers} / Total: {totalAnswers}";
                lblAccuracy.Text = $"Accuracy Rate: {winRate}% | Avg Time: {avgTime}s";

                if (pieChartStats != null)
                {
                    pieChartStats.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Correct",
                    Values = new ChartValues<int> { correctAnswers },
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.MediumPurple
                },
                new PieSeries
                {
                    Title = "Incorrect",
                    Values = new ChartValues<int> { wrongAnswers },
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Tomato
                }
            };

                    pieChartStats.LegendLocation = LegendLocation.Bottom;
                    pieChartStats.ForeColor = MenuForm.IsDarkMode ? Color.White : Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                lblUsername.ForeColor = SystemColors.Control;

                lblWins.ForeColor = Color.LightGreen;
                lblLosses.ForeColor = Color.Tomato;
                lblAccuracy.ForeColor = Color.Gold;

                if (pieChartStats != null)
                {
                    pieChartStats.ForeColor = Color.White;
                }
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                lblUsername.ForeColor = Color.Black;

                lblWins.ForeColor = Color.DarkGreen;
                lblLosses.ForeColor = Color.Firebrick;
                lblAccuracy.ForeColor = Color.DarkGoldenrod;

                if (pieChartStats != null)
                {
                    pieChartStats.ForeColor = Color.Black;
                }
            }
        }
    }

    public struct GetPersonalStatsRequest
    {
    }

    public struct GetPersonalStatsResponse
    {
        public uint status { get; set; }
        public List<string> statistics { get; set; }
    }
}