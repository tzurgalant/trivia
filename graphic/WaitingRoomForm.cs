using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static clientGraphic.MenuForm;

namespace clientGraphic
{
    public partial class WaitingRoomForm : Form
    {
        private System.Windows.Forms.Timer _updatePlayersTimer;
        private int _currentRoomId;

        public WaitingRoomForm()
        {
            InitializeComponent();

            // Glowing effect
            ButtonEffects.AddGlowEffect(btnBack, Color.Tomato);

            // Night/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();

            UserInfo currentUser = Helper._currentUser;

            _updatePlayersTimer = new System.Windows.Forms.Timer();
            _updatePlayersTimer.Interval = 3000;
            _updatePlayersTimer.Tick += UpdatePlayersTimer_Tick;
        }

        private void WaitingRoomForm_Load(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
            
            // Show Start Game button only for admin
            if (Helper._currentUser.IsAdmin)
            {
                btnStartGame.Visible = true;
                ButtonEffects.AddGlowEffect(btnStartGame, Color.Magenta);
            }
            else
            {
                btnStartGame.Visible = false;
            }

            _updatePlayersTimer.Start();
        }

        private void UpdatePlayersTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                var request = new GetPlayersInRoomRequest
                {
                    roomId = _currentRoomId
                };

                var response = Communicator.SendAndReceive<GetPlayersInRoomResponse>((byte)CodeR.GetPlayersInRoomCmd, request);

                if (response?.players != null)
                {
                    PlayersList.Items.Clear();
                    foreach (var player in response.players)
                    {
                        PlayersList.Items.Add(player);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to auto-refresh players list: " + ex.Message);
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                var request = new StartGameRequest
                {
                    roomId = _currentRoomId
                };

                var response = Communicator.SendAndReceive<StartGameResponse>((byte)CodeR.StartGameCmd, request);

                if (response?.status == 1)
                {
                    MessageBox.Show("Game started!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Navigate to game form or next screen
                }
                else
                {
                    MessageBox.Show("Could not start game. Make sure all players are ready.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper._currentUser.IsAdmin)
                {
                    // Admin closes the room
                    var closeRequest = new CloseRoomRequest
                    {
                        roomId = _currentRoomId
                    };

                    var closeResponse = Communicator.SendAndReceive<CloseRoomResponse>((byte)CodeR.CloseRoomCmd, closeRequest);

                    if (closeResponse?.status == 1)
                    {
                        MessageBox.Show("Room closed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to close room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Member leaves the room
                    var leaveRequest = new LeaveRoomRequest
                    {
                        roomId = _currentRoomId
                    };

                    var leaveResponse = Communicator.SendAndReceive<LeaveRoomResponse>((byte)CodeR.LeaveRoomCmd, leaveRequest);

                    if (leaveResponse?.status == 1)
                    {
                        MessageBox.Show("You left the room.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to leave room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MenuForm FormWindow = new MenuForm();
                FormWindow.Show();
                this.Hide();
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

                if (PlayersList != null)
                {
                    PlayersList.BackColor = Color.FromArgb(45, 45, 45);
                    PlayersList.ForeColor = Color.White;
                }

                lblShowPlayers.ForeColor = Color.White;
                label1.ForeColor = Color.MediumPurple;
                btnBack.ForeColor = Color.Tomato;
                
                if (btnStartGame != null && btnStartGame.Visible)
                {
                    btnStartGame.ForeColor = Color.MediumPurple;
                }
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);

                if (PlayersList != null)
                {
                    PlayersList.BackColor = Color.White;
                    PlayersList.ForeColor = Color.FromArgb(50, 50, 50);
                }

                lblShowPlayers.ForeColor = Color.FromArgb(50, 50, 50);
                label1.ForeColor = Color.Purple;
                btnBack.ForeColor = Color.Tomato;
                
                if (btnStartGame != null && btnStartGame.Visible)
                {
                    btnStartGame.ForeColor = Color.Purple;
                }
            }
        }

        public void SetRoomId(int roomId)
        {
            _currentRoomId = roomId;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _updatePlayersTimer?.Stop();
            _updatePlayersTimer?.Dispose();
            base.OnFormClosing(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

    public class GetPlayersInRoomRequest
    {
        public int roomId { get; set; }
    }

    public class GetPlayersInRoomResponse
    {
        public List<string> players { get; set; }
    }

    public class StartGameRequest
    {
        public int roomId { get; set; }
    }

    public class StartGameResponse
    {
        public int status { get; set; }
    }

    public class CloseRoomRequest
    {
        public int roomId { get; set; }
    }

    public class CloseRoomResponse
    {
        public int status { get; set; }
    }

    public class LeaveRoomRequest
    {
        public int roomId { get; set; }
    }

    public class LeaveRoomResponse
    {
        public int status { get; set; }
    }
}
