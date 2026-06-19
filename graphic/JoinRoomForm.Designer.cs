using System.Drawing;
using System.Windows.Forms;

namespace clientGraphic
{
    partial class JoinRoomForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            listBoxRooms = new ListBox();
            btnRefresh = new Button();
            btnJoin = new Button();
            btnBack = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // listBoxRooms
            // 
            listBoxRooms.BackColor = Color.FromArgb(45, 45, 45);
            listBoxRooms.BorderStyle = BorderStyle.None;
            listBoxRooms.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            listBoxRooms.ForeColor = Color.MediumPurple;
            listBoxRooms.FormattingEnabled = true;
            listBoxRooms.ItemHeight = 32;
            listBoxRooms.Location = new Point(509, 136);
            listBoxRooms.Name = "listBoxRooms";
            listBoxRooms.Size = new Size(400, 544);
            listBoxRooms.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(133, 136);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 50);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnJoin
            // 
            btnJoin.Cursor = Cursors.Hand;
            btnJoin.FlatAppearance.BorderSize = 0;
            btnJoin.FlatStyle = FlatStyle.Flat;
            btnJoin.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnJoin.ForeColor = Color.MediumPurple;
            btnJoin.Location = new Point(133, 235);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(250, 50);
            btnJoin.TabIndex = 3;
            btnJoin.Text = "Join Room";
            btnJoin.UseVisualStyleBackColor = false;
            btnJoin.Click += joinRoom_Click;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.Tomato;
            btnBack.Location = new Point(133, 631);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 53);
            btnBack.TabIndex = 4;
            btnBack.Text = "Return To Menu";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 26F, FontStyle.Bold);
            label2.ForeColor = Color.MediumPurple;
            label2.Location = new Point(340, 40);
            label2.Name = "label2";
            label2.Size = new Size(277, 69);
            label2.TabIndex = 6;
            label2.Text = "Join Room";
            // 
            // JoinRoomForm
            // 
            BackColor = Color.FromArgb(35, 35, 35);
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(978, 744);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(btnJoin);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxRooms);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "JoinRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += JoinRoomForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox listBoxRooms;
        private Button btnRefresh;
        private Button btnJoin;
        private Button btnBack;
        private Label label2;
    }
}