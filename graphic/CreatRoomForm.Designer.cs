namespace clientGraphic
{
    partial class CreatRoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnReturn = new Button();
            panel2 = new Panel();
            pnlRoomDetails = new Panel();
            lblShowPlayers = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            PlayersList = new ListBox();
            lblShowAdmin = new Label();
            label5 = new Label();
            label4 = new Label();
            btnExit = new Button();
            label3 = new Label();
            txtNumOfPlayers = new TextBox();
            txtTimeForQustion = new TextBox();
            btnStartRoom = new Button();
            txtRoomName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            pnlRoomDetails.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 75, 64);
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlRoomDetails);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtNumOfPlayers);
            panel1.Controls.Add(txtTimeForQustion);
            panel1.Controls.Add(btnStartRoom);
            panel1.Controls.Add(txtRoomName);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 744);
            panel1.TabIndex = 0;
            // 
            // btnReturn
            // 
            btnReturn.AccessibleName = "btnReturnToMenu";
            btnReturn.BackgroundImageLayout = ImageLayout.None;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI Symbol", 12F);
            btnReturn.ForeColor = SystemColors.Control;
            btnReturn.Location = new Point(3, 651);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(200, 44);
            btnReturn.TabIndex = 14;
            btnReturn.Text = "Return To Menu";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // panel2
            // 
            panel2.AccessibleName = "SplitButtensFromtext";
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(0, 298);
            panel2.Name = "panel2";
            panel2.Size = new Size(202, 10);
            panel2.TabIndex = 8;
            // 
            // pnlRoomDetails
            // 
            pnlRoomDetails.AccessibleName = "pnlRoomDetails";
            pnlRoomDetails.Controls.Add(lblShowPlayers);
            pnlRoomDetails.Controls.Add(panel4);
            pnlRoomDetails.Controls.Add(panel3);
            pnlRoomDetails.Controls.Add(PlayersList);
            pnlRoomDetails.Controls.Add(lblShowAdmin);
            pnlRoomDetails.Location = new Point(3, 370);
            pnlRoomDetails.Name = "pnlRoomDetails";
            pnlRoomDetails.Size = new Size(197, 275);
            pnlRoomDetails.TabIndex = 8;
            pnlRoomDetails.Visible = false;
            // 
            // lblShowPlayers
            // 
            lblShowPlayers.AutoSize = true;
            lblShowPlayers.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowPlayers.ForeColor = SystemColors.ButtonFace;
            lblShowPlayers.Location = new Point(4, 68);
            lblShowPlayers.Name = "lblShowPlayers";
            lblShowPlayers.Size = new Size(102, 25);
            lblShowPlayers.TabIndex = 16;
            lblShowPlayers.Text = "Players List:";
            // 
            // panel4
            // 
            panel4.AccessibleName = "SplitButtensFromtext";
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(-6, 263);
            panel4.Name = "panel4";
            panel4.Size = new Size(201, 10);
            panel4.TabIndex = 15;
            // 
            // panel3
            // 
            panel3.AccessibleName = "SplitButtensFromtext";
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(-14, 11);
            panel3.Name = "panel3";
            panel3.Size = new Size(214, 10);
            panel3.TabIndex = 14;
            // 
            // PlayersList
            // 
            PlayersList.BackColor = Color.White;
            PlayersList.FormattingEnabled = true;
            PlayersList.ItemHeight = 25;
            PlayersList.Location = new Point(4, 96);
            PlayersList.Name = "PlayersList";
            PlayersList.Size = new Size(191, 129);
            PlayersList.TabIndex = 3;
            // 
            // lblShowAdmin
            // 
            lblShowAdmin.AutoSize = true;
            lblShowAdmin.ForeColor = SystemColors.ButtonFace;
            lblShowAdmin.Location = new Point(3, 33);
            lblShowAdmin.Name = "lblShowAdmin";
            lblShowAdmin.Size = new Size(121, 25);
            lblShowAdmin.TabIndex = 1;
            lblShowAdmin.Text = "Admin Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(26, 232);
            label5.Name = "label5";
            label5.Size = new Size(133, 25);
            label5.TabIndex = 13;
            label5.Text = "Num of Players";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(26, 157);
            label4.Name = "label4";
            label4.Size = new Size(149, 25);
            label4.TabIndex = 12;
            label4.Text = "Time For Qustion";
            // 
            // btnExit
            // 
            btnExit.AccessibleName = "btnExit";
            btnExit.BackgroundImageLayout = ImageLayout.None;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Symbol", 12F);
            btnExit.ForeColor = SystemColors.Control;
            btnExit.Location = new Point(-3, 694);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 50);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(26, 85);
            label3.Name = "label3";
            label3.Size = new Size(112, 25);
            label3.TabIndex = 11;
            label3.Text = "Room Name";
            // 
            // txtNumOfPlayers
            // 
            txtNumOfPlayers.AccessibleName = "txtNumOfPlayers";
            txtNumOfPlayers.Location = new Point(26, 260);
            txtNumOfPlayers.Name = "txtNumOfPlayers";
            txtNumOfPlayers.Size = new Size(150, 31);
            txtNumOfPlayers.TabIndex = 10;
            // 
            // txtTimeForQustion
            // 
            txtTimeForQustion.AccessibleName = "txtTimeForQustion";
            txtTimeForQustion.Location = new Point(26, 184);
            txtTimeForQustion.Name = "txtTimeForQustion";
            txtTimeForQustion.Size = new Size(150, 31);
            txtTimeForQustion.TabIndex = 9;
            // 
            // btnStartRoom
            // 
            btnStartRoom.AccessibleName = "btnCreateRoom";
            btnStartRoom.BackgroundImageLayout = ImageLayout.None;
            btnStartRoom.Cursor = Cursors.Hand;
            btnStartRoom.FlatAppearance.BorderSize = 0;
            btnStartRoom.FlatStyle = FlatStyle.Flat;
            btnStartRoom.Font = new Font("Segoe UI Symbol", 12F);
            btnStartRoom.ForeColor = SystemColors.Control;
            btnStartRoom.Location = new Point(-3, 314);
            btnStartRoom.Name = "btnStartRoom";
            btnStartRoom.Size = new Size(200, 50);
            btnStartRoom.TabIndex = 4;
            btnStartRoom.Text = "Start Room";
            btnStartRoom.UseVisualStyleBackColor = true;
            btnStartRoom.Click += btnStartRoom_Click;
            // 
            // txtRoomName
            // 
            txtRoomName.AccessibleName = "txtRoomName";
            txtRoomName.Location = new Point(26, 113);
            txtRoomName.Name = "txtRoomName";
            txtRoomName.Size = new Size(150, 31);
            txtRoomName.TabIndex = 8;
            // 
            // label2
            // 
            label2.AccessibleName = "lblWelcome";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(626, 74);
            label2.Name = "label2";
            label2.Size = new Size(215, 38);
            label2.TabIndex = 7;
            label2.Text = "Welcom, Player!";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(399, 9);
            label1.Name = "label1";
            label1.Size = new Size(315, 65);
            label1.TabIndex = 6;
            label1.Text = "Create Room";
            // 
            // CreatRoomForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(978, 744);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CreatRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RoomForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlRoomDetails.ResumeLayout(false);
            pnlRoomDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnStartRoom;
        private Button btnExit;
        private TextBox txtTimeForQustion;
        private TextBox txtRoomName;
        private Label label2;
        private Label label1;
        private TextBox txtNumOfPlayers;
        private Label label5;
        private Label label4;
        private Label label3;
        private Panel panel2;
        private Panel pnlRoomDetails;
        private Label lblShowAdmin;
        private ListBox PlayersList;
        private Panel panel3;
        private Panel panel4;
        private Label lblShowPlayers;
        private Button btnReturn;
    }
}