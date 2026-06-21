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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnSignUp, Color.Magenta);
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SignUpRequest signUpReq = new SignUpRequest
            {
                username = username,
                password = password,
                email = email
            };

            SignUpResponse signUpRes = Communicator.SendAndReceive<SignUpResponse>(101, signUpReq);

            if (signUpRes.status == 1)
            {
                Helper._currentUser.IsLogged = true;
                Helper._currentUser.Name = username;
                Helper._currentUser.Pass = password;
                Helper._currentUser.Email = email;

                MessageBox.Show("Sign Up Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MenuForm FormWindow = new MenuForm();
                FormWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sign Up failed! Username might already be taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyCurrentTheme()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ApplyCurrentTheme));
                return;
            }

            if (MenuForm.IsDarkMode)
            {
                this.BackColor = Color.FromArgb(35, 35, 35);

                label1.ForeColor = Color.MediumPurple;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;

                txtUsername.BackColor = Color.FromArgb(45, 45, 45);
                txtUsername.ForeColor = Color.White;
                txtEmail.BackColor = Color.FromArgb(45, 45, 45);
                txtEmail.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(45, 45, 45);
                txtPassword.ForeColor = Color.White;

                btnSignUp.ForeColor = Color.MediumPurple;
                btnBack.ForeColor = Color.Tomato;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);

                label1.ForeColor = Color.MediumPurple;
                label2.ForeColor = Color.FromArgb(50, 50, 50);
                label3.ForeColor = Color.FromArgb(50, 50, 50);
                label4.ForeColor = Color.FromArgb(50, 50, 50);

                txtUsername.BackColor = Color.White;
                txtUsername.ForeColor = Color.Black;
                txtEmail.BackColor = Color.White;
                txtEmail.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;

                btnSignUp.ForeColor = Color.Purple;
                btnBack.ForeColor = Color.Tomato;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.TaskManagerClosing)
            {
                Application.Exit();
            }
        }
    }

    public struct SignUpRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }

    public struct SignUpResponse
    {
        public int status { get; set; }
    }
}
