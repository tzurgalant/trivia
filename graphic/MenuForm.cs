using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientGraphic
{
    public partial class MenuForm : Form
    {
        public static bool IsDarkMode { get; private set; } = true;

        public static event Action ThemeChanged;

        //night mode colors
        private readonly Color darkBg = Color.FromArgb(35, 35, 35);
        private readonly Color darkPanel = Color.FromArgb(45, 45, 45);
        private readonly Color darkText = Color.White;

        //day mode colors
        private readonly Color lightBg = Color.FromArgb(240, 240, 240);
        private readonly Color lightPanel = Color.FromArgb(220, 220, 220);
        private readonly Color lightText = Color.Black;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            if (Helper._currentUser.Name != null)
            {
                label2.Text = "Welcome, " + Helper._currentUser.Name + "!!";
            }
            else
            {
                label2.Text = "Welcome, Player!";
            }
            ApplyTheme();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                CreatRoomForm createRoomWindow = new CreatRoomForm();
                createRoomWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                PersonalStatisticsForm statsForm = new PersonalStatisticsForm();
                statsForm.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                HighScoresForm highScoresWindow = new HighScoresForm();
                highScoresWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm LoginFormWindow = new LoginForm();
            LoginFormWindow.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm SignUpFormWindow = new SignUpForm();
            SignUpFormWindow.Show();
            this.Hide();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                JoinRoomForm JoinRoomWindow = new JoinRoomForm();
                JoinRoomWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            IsDarkMode = !IsDarkMode;
            ApplyTheme();
            ThemeChanged?.Invoke();
        }
        private void ApplyTheme()
        {
            if (IsDarkMode)
            {
                this.BackColor = darkBg;
                panel1.BackColor = darkPanel;
                label2.ForeColor = SystemColors.ControlLight;

                btnJoinRoom.ForeColor = darkText;
                btnCreateRoom.ForeColor = darkText;
                btnStatistics.ForeColor = darkText;

                btnToggleTheme.Text = "☀️ Light Mode";
                btnToggleTheme.ForeColor = darkText;
            }
            else
            {
                this.BackColor = lightBg;
                panel1.BackColor = lightPanel;
                label2.ForeColor = Color.FromArgb(60, 60, 60);

                btnJoinRoom.ForeColor = lightText;
                btnCreateRoom.ForeColor = lightText;
                btnStatistics.ForeColor = lightText;

                btnToggleTheme.Text = "🌙 Dark Mode";
                btnToggleTheme.ForeColor = lightText;
            }
        }
    }
}