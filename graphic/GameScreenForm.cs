using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class GameScreenForm : Form
    {
        private bool _isBackButtonClicked = false;
        public GameScreenForm()
        {
            InitializeComponent();
            LoadGameScreen();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnLeaveGame, Color.Tomato);

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void LoadGameScreen()
        {
            try
            {
                getNewQuestion();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading GameScreen: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            Button clickedButton = (sender as Button);
            if (clickedButton == null)
            {
                return;
            }

            int selectedAnswerId = (int)clickedButton.Tag;

            SubmitAnswerRequest req = new SubmitAnswerRequest { answerId = (uint)selectedAnswerId };

            SubmitAnswerResponse res = Communicator.SendAndReceive<SubmitAnswerResponse>((byte)CodeR.SubmitAnswerResponseCmd, req);

            //check if the answer was correct
            if (res.status == 1)
            {
                if (selectedAnswerId == res.correctAnswerId)
                {
                    MessageBox.Show("true");
                }
                else
                {
                    MessageBox.Show("false");
                }

                //loading next question
                getNewQuestion();
            }
        }

        private void btnLeaveGame_Click(object sender, EventArgs e)
        {
            Helper._currentUser.IsAdmin = false;

            LeaveGameResponse res = Communicator.SendAndReceive<LeaveGameResponse>((byte)CodeR.LeaveGameCmd);

            if (res.status != 1)
            {
                MessageBox.Show("Failed to leave game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _isBackButtonClicked = true;
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }

        private void ApplyCurrentTheme()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(ApplyCurrentTheme));
                return;
            }

            if (MenuForm.IsDarkMode)
            {
                this.BackColor = Color.FromArgb(35, 35, 35);
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
            }
        }

        private void getNewQuestion()
        {
            GetQuestionResponse res = Communicator.SendAndReceive<GetQuestionResponse>((byte)CodeR.GetQuestionResponseCmd);

            if (res.status == 0 || string.IsNullOrEmpty(res.question) || res.answers == null)
            {
                OpenResultsScreen();
                return;
            }

            lblQuestion.Text = res.question;
            Button[] answerButtons = { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 };

            for (int i = 0; i < res.answers.Length; i++)
            {
                if (i >= answerButtons.Length) break;

                string idStr = res.answers[i][0];
                string answerText = res.answers[i][1];

                answerButtons[i].Text = answerText;
                answerButtons[i].Tag = Convert.ToInt32(idStr); 
            }
        }

        private void OpenResultsScreen()
        {
            GameResultForm resultForm = new GameResultForm();
            resultForm.Show();

            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_isBackButtonClicked)
            {
                Application.Exit();
            }
            base.OnFormClosing(e);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

    }
    public struct SubmitAnswerRequest
    {
        public uint answerId { get; set; }
    }

    public struct GetQuestionResponse
    {
        public uint status { get; set; }
        public string question { get; set; }

        public string[][] answers { get; set; }
    }
    public struct SubmitAnswerResponse
    {
        public uint status { get; set; }
        public uint correctAnswerId { get; set; }
    }

    public struct LeaveGameResponse
    {
        public uint status { get; set; }
    }
}