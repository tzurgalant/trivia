using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class HighScoresForm
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
            this.lblTitle = new Label();
            this.lvHighScores = new ListView();
            this.btnBack = new Button();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold | FontStyle.Italic);
            this.lblTitle.ForeColor = Color.Gold;
            this.lblTitle.Location = new Point(310, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(350, 58);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏆 Top 5 Players";

            // 
            // lvHighScores
            // 
            this.lvHighScores.BackColor = Color.FromArgb(45, 45, 45);
            this.lvHighScores.BorderStyle = BorderStyle.None;
            this.lvHighScores.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            this.lvHighScores.ForeColor = Color.White;
            this.lvHighScores.FullRowSelect = true;
            this.lvHighScores.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.lvHighScores.HideSelection = false;
            this.lvHighScores.Location = new Point(150, 150);
            this.lvHighScores.Name = "lvHighScores";
            this.lvHighScores.Size = new Size(678, 420);
            this.lvHighScores.TabIndex = 1;
            this.lvHighScores.UseCompatibleStateImageBehavior = false;
            this.lvHighScores.View = View.Details;

            // 
            // btnBack
            // 
            this.btnBack.BackColor = SystemColors.MenuBar;
            this.btnBack.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.MediumPurple;
            this.btnBack.Location = new Point(100, 630);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(250, 53);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Return To Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // 
            // HighScoresForm
            // 
            this.BackColor = Color.FromArgb(35, 35, 35);
            this.ClientSize = new Size(978, 744);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lvHighScores);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "HighScoresForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private ListView lvHighScores;
        private Button btnBack;
    }
}