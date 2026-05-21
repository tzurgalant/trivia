using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace clientGraphic
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            if(Helper._currentUser.Name != null)
            {
                label2.Text = "Welcom," + Helper._currentUser.Name + "!!";
            }
            else
            {
                label2.Text = "Welcom, Player!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if(Helper._currentUser.IsLogged)
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
    }
}
