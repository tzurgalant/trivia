namespace clientGraphic
{
    public partial class Form1 : Form
    {
        public Form1()
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
            SuspendLayout();
            // 
            // listBoxRooms
            // 
            listBoxRooms.Font = new Font("Microsoft Sans Serif", 8.25F);
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
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(402, 50);
            label1.Name = "label1";
            label1.Size = new Size(184, 20);
            label1.TabIndex = 1;
            label1.Text = "Available Game Rooms";
            label1.Click += this.label1_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(133, 144);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(250, 50);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh List";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(978, 744);
            Controls.Add(btnRefresh);
            Controls.Add(label1);
            Controls.Add(listBoxRooms);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Load += this.Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
