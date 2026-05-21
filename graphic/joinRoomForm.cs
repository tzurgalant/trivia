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
        private Button btnRefresh;

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
            listBoxRooms.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            listBoxRooms.ForeColor = Color.MediumPurple;
            listBoxRooms.FormattingEnabled = true;
            listBoxRooms.ItemHeight = 32;
            listBoxRooms.Location = new Point(509, 136);
            listBoxRooms.Name = "listBoxRooms";
            listBoxRooms.Size = new Size(400, 548);
            listBoxRooms.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.MenuBar;
            btnRefresh.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.MediumPurple;
            btnRefresh.Location = new Point(133, 136);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 50);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnJoin
            // 
            btnJoin.BackColor = SystemColors.MenuBar;
            btnJoin.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnJoin.ForeColor = Color.MediumPurple;
            btnJoin.Location = new Point(133, 235);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(250, 50);
            btnJoin.TabIndex = 3;
            btnJoin.Text = "Join Room";
            btnJoin.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.MenuBar;
            btnBack.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.MediumPurple;
            btnBack.Location = new Point(133, 631);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 53);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.Font = new Font("Segoe UI Emoji", 22F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(319, 42);
            label2.Name = "label2";
            label2.Size = new Size(319, 58);
            label2.TabIndex = 6;
            label2.Text = "TRIVIA LOGIN ";
            // 
            // joinRoomForm
            // 
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(978, 744);
            Controls.Add(label2);
            Controls.Add(btnBack);
            Controls.Add(btnJoin);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxRooms);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "joinRoomForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += joinRoomForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Button btnJoin;
        private Button btnBack;

        private void joinRoomForm_Load(object sender, EventArgs e)
        {

        }

        private Label label2;
    }
}
