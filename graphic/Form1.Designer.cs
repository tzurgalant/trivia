namespace clientGraphic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxRooms = new ListBox();
            btnRefresh = new Button();
            btnJoin = new Button();
            SuspendLayout();
            // 
            // listBoxRooms
            // 
            listBoxRooms.FormattingEnabled = true;
            listBoxRooms.ItemHeight = 25;
            listBoxRooms.Location = new Point(292, 128);
            listBoxRooms.Name = "listBoxRooms";
            listBoxRooms.Size = new Size(180, 129);
            listBoxRooms.TabIndex = 0;
            listBoxRooms.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(143, 170);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(143, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh Rooms";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnJoin
            // 
            btnJoin.Location = new Point(509, 210);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(178, 34);
            btnJoin.TabIndex = 2;
            btnJoin.Text = "Join Selected Room";
            btnJoin.UseVisualStyleBackColor = true;
            btnJoin.Click += btnJoin_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnJoin);
            Controls.Add(btnRefresh);
            Controls.Add(listBoxRooms);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxRooms;
        private Button btnRefresh;
        private Button btnJoin;
    }
}
