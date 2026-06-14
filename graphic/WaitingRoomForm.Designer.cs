using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class WaitingRoomForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnStartGame = new Button();
            btnBack = new Button();
            label1 = new Label();
            PlayersList = new ListBox();
            lblShowPlayers = new Label();
            SuspendLayout();
            //
            // btnStartGame
            //
            btnStartGame.Cursor = Cursors.Hand;
            btnStartGame.FlatAppearance.BorderSize = 0;
            btnStartGame.FlatStyle = FlatStyle.Flat;
            btnStartGame.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnStartGame.ForeColor = Color.MediumPurple;
            btnStartGame.Location = new Point(345, 445);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(220, 50);
            btnStartGame.TabIndex = 0;
            btnStartGame.Text = "START GAME";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Visible = false;
            btnStartGame.Click += btnStartGame_Click;
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
            btnBack.TabIndex = 1;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold);
            label1.ForeColor = Color.MediumPurple;
            label1.Location = new Point(340, 40);
            label1.Name = "label1";
            label1.Size = new Size(337, 69);
            label1.TabIndex = 2;
            label1.Text = "Waiting Room";
            label1.Click += label1_Click;
            //
            // PlayersList
            //
            PlayersList.BackColor = Color.FromArgb(45, 45, 45);
            PlayersList.BorderStyle = BorderStyle.FixedSingle;
            PlayersList.Font = new Font("Segoe UI", 10F);
            PlayersList.ForeColor = Color.White;
            PlayersList.FormattingEnabled = true;
            PlayersList.ItemHeight = 28;
            PlayersList.Location = new Point(345, 210);
            PlayersList.Name = "PlayersList";
            PlayersList.Size = new Size(220, 200);
            PlayersList.TabIndex = 4;
            //
            // lblShowPlayers
            //
            lblShowPlayers.AutoSize = true;
            lblShowPlayers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShowPlayers.ForeColor = Color.White;
            lblShowPlayers.Location = new Point(345, 175);
            lblShowPlayers.Name = "lblShowPlayers";
            lblShowPlayers.Size = new Size(124, 28);
            lblShowPlayers.TabIndex = 5;
            lblShowPlayers.Text = "Players List:";
            //
            // WaitingRoomForm
            //
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(978, 744);
            Controls.Add(lblShowPlayers);
            Controls.Add(PlayersList);
            Controls.Add(label1);
            Controls.Add(btnStartGame);
            Controls.Add(btnBack);
            FormBorderStyle = FormBorderStyle.None;
            Name = "WaitingRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WaitingRoomForm";
            Load += WaitingRoomForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartGame;
        private Button btnBack;
        private Label label1;
        private ListBox PlayersList;
        private Label lblShowPlayers;
    }
}