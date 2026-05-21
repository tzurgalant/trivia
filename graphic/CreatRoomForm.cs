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
    public partial class CreatRoomForm : Form
    {
        public CreatRoomForm()
        {
            InitializeComponent();
            if (Helper._currentUser.Name != null)
            {
                label2.Text = "Welcom," + Helper._currentUser.Name + "!!";
            }
            else
            {
                label2.Text = "Welcom, Player!";
            }
        }

        private void btnStartRoom_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text;
            string numOfPlayers = txtNumOfPlayers.Text.Trim();
            string timeForQustion = txtTimeForQustion.Text.Trim();

            if (string.IsNullOrEmpty(roomName) || string.IsNullOrEmpty(numOfPlayers) || string.IsNullOrEmpty(timeForQustion))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            pnlRoomDetails.Visible = true;

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            pnlRoomDetails.Visible = false;
            MenuForm FormWindow = new MenuForm();
            FormWindow.Show();
            this.Hide();
        }
    }
}