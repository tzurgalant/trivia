using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class CreatRoomForm : Form
    {
        private int _currentRoomId;

        public CreatRoomForm()
        {
            InitializeComponent();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnCreateRoom, Color.Magenta);
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            //night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();

            UserInfo currentUser = Helper._currentUser;

            if (currentUser.Name != null)
                label2.Text = "Welcome, " + currentUser.Name + "!!";
            else
                label2.Text = "Welcome, Player!";

        }



        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();

            if (!int.TryParse(txtNumOfPlayers.Text.Trim(), out int maxUsers) ||
                !int.TryParse(txtTimeForQustion.Text.Trim(), out int questionTime) ||
                !int.TryParse(txtQuestionCount.Text.Trim(), out int questionCount))
            {
                MessageBox.Show("Please enter valid numbers!", "Data Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var request = new CreateRoomRequest
            {
                roomName = roomName,
                maxUsers = maxUsers,
                answerTimeout = questionTime,
                questionCount = questionCount
            };

            var response = Communicator.SendAndReceive<CreateRoomResponse>((byte)CodeR.CreateRoomCmd, request);

            if (response.status == 1)
            {
                _currentRoomId = response.roomId;
                Helper._currentUser.IsAdmin = true;
                txtRoomName.Enabled = false;
                txtNumOfPlayers.Enabled = false;
                txtTimeForQustion.Enabled = false;
                btnCreateRoom.Enabled = false;

                WaitingRoomForm FormWindow = new WaitingRoomForm();
                FormWindow.SetRoomId(_currentRoomId);
                FormWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("The server rejected the request. Room creation failed.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
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
                label2.ForeColor = Color.DarkGray;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                label6.ForeColor = Color.White;
 

                txtRoomName.BackColor = Color.FromArgb(45, 45, 45);
                txtRoomName.ForeColor = Color.White;
                txtTimeForQustion.BackColor = Color.FromArgb(45, 45, 45);
                txtTimeForQustion.ForeColor = Color.White;
                txtQuestionCount.BackColor = Color.FromArgb(45, 45, 45);
                txtQuestionCount.ForeColor = Color.White;
                txtNumOfPlayers.BackColor = Color.FromArgb(45, 45, 45);
                txtNumOfPlayers.ForeColor = Color.White;


                btnCreateRoom.ForeColor = Color.MediumPurple;
                btnBack.ForeColor = Color.Tomato;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);

                label1.ForeColor = Color.MediumPurple;
                label2.ForeColor = Color.DimGray;
                label3.ForeColor = Color.FromArgb(50, 50, 50);
                label4.ForeColor = Color.FromArgb(50, 50, 50);
                label5.ForeColor = Color.FromArgb(50, 50, 50);
                label6.ForeColor = Color.FromArgb(50, 50, 50);

                txtRoomName.BackColor = Color.White;
                txtRoomName.ForeColor = Color.Black;
                txtTimeForQustion.BackColor = Color.White;
                txtTimeForQustion.ForeColor = Color.Black;
                txtQuestionCount.BackColor = Color.White;
                txtQuestionCount.ForeColor = Color.Black;
                txtNumOfPlayers.BackColor = Color.White;
                txtNumOfPlayers.ForeColor = Color.Black;


                btnCreateRoom.ForeColor = Color.Purple;
                btnBack.ForeColor = Color.Tomato;
            }
        }

        private void PlayersList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

    // ==========================================
    //        Network Data Structures
    // ==========================================

    public struct CreateRoomRequest
    {
        public string roomName { get; set; }
        public int maxUsers { get; set; }
        public int questionCount { get; set; }
        public int answerTimeout { get; set; }
    }

    public struct CreateRoomResponse
    {
        public int status { get; set; }
        public int roomId { get; set; }
    }


}