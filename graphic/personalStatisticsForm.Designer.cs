using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class personalStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pieChartStats = new LiveCharts.WinForms.PieChart();
            btnBack = new Button();
            label2 = new Label();
            lblUsername = new Label();
            lblWins = new Label();
            lblLosses = new Label();
            lblAccuracy = new Label();
            SuspendLayout();
            // 
            // pieChartStats
            // 
            pieChartStats.Location = new Point(494, 160);
            pieChartStats.Name = "pieChartStats";
            pieChartStats.Size = new Size(420, 350);
            pieChartStats.TabIndex = 8;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.MenuBar;
            btnBack.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.MediumPurple;
            btnBack.Location = new Point(100, 630);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 53);
            btnBack.TabIndex = 4;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = Color.MediumPurple;
            label2.Location = new Point(300, 40);
            label2.Name = "label2";
            label2.Size = new Size(452, 69);
            label2.TabIndex = 6;
            label2.Text = "Personal Statistics";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold);
            lblUsername.ForeColor = SystemColors.Control;
            lblUsername.Location = new Point(100, 160);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(232, 48);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Username: {}";
            // 
            // lblWins
            // 
            lblWins.AutoSize = true;
            lblWins.Font = new Font("Segoe UI Emoji", 16F);
            lblWins.ForeColor = Color.LightGreen;
            lblWins.Location = new Point(100, 240);
            lblWins.Name = "lblWins";
            lblWins.Size = new Size(202, 43);
            lblWins.TabIndex = 9;
            lblWins.Text = "Total Wins: 0";
            // 
            // lblLosses
            // 
            lblLosses.AutoSize = true;
            lblLosses.Font = new Font("Segoe UI Emoji", 16F);
            lblLosses.ForeColor = Color.Tomato;
            lblLosses.Location = new Point(100, 310);
            lblLosses.Name = "lblLosses";
            lblLosses.Size = new Size(225, 43);
            lblLosses.TabIndex = 10;
            lblLosses.Text = "Total Losses: 0";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold);
            lblAccuracy.ForeColor = Color.Gold;
            lblAccuracy.Location = new Point(100, 380);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(218, 43);
            lblAccuracy.TabIndex = 11;
            lblAccuracy.Text = "Win Rate: 0%";
            // 
            // personalStatisticsForm
            // 
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(978, 744);
            Controls.Add(lblAccuracy);
            Controls.Add(lblLosses);
            Controls.Add(lblWins);
            Controls.Add(pieChartStats);
            Controls.Add(lblUsername);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "personalStatisticsForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private LiveCharts.WinForms.PieChart pieChartStats;
        private Button btnBack;
        private Label label2;
        private Label lblUsername;
        private Label lblWins;
        private Label lblLosses;
        private Label lblAccuracy;
    }
}