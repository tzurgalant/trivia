namespace clientGraphic
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnReturn_Click(object sender, EventArgs e)
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
