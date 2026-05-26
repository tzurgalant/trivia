using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace clientGraphic
{
    public partial class JoinRoomForm : Form
    {
        private List<RoomData> _availableRooms = new List<RoomData>();

        public JoinRoomForm()
        {
            InitializeComponent();

            //glowing effect
            MenuForm.AddGlowEffect(btnJoin);

            //nught/day mode related
            MenuForm.ThemeChanged += ApplyCurrentTheme;
            this.FormClosed += (s, e) => MenuForm.ThemeChanged -= ApplyCurrentTheme;
            ApplyCurrentTheme();
        }

        private void JoinRoomForm_Load(object sender, EventArgs e)
        {
            ApplyCurrentTheme();
            RefreshRoomsList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRoomsList();
        }


        private void RefreshRoomsList()
        {
            try
            {
                GetRoomsResponse response = Communicator.SendAndReceive<GetRoomsResponse>((byte)CodeR.GetRoomsCmd);

                if (response != null && response.rooms != null)
                {
                    _availableRooms = response.rooms;

                    listBoxRooms.Items.Clear();

                    foreach (var room in _availableRooms)
                    {
                        string displayText = $"Room: {room.name} | Players: {room.currentPlayers}/{room.maxPlayers}";
                        listBoxRooms.Items.Add(displayText);
                    }

                    if (_availableRooms.Count == 0)
                    {
                        listBoxRooms.Items.Add("No active rooms found. Create one!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
        }

        private void joinRoom_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxRooms.SelectedIndex;

            if (selectedIndex == -1 || _availableRooms.Count == 0 || selectedIndex >= _availableRooms.Count)
            {
                MessageBox.Show("Please select a valid room from the list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RoomData selectedRoom = _availableRooms[selectedIndex];

            var request = new JoinRoomRequest { roomId = selectedRoom.id };

            var response = Communicator.SendAndReceive<JoinRoomResponse>((byte)CodeR.JoinRoomCmd, request);

            if (response != null && response.status == 1)
            {
                MessageBox.Show($"Successfully joined {selectedRoom.name}!");
            }
            else
            {
                MessageBox.Show("Could not join room: ");
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
                label2.ForeColor = Color.MediumPurple;

                if (listBoxRooms != null)
                {
                    listBoxRooms.BackColor = Color.FromArgb(45, 45, 45);
                    listBoxRooms.ForeColor = Color.MediumPurple;
                }

                btnRefresh.ForeColor = Color.White;
                btnJoin.ForeColor = Color.MediumPurple;
                btnBack.ForeColor = Color.Tomato;
            }
            else
            {
                this.BackColor = Color.FromArgb(240, 240, 240);
                label2.ForeColor = Color.MediumPurple;

                if (listBoxRooms != null)
                {
                    listBoxRooms.BackColor = Color.White;
                    listBoxRooms.ForeColor = Color.MediumPurple;
                }

                btnRefresh.ForeColor = Color.FromArgb(50, 50, 50);
                btnJoin.ForeColor = Color.Purple;
                btnBack.ForeColor = Color.Tomato;
            }
        }
    }
    public class JoinRoomRequest
    {
        public int roomId { get; set; }
    }
    public class JoinRoomResponse
    {
        public int status { get; set; }
    }
    public class RoomData
    {
        public int id { get; set; }
        public string name { get; set; }
        public int maxPlayers { get; set; }
        public int currentPlayers { get; set; }
        public int timePerQuestion { get; set; }
        public bool isActive { get; set; }
    }
    public class GetRoomsResponse
    {
        public List<RoomData> rooms { get; set; }
    }
}