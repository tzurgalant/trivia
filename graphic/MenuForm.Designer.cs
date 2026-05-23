using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class MenuForm
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
            panel1 = new Panel();
            btnJoinRoom = new Button();
            btnCreateRoom = new Button();
            btnStatistics = new Button();
            btnHighScores = new Button();
            btnLogin = new Button();
            btnSignUp = new Button();
            btnExit = new Button();
            label1 = new Label();
            label2 = new Label();
            lblNotLoggedMessage = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 45, 45);
            panel1.Controls.Add(btnJoinRoom);
            panel1.Controls.Add(btnCreateRoom);
            panel1.Controls.Add(btnStatistics);
            panel1.Controls.Add(btnHighScores);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnSignUp);
            panel1.Controls.Add(btnExit);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(220, 744);
            panel1.TabIndex = 0;
            // 
            // btnJoinRoom
            // 
            btnJoinRoom.AccessibleName = "btnJoinRoom";
            btnJoinRoom.Cursor = Cursors.Hand;
            btnJoinRoom.FlatAppearance.BorderSize = 0;
            btnJoinRoom.FlatStyle = FlatStyle.Flat;
            btnJoinRoom.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnJoinRoom.ForeColor = Color.White;
            btnJoinRoom.Location = new Point(0, 100);
            btnJoinRoom.Name = "btnJoinRoom";
            btnJoinRoom.Size = new Size(220, 55);
            btnJoinRoom.TabIndex = 1;
            btnJoinRoom.Text = "Join Room";
            btnJoinRoom.UseVisualStyleBackColor = true;
            btnJoinRoom.Click += btnJoinRoom_Click;
            // 
            // btnCreateRoom
            // 
            btnCreateRoom.AccessibleName = "btnCreateRoom";
            btnCreateRoom.Cursor = Cursors.Hand;
            btnCreateRoom.FlatAppearance.BorderSize = 0;
            btnCreateRoom.FlatStyle = FlatStyle.Flat;
            btnCreateRoom.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnCreateRoom.ForeColor = Color.White;
            btnCreateRoom.Location = new Point(0, 165);
            btnCreateRoom.Name = "btnCreateRoom";
            btnCreateRoom.Size = new Size(220, 55);
            btnCreateRoom.TabIndex = 2;
            btnCreateRoom.Text = "Create Room";
            btnCreateRoom.UseVisualStyleBackColor = true;
            btnCreateRoom.Click += btnCreateRoom_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.AccessibleName = "btnStatistics";
            btnStatistics.Cursor = Cursors.Hand;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnStatistics.ForeColor = Color.White;
            btnStatistics.Location = new Point(0, 230);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(220, 55);
            btnStatistics.TabIndex = 3;
            btnStatistics.Text = "My Statistics";
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnHighScores
            // 
            btnHighScores.AccessibleName = "btnHighScores";
            btnHighScores.Cursor = Cursors.Hand;
            btnHighScores.FlatAppearance.BorderSize = 0;
            btnHighScores.FlatStyle = FlatStyle.Flat;
            btnHighScores.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnHighScores.ForeColor = Color.Gold;
            btnHighScores.Location = new Point(0, 295);
            btnHighScores.Name = "btnHighScores";
            btnHighScores.Size = new Size(220, 55);
            btnHighScores.TabIndex = 4;
            btnHighScores.Text = "🏆 High Scores";
            btnHighScores.UseVisualStyleBackColor = true;
            btnHighScores.Click += btnHighScores_Click;
            // 
            // btnLogin
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.MediumPurple;
            btnLogin.Location = new Point(0, 400);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(220, 55);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.AccessibleName = "btnSignUp";
            btnSignUp.Cursor = Cursors.Hand;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnSignUp.ForeColor = Color.MediumPurple;
            btnSignUp.Location = new Point(0, 465);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(220, 55);
            btnSignUp.TabIndex = 6;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // btnExit
            // 
            btnExit.AccessibleName = "btnExit";
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.Tomato;
            btnExit.Location = new Point(0, 670);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(220, 55);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 28F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = Color.MediumPurple;
            label1.Location = new Point(440, 40);
            label1.Name = "label1";
            label1.Size = new Size(317, 74);
            label1.TabIndex = 8;
            label1.Text = "Main Menu";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AccessibleName = "lblWelcome";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 14F);
            label2.ForeColor = SystemColors.ControlLight;
            label2.Location = new Point(472, 137);
            label2.Name = "label2";
            label2.Size = new Size(231, 37);
            label2.TabIndex = 9;
            label2.Text = "Welcome, Player!";
            // 
            // lblNotLoggedMessage
            // 
            lblNotLoggedMessage.AccessibleName = "lblNotLoggedMessage";
            lblNotLoggedMessage.AutoSize = true;
            lblNotLoggedMessage.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            lblNotLoggedMessage.ForeColor = Color.Tomato;
            lblNotLoggedMessage.Location = new Point(250, 680);
            lblNotLoggedMessage.Name = "lblNotLoggedMessage";
            lblNotLoggedMessage.Size = new Size(340, 32);
            lblNotLoggedMessage.TabIndex = 10;
            lblNotLoggedMessage.Text = "You must be logged in first!";
            lblNotLoggedMessage.Visible = false;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(35, 35, 35);
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
        private Button btnHighScores;
        private Button btnExit;
        private Button btnLogin;
        private Button btnSignUp;
        private Label lblNotLoggedMessage;
    }
}