using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class GameResultForm : Form
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
            lblWinner = new Label();
            lvResults = new ListView();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(290, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(443, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🏆 Game Results";
            // 
            // lblWinner
            // 
            lblWinner.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWinner.ForeColor = Color.LightGreen;
            lblWinner.Location = new Point(150, 110);
            lblWinner.Name = "lblWinner";
            lblWinner.Size = new Size(678, 40);
            lblWinner.TabIndex = 1;
            lblWinner.Text = "Winner: -";
            lblWinner.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lvResults
            // 
            lvResults.BackColor = Color.FromArgb(45, 45, 45);
            lvResults.BorderStyle = BorderStyle.None;
            lvResults.Font = new Font("Segoe UI", 12F);
            lvResults.ForeColor = Color.White;
            lvResults.FullRowSelect = true;
            lvResults.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvResults.Location = new Point(100, 180);
            lvResults.Name = "lvResults";
            lvResults.Size = new Size(780, 360);
            lvResults.TabIndex = 2;
            lvResults.UseCompatibleStateImageBehavior = false;
            lvResults.View = View.Details;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.Tomato;
            btnBack.Location = new Point(120, 620);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 50);
            btnBack.TabIndex = 3;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // GameResultForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(978, 744);
            Controls.Add(btnBack);
            Controls.Add(lvResults);
            Controls.Add(lblWinner);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GameResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblWinner;
        private ListView lvResults;
        private Button btnBack;
    }
}