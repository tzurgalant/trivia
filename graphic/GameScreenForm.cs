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
        private System.Windows.Forms.Timer _questionTimer;
        private int _timePerQuestion;
        private int _timeLeft;
        private int _totalQuestions;
        private int _questionsAnswered = 0;

        public GameScreenForm(int totalQuestions, int timePerQuestion)
        {
            InitializeComponent();

            _totalQuestions = totalQuestions;
            _timePerQuestion = timePerQuestion;
            _questionTimer = new System.Windows.Forms.Timer();
            _questionTimer.Interval = 1000;
            _questionTimer.Tick += QuestionTimer_Tick;

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

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            _timeLeft--;
            lblTimer.Text = $"⏱ {_timeLeft}";

            if (_timeLeft <= 0)
            {
                _questionTimer.Stop();
                SubmitAnswerRequest req = new SubmitAnswerRequest { answerId = 255 };
                SubmitAnswerResponse res = Communicator.SendAndReceive<SubmitAnswerResponse>(
                    (byte)CodeR.SubmitAnswerResponseCmd, req);
                getNewQuestion();
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
                //if (selectedAnswerId == res.correctAnswerId)
                //{
                //    MessageBox.Show("true");
                //}
                //else
                //{
                //    MessageBox.Show("false");
                //}

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
            _questionTimer.Stop();
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
            GetQuestionResponse res = Communicator.SendAndReceive<GetQuestionResponse>(
            (byte)CodeR.GetQuestionResponseCmd);

            if (res.status == 0 || string.IsNullOrEmpty(res.question) || res.answers == null)
            {
                _questionTimer.Stop();
                OpenResultsScreen();
                return;
            }

            //update questions counter
            _questionsAnswered++;
            lblQuestionsLeft.Text = $"Questions Left: {_totalQuestions - _questionsAnswered}";

            //reset timer
            _questionTimer.Stop();
            _timeLeft = _timePerQuestion;
            lblTimer.Text = $"⏱ {_timeLeft}";
            _questionTimer.Start();

            lblQuestion.Text = res.question;
            Button[] answerButtons = { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 };

            for (int i = 0; i < res.answers.Length; i++)
            {
                if (i >= answerButtons.Length) break;

                object idRaw = res.answers[i][0];
                object textRaw = res.answers[i][1];

                if (idRaw is System.Text.Json.JsonElement idElement && textRaw is System.Text.Json.JsonElement textElement)
                {
                    answerButtons[i].Text = textElement.GetString();

                    answerButtons[i].Tag = idElement.GetInt32();
                }
                else if (idRaw != null && textRaw != null)
                {
                    answerButtons[i].Text = textRaw.ToString();
                    answerButtons[i].Tag = Convert.ToInt32(idRaw);
                }
            }
        }

        private void OpenResultsScreen()
        {
            _isBackButtonClicked = true;
            _questionTimer.Stop();
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

        public object[][] answers { get; set; }
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