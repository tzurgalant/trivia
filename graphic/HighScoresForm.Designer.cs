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
            lblTitle = new Label();
            lvHighScores = new ListView();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(310, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(431, 69);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏆 Top 5 Players";
            // 
            // lvHighScores
            // 
            lvHighScores.BackColor = Color.FromArgb(45, 45, 45);
            lvHighScores.BorderStyle = BorderStyle.None;
            lvHighScores.Font = new Font("Segoe UI", 14F);
            lvHighScores.ForeColor = Color.White;
            lvHighScores.FullRowSelect = true;
            lvHighScores.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvHighScores.Location = new Point(150, 150);
            lvHighScores.Name = "lvHighScores";
            lvHighScores.Size = new Size(678, 420);
            lvHighScores.TabIndex = 1;
            lvHighScores.UseCompatibleStateImageBehavior = false;
            lvHighScores.View = View.Details;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.Tomato;
            btnBack.Location = new Point(133, 631);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 53);
            btnBack.TabIndex = 5;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // HighScoresForm
            // 
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(978, 744);
            Controls.Add(btnBack);
            Controls.Add(lvHighScores);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HighScoresForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private ListView lvHighScores;
        private Button btnBack;
    }
}