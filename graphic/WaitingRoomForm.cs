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
        private bool _isUpdating = false;

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
            if (_isUpdating) return;
            _isUpdating = true;

            try
            {
                Console.WriteLine($"Timer tick - RoomId: {_currentRoomId}");

                if (_currentRoomId < 0)
                {
                    Console.WriteLine("RoomId not set!");
                    _isUpdating = false;
                    return;
                }

                if (!Helper._currentUser.IsAdmin)
                {
                    var response = Communicator.SendAndReceive<GetRoomStateResponse>((byte)CodeR.GetRoomStateCmd);

                    if (response == null || response.status != 1)
                    {
                        _updatePlayersTimer.Stop();
                        MessageBox.Show("The room was closed by the admin.", "Room Closed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        MenuForm FormWindow = new MenuForm();
                        FormWindow.Show();
                        this.Close();
                        return;
                    }

                    if (response.hasGameBegun)
                    {
                        _updatePlayersTimer.Stop();

                        GameScreenForm gameWindow = new GameScreenForm();
                        gameWindow.Show();
                        this.Close();
                        return;
                    }

                    if (response.players != null)
                    {
                        PlayersList.Items.Clear();
                        PlayersList.Items.AddRange(response.players.ToArray());
                    }
                }
                else
                {
                    var response = Communicator.SendAndReceive<GetRoomStateResponse>((byte)CodeR.GetRoomStateCmd);

                    if (response?.players != null)
                    {
                        PlayersList.Items.Clear();
                        PlayersList.Items.AddRange(response.players.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed in timer tick: " + ex.Message);
            }
            finally
            {
                _isUpdating = false;
            }
        }
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            try
            {
                var response = Communicator.SendAndReceive<StartGameResponse>((byte)CodeR.StartGameCmd);

                if (response?.status == 1)
                {
                    MessageBox.Show("Game started!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Navigate to game form or next screen

                    _updatePlayersTimer.Stop();

                    GameScreenForm gameWindow = new GameScreenForm();
                    gameWindow.Show();

                    this.Close();
                    return;
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
            finally
            {
                _isUpdating = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            bool wasAdmin = Helper._currentUser.IsAdmin;
            Helper._currentUser.IsAdmin = false;

            try
            {
                if (wasAdmin)
                {
                    // Admin closes the room

                    var closeResponse = Communicator.SendAndReceive<CloseRoomResponse>((byte)CodeR.CloseRoomCmd);

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

                    var leaveResponse = Communicator.SendAndReceive<LeaveRoomResponse>((byte)CodeR.LeaveRoomCmd);
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
                _updatePlayersTimer.Stop();
                this.Close();
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

    public class sumbitAnswerRequest
    {
        public int answerId { get; set; }
    }

    public class GetPlayersInRoomResponse
    {
        public List<string> players { get; set; }
    }
    public class StartGameResponse
    {
        public int status { get; set; }
    }


    public class CloseRoomResponse
    {
        public int status { get; set; }
    }


    public class LeaveRoomResponse
    {
        public int status { get; set; }
    }
    public class GetRoomStateResponse
    {
        public int  status { get; set; }
        public bool hasGameBegun { get; set; }

        public  List<string>players { get; set; }

        public int questionCount { get; set; }

        public int answerTimeout { get; set; }
    }
}
