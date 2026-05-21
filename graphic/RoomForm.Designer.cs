namespace clientGraphic
{
    partial class RoomForm
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
            panel2 = new Panel();
            pnlRoomDetails = new Panel();
            lblShowPlayers = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            PlayersList = new ListBox();
            lblShowAdmin = new Label();
            label5 = new Label();
            label4 = new Label();
            button4 = new Button();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            btnStartRoom = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            pnlRoomDetails.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 75, 64);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(pnlRoomDetails);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(btnStartRoom);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 744);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
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
            pnlRoomDetails.Paint += pnlRoomDetails_Paint;
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
            PlayersList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
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
            // button4
            // 
            button4.AccessibleName = "btnExit";
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Symbol", 12F);
            button4.ForeColor = SystemColors.Control;
            button4.Location = new Point(-3, 694);
            button4.Name = "button4";
            button4.Size = new Size(200, 50);
            button4.TabIndex = 6;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
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
            // textBox3
            // 
            textBox3.Location = new Point(26, 260);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(26, 184);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 9;
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
            btnStartRoom.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 113);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 8;
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
            // RoomForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(978, 744);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "RoomForm";
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
        private Button button4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
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
    }
}