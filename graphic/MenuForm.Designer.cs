namespace clientGraphic
{
    partial class MenuForm
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
            btnLogin = new Button();
            btnSignUp = new Button();
            btnJoinRoom = new Button();
            btnCreateRoom = new Button();
            btnStatistics = new Button();
            btnExit = new Button();
            label1 = new Label();
            label2 = new Label();
            lblNotLoggedMessage = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 75, 64);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnSignUp);
            panel1.Controls.Add(btnJoinRoom);
            panel1.Controls.Add(btnCreateRoom);
            panel1.Controls.Add(btnStatistics);
            panel1.Controls.Add(btnExit);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 744);
            panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.BackgroundImageLayout = ImageLayout.None;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Symbol", 12F);
            btnLogin.ForeColor = SystemColors.Control;
            btnLogin.Location = new Point(-3, 281);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 50);
            btnLogin.TabIndex = 13;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleName = "btnSignUp";
            btnSignUp.BackgroundImageLayout = ImageLayout.None;
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Segoe UI Symbol", 12F);
            btnSignUp.ForeColor = SystemColors.Control;
            btnSignUp.Location = new Point(0, 337);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(200, 50);
            btnSignUp.TabIndex = 12;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.AccessibleName = "btnJoinRoom";
            btnJoinRoom.BackgroundImageLayout = ImageLayout.None;
            btnJoinRoom.Cursor = Cursors.Hand;
            btnJoinRoom.FlatAppearance.BorderSize = 0;
            btnJoinRoom.FlatStyle = FlatStyle.Flat;
            btnJoinRoom.Font = new Font("Segoe UI Symbol", 12F);
            btnJoinRoom.ForeColor = SystemColors.Control;
            btnJoinRoom.Location = new Point(-3, 113);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(200, 50);
            btnJoinRoom.TabIndex = 11;
            btnJoinRoom.Text = "Join Room";
            btnJoinRoom.UseVisualStyleBackColor = true;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.AccessibleName = "btnCreateRoom";
            btnCreateRoom.BackgroundImageLayout = ImageLayout.None;
            btnCreateRoom.Cursor = Cursors.Hand;
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Font = new Font("Segoe UI Symbol", 12F);
            btnCreateRoom.ForeColor = SystemColors.Control;
            btnCreateRoom.Location = new Point(-3, 169);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(200, 50);
            btnCreateRoom.TabIndex = 8;
            btnCreateRoom.Text = "Create Room";
            btnCreateRoom.UseVisualStyleBackColor = true;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.AccessibleName = "btnStatistics";
            btnStatistics.BackgroundImageLayout = ImageLayout.None;
            btnStatistics.Cursor = Cursors.Hand;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI Symbol", 12F);
            btnStatistics.ForeColor = SystemColors.Control;
            btnStatistics.Location = new Point(-3, 225);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(200, 50);
            btnStatistics.TabIndex = 9;
            btnStatistics.Text = "Statistics";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
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
            btnExit.Location = new Point(-3, 691);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 50);
            btnExit.TabIndex = 10;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(354, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 65);
            label1.TabIndex = 4;
            label1.Text = "Main Menu";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AccessibleName = "lblWelcome";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(380, 125);
            label2.Name = "label2";
            label2.Size = new Size(215, 38);
            label2.TabIndex = 5;
            label2.Text = "Welcom, Player!";
            // 
            // lblNotLoggedMessage
            // 
            lblNotLoggedMessage.AccessibleName = "lblNotLoggedMessage";
            lblNotLoggedMessage.AutoSize = true;
            lblNotLoggedMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNotLoggedMessage.ForeColor = Color.Firebrick;
            lblNotLoggedMessage.Location = new Point(206, 700);
            lblNotLoggedMessage.Name = "lblNotLoggedMessage";
            lblNotLoggedMessage.Size = new Size(337, 32);
            lblNotLoggedMessage.TabIndex = 6;
            lblNotLoggedMessage.Text = "Need to be logged to do that!";
            lblNotLoggedMessage.Visible = false;
            // 
            // MenuForm
            // 
            AccessibleName = "";
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(978, 744);
            Controls.Add(lblNotLoggedMessage);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            Load += MenuForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Button btnJoinRoom;
        private Button btnCreateRoom;
        private Button btnStatistics;
        private Button btnExit;
        private Button btnLogin;
        private Button btnSignUp;
        private Label lblNotLoggedMessage;
    }
}