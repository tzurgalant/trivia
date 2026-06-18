using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class GameScreenForm
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
            lblQuestion = new Label();
            btnAnswer1 = new Button();
            btnAnswer2 = new Button();
            btnAnswer3 = new Button();
            btnAnswer4 = new Button();
            lblQuestionsLeft = new Label();
            lblTimer = new Label();
            btnLeaveGame = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gold;
            lblTitle.Location = new Point(59, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(368, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎮 Trivia Game";
            // 
            // lblQuestion
            // 
            lblQuestion.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblQuestion.ForeColor = Color.White;
            lblQuestion.Location = new Point(89, 100);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(800, 100);
            lblQuestion.TabIndex = 1;
            lblQuestion.Text = "Question appears here";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAnswer1
            // 
            btnAnswer1.Location = new Point(179, 274);
            btnAnswer1.Name = "btnAnswer1";
            btnAnswer1.Size = new Size(278, 65);
            btnAnswer1.TabIndex = 2;
            btnAnswer1.Tag = "1";
            btnAnswer1.Click += btnAnswer_Click;
            // 
            // btnAnswer2
            // 
            btnAnswer2.Location = new Point(543, 274);
            btnAnswer2.Name = "btnAnswer2";
            btnAnswer2.Size = new Size(278, 65);
            btnAnswer2.TabIndex = 3;
            btnAnswer2.Tag = "2";
            btnAnswer2.Click += btnAnswer_Click;
            // 
            // btnAnswer3
            // 
            btnAnswer3.Location = new Point(179, 390);
            btnAnswer3.Name = "btnAnswer3";
            btnAnswer3.Size = new Size(278, 65);
            btnAnswer3.TabIndex = 4;
            btnAnswer3.Tag = "3";
            btnAnswer3.Click += btnAnswer_Click;
            // 
            // btnAnswer4
            // 
            btnAnswer4.Location = new Point(543, 390);
            btnAnswer4.Name = "btnAnswer4";
            btnAnswer4.Size = new Size(278, 65);
            btnAnswer4.TabIndex = 5;
            btnAnswer4.Tag = "4";
            btnAnswer4.Click += btnAnswer_Click;
            // 
            // lblQuestionsLeft
            // 
            lblQuestionsLeft.AutoSize = true;
            lblQuestionsLeft.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblQuestionsLeft.ForeColor = Color.DeepSkyBlue;
            lblQuestionsLeft.Location = new Point(690, 57);
            lblQuestionsLeft.Name = "lblQuestionsLeft";
            lblQuestionsLeft.Size = new Size(255, 38);
            lblQuestionsLeft.TabIndex = 6;
            lblQuestionsLeft.Text = "Questions Left: 10";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold);
            lblTimer.ForeColor = Color.Orange;
            lblTimer.Location = new Point(490, 47);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(121, 48);
            lblTimer.TabIndex = 8;
            lblTimer.Text = "⏱ 15";
            // 
            // btnLeaveGame
            // 
            btnLeaveGame.Cursor = Cursors.Hand;
            btnLeaveGame.FlatAppearance.BorderSize = 0;
            btnLeaveGame.FlatStyle = FlatStyle.Flat;
            btnLeaveGame.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnLeaveGame.ForeColor = Color.Tomato;
            btnLeaveGame.Location = new Point(59, 592);
            btnLeaveGame.Name = "btnLeaveGame";
            btnLeaveGame.Size = new Size(220, 50);
            btnLeaveGame.TabIndex = 9;
            btnLeaveGame.Text = "Leave Game";
            btnLeaveGame.UseVisualStyleBackColor = false;
            btnLeaveGame.Click += btnLeaveGame_Click;
            // 
            // GameScreenForm
            // 
            BackColor = Color.FromArgb(35, 35, 35);
            ClientSize = new Size(1000, 720);
            Controls.Add(lblTitle);
            Controls.Add(lblQuestion);
            Controls.Add(btnAnswer1);
            Controls.Add(btnAnswer2);
            Controls.Add(btnAnswer3);
            Controls.Add(btnAnswer4);
            Controls.Add(lblQuestionsLeft);
            Controls.Add(lblTimer);
            Controls.Add(btnLeaveGame);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GameScreenForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupAnswerButton(Button button, int x, int y)
        {
            button.Cursor = Cursors.Hand;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.FromArgb(50, 50, 50);
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button.Location = new Point(x, y);
            button.Size = new Size(320, 80);
            button.Text = "Answer";
            button.UseVisualStyleBackColor = false;
        }

        private Label lblTitle;
        private Label lblQuestion;

        private Button btnAnswer1;
        private Button btnAnswer2;
        private Button btnAnswer3;
        private Button btnAnswer4;

        private Label lblQuestionsLeft;
        private Label lblTimer;

        private Button btnLeaveGame;
    }
}