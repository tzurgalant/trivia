using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace clientGraphic
{
    public partial class CreatRoomForm : Form
    {
        private System.Windows.Forms.Timer _updatePlayersTimer;

        public CreatRoomForm()
        {
            InitializeComponent();

            UserInfo currentUser = Helper._currentUser;

            if (currentUser.Name != null)
                label2.Text = "Welcome, " + currentUser.Name + "!!";
            else
                label2.Text = "Welcome, Player!";

            _updatePlayersTimer = new System.Windows.Forms.Timer();
            _updatePlayersTimer.Interval = 1500;
            _updatePlayersTimer.Tick += UpdatePlayersTimer_Tick;
        }

        private void UpdatePlayersTimer_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    var request = new GetPlayersInRoomRequest
            //    {
            //        roomId = 0
            //    }; 
            //    var response = Communicator.SendAndReceive<GetPlayersInRoomResponse>((byte)CodeR.GetPlayersInRoomCmd);

            //    if (response.players != null)
            //    {
            //        PlayersList.Items.Clear();
            //        foreach (var player in response.players)
            //        {
            //            PlayersList.Items.Add(player);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Log to console to prevent intrusive popups during active gameplay
            //    Console.WriteLine("Failed to auto-refresh players list: " + ex.Message);
            //}
        }

        private void btnStartRoom_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();

            // Validate numeric inputs
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

            // Send creation request (Opcode 108)
            var response = Communicator.SendAndReceive<CreateRoomResponse>((byte)CodeR.CreateRoomCmd, request);

            if (response.status == 1)
            {
                pnlRoomDetails.Visible = true;

                // Lock fields after successful creation
                txtRoomName.Enabled = false;
                txtNumOfPlayers.Enabled = false;
                txtTimeForQustion.Enabled = false;
                btnStartRoom.Enabled = false;

                _updatePlayersTimer.Start();
            }
            else
            {
                MessageBox.Show("The server rejected the request. Room creation failed.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            StopAndDisposeTimer();
            Application.Exit();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            StopAndDisposeTimer(); // Critical: prevents background memory leaks

            pnlRoomDetails.Visible = false;
            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
        }

        private void StopAndDisposeTimer()
        {
            if (_updatePlayersTimer != null)
            {
                _updatePlayersTimer.Stop();
                _updatePlayersTimer.Dispose();
            }
        }
    }

    //Network Data Structures

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
    }
    public struct GetPlayersInRoomRequest
    {
        public int roomId { get; set; }
    }
    public struct GetPlayersInRoomResponse
    {
        public List<string> players { get; set; }
    }
}