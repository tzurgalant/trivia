using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnLogin, Color.Magenta);
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginRequest loginReq = new LoginRequest
            {
                username = username,
                password = password
            };

            LoginResponse loginRes = Communicator.SendAndReceive<LoginResponse>(100, loginReq);

            if (loginRes.status == 1)
            {
                Helper._currentUser.IsLogged = true;
                Helper._currentUser.Name = username;
                Helper._currentUser.Pass = password;

                MenuForm FormWindow = new MenuForm();
                FormWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed! Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtUsername.BackColor = Color.FromArgb(45, 45, 45);
                txtUsername.ForeColor = Color.White;
                txtPassword.BackColor = Color.FromArgb(45, 45, 45);
                txtPassword.ForeColor = Color.White;

                btnLogin.ForeColor = Color.MediumPurple;
                btnBack.ForeColor = Color.Tomato;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);

                label1.ForeColor = Color.MediumPurple;
                label2.ForeColor = Color.FromArgb(50, 50, 50);
                label3.ForeColor = Color.FromArgb(50, 50, 50);

                txtUsername.BackColor = Color.White;
                txtUsername.ForeColor = Color.Black;
                txtPassword.BackColor = Color.White;
                txtPassword.ForeColor = Color.Black;

                btnLogin.ForeColor = Color.Purple;
                btnBack.ForeColor = Color.Tomato;
            }
        }
    }
    public struct LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public struct LoginResponse
    {
        public int status { get; set; }
    }
}
