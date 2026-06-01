using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class CreatRoomForm
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
            txtQuestionCount = new TextBox();
            label6 = new Label();
            btnBack = new Button();
            pnlRoomDetails = new Panel();
            lblShowPlayers = new Label();
            PlayersList = new ListBox();
            lblShowAdmin = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtNumOfPlayers = new TextBox();
            txtTimeForQustion = new TextBox();
            btnStartRoom = new Button();
            txtRoomName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlRoomDetails.SuspendLayout();
            SuspendLayout();
            // 
            // txtQuestionCount
            // 
            txtQuestionCount.BackColor = Color.FromArgb(45, 45, 45);
            txtQuestionCount.BorderStyle = BorderStyle.FixedSingle;
            txtQuestionCount.Font = new Font("Segoe UI", 11F);
            txtQuestionCount.ForeColor = Color.White;
            txtQuestionCount.Location = new Point(345, 320);
            txtQuestionCount.Name = "txtQuestionCount";
            txtQuestionCount.Size = new Size(220, 37);
            txtQuestionCount.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(135, 322);
            label6.Name = "label6";
            label6.Size = new Size(199, 30);
            label6.TabIndex = 15;
            label6.Text = "Num of Questions";
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
            btnBack.TabIndex = 14;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pnlRoomDetails
            // 
            pnlRoomDetails.Controls.Add(lblShowPlayers);
            pnlRoomDetails.Controls.Add(PlayersList);
            pnlRoomDetails.Controls.Add(lblShowAdmin);
            pnlRoomDetails.Location = new Point(710, 210);
            pnlRoomDetails.Name = "pnlRoomDetails";
            pnlRoomDetails.Size = new Size(240, 285);
            pnlRoomDetails.TabIndex = 8;
            pnlRoomDetails.Visible = false;
            // 
            // lblShowPlayers
            // 
            lblShowPlayers.AutoSize = true;
            lblShowPlayers.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShowPlayers.ForeColor = Color.White;
            lblShowPlayers.Location = new Point(3, 45);
            lblShowPlayers.Name = "lblShowPlayers";
            lblShowPlayers.Size = new Size(124, 28);
            lblShowPlayers.TabIndex = 16;
            lblShowPlayers.Text = "Players List:";
            // 
            // PlayersList
            // 
            PlayersList.BackColor = Color.FromArgb(45, 45, 45);
            PlayersList.BorderStyle = BorderStyle.FixedSingle;
            PlayersList.Font = new Font("Segoe UI", 10F);
            PlayersList.ForeColor = Color.White;
            PlayersList.FormattingEnabled = true;
            PlayersList.ItemHeight = 28;
            PlayersList.Location = new Point(3, 80);
            PlayersList.Name = "PlayersList";
            PlayersList.Size = new Size(230, 170);
            PlayersList.TabIndex = 3;
            PlayersList.SelectedIndexChanged += PlayersList_SelectedIndexChanged;
            // 
            // lblShowAdmin
            // 
            lblShowAdmin.AutoSize = true;
            lblShowAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShowAdmin.ForeColor = Color.White;
            lblShowAdmin.Location = new Point(3, 5);
            lblShowAdmin.Name = "lblShowAdmin";
            lblShowAdmin.Size = new Size(141, 28);
            lblShowAdmin.TabIndex = 1;
            lblShowAdmin.Text = "Admin Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(135, 377);
            label5.Name = "label5";
            label5.Size = new Size(166, 30);
            label5.TabIndex = 13;
            label5.Text = "Max of Players";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(135, 267);
            label4.Name = "label4";
            label4.Size = new Size(202, 30);
            label4.TabIndex = 12;
            label4.Text = "Time For Question";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(135, 212);
            label3.Name = "label3";
            label3.Size = new Size(139, 30);
            label3.TabIndex = 11;
            label3.Text = "Room Name";
            // 
            // txtNumOfPlayers
            // 
            txtNumOfPlayers.BackColor = Color.FromArgb(45, 45, 45);
            txtNumOfPlayers.BorderStyle = BorderStyle.FixedSingle;
            txtNumOfPlayers.Font = new Font("Segoe UI", 11F);
            txtNumOfPlayers.ForeColor = Color.White;
            txtNumOfPlayers.Location = new Point(345, 375);
            txtNumOfPlayers.Name = "txtNumOfPlayers";
            txtNumOfPlayers.Size = new Size(220, 37);
            txtNumOfPlayers.TabIndex = 10;
            // 
            // txtTimeForQustion
            // 
            txtTimeForQustion.BackColor = Color.FromArgb(45, 45, 45);
            txtTimeForQustion.BorderStyle = BorderStyle.FixedSingle;
            txtTimeForQustion.Font = new Font("Segoe UI", 11F);
            txtTimeForQustion.ForeColor = Color.White;
            txtTimeForQustion.Location = new Point(345, 265);
            txtTimeForQustion.Name = "txtTimeForQustion";
            txtTimeForQustion.Size = new Size(220, 37);
            txtTimeForQustion.TabIndex = 9;
            // 
            // btnStartRoom
            // 
            btnStartRoom.Cursor = Cursors.Hand;
            btnStartRoom.FlatAppearance.BorderSize = 0;
            btnStartRoom.FlatStyle = FlatStyle.Flat;
            btnStartRoom.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnStartRoom.ForeColor = Color.MediumPurple;
            btnStartRoom.Location = new Point(345, 445);
            btnStartRoom.Name = "btnStartRoom";
            btnStartRoom.Size = new Size(220, 50);
            btnStartRoom.TabIndex = 4;
            btnStartRoom.Text = "START ROOM";
            btnStartRoom.UseVisualStyleBackColor = true;
            btnStartRoom.Click += btnStartRoom_Click;
            // 
            // txtRoomName
            // 
            txtRoomName.BackColor = Color.FromArgb(45, 45, 45);
            txtRoomName.BorderStyle = BorderStyle.FixedSingle;
            txtRoomName.Font = new Font("Segoe UI", 11F);
            txtRoomName.ForeColor = Color.White;
            txtRoomName.Location = new Point(345, 210);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(220, 37);
            txtRoomName.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            label2.ForeColor = Color.DarkGray;
            label2.Location = new Point(345, 115);
            label2.Name = "label2";
            label2.Size = new Size(196, 32);
            label2.TabIndex = 7;
            label2.Text = "Welcome, Player!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold);
            label1.ForeColor = Color.MediumPurple;
            label1.Location = new Point(340, 40);
            label1.Name = "label1";
            label1.Size = new Size(337, 69);
            label1.TabIndex = 6;
            label1.Text = "Create Room";
            // 
            // CreatRoomForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(978, 744);
            Controls.Add(btnBack);
            Controls.Add(pnlRoomDetails);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(txtQuestionCount);
            Controls.Add(txtNumOfPlayers);
            Controls.Add(txtTimeForQustion);
            Controls.Add(btnStartRoom);
            Controls.Add(txtRoomName);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreatRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoomForm";
            pnlRoomDetails.ResumeLayout(false);
            pnlRoomDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartRoom;
        private TextBox txtTimeForQustion;
        private TextBox txtRoomName;
        private Label label2;
        private Label label1;
        private TextBox txtNumOfPlayers;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel pnlRoomDetails;
        private Label lblShowAdmin;
        private ListBox PlayersList;
        private Label lblShowPlayers;
        private Button btnBack;
        private TextBox txtQuestionCount;
        private Label label6;
    }
}