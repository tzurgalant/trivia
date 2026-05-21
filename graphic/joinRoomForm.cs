namespace clientGraphic
{
    public partial class joinRoomForm : Form
    {
        public joinRoomForm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private ListBox listBoxRooms;
        private Label label1;
        private Button btnRefresh;

        private void InitializeComponent()
        {
            listBoxRooms = new ListBox();
            label1 = new Label();
            btnRefresh = new Button();
            btnJoin = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // listBoxRooms
            // 
            listBoxRooms.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            listBoxRooms.ForeColor = Color.MediumPurple;
            listBoxRooms.FormattingEnabled = true;
            listBoxRooms.ItemHeight = 20;
            listBoxRooms.Location = new Point(450, 108);
            listBoxRooms.Name = "listBoxRooms";
            listBoxRooms.Size = new Size(500, 584);
            listBoxRooms.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(402, 50);
            label1.Name = "label1";
            label1.Size = new Size(204, 20);
            label1.TabIndex = 1;
            label1.Text = "Available Game Rooms";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.MenuBar;
            btnRefresh.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.MediumPurple;
            btnRefresh.Location = new Point(133, 108);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 50);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnJoin
            // 
            btnJoin.BackColor = SystemColors.MenuBar;
            btnJoin.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnJoin.ForeColor = Color.MediumPurple;
            btnJoin.Location = new Point(133, 188);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(250, 50);
            btnJoin.TabIndex = 3;
            btnJoin.Text = "Join Room";
            btnJoin.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.MenuBar;
            btnBack.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnBack.ForeColor = Color.MediumPurple;
            btnBack.Location = new Point(133, 639);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 53);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // joinRoomForm
            // 
            BackColor = Color.MediumPurple;
            ClientSize = new Size(978, 744);
            Controls.Add(btnBack);
            Controls.Add(btnJoin);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(listBoxRooms);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "joinRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnJoin;
        private Button btnBack;
    }
}
