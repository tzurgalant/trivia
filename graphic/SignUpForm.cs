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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
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
