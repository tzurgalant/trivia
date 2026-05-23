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
        }

        private void SetupChart()
        {
            try
            {
                int wins = 8;
                int losses = 4;
                string currentUsername = "GamerPro";

                int totalGames = wins + losses;
                double winRate = totalGames > 0 ? Math.Round(((double)wins / totalGames) * 100, 1) : 0;

                lblUsername.Text = $"Username: {currentUsername}";
                lblWins.Text = $"Total Wins: {wins}";
                lblLosses.Text = $"Total Losses: {losses}";
                lblAccuracy.Text = $"Win Rate: {winRate}%";

                if (pieChartStats != null)
                {
                    pieChartStats.Series = new SeriesCollection
                    {
                        new PieSeries
                        {
                            Title = "Wins",
                            Values = new ChartValues<int> { wins },
                            DataLabels = true,
                            Fill = System.Windows.Media.Brushes.MediumPurple
                        },
                        new PieSeries
                        {
                            Title = "Losses",
                            Values = new ChartValues<int> { losses },
                            DataLabels = true,
                            Fill = System.Windows.Media.Brushes.Tomato
                        }
                    };

                    pieChartStats.LegendLocation = LegendLocation.Bottom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting up chart: " + ex.Message);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}