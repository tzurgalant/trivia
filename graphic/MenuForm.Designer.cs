namespace clientGraphic
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 75, 64);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button8);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 744);
            panel1.TabIndex = 0;
            // 
            // button5
            // 
            button5.AccessibleName = "btnJoinRoom";
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Symbol", 12F);
            button5.ForeColor = SystemColors.Control;
            button5.Location = new Point(-3, 113);
            button5.Name = "button5";
            button5.Size = new Size(200, 50);
            button5.TabIndex = 11;
            button5.Text = "Join Room";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.AccessibleName = "btnCreateRoom";
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.Cursor = Cursors.Hand;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Segoe UI Symbol", 12F);
            button6.ForeColor = SystemColors.Control;
            button6.Location = new Point(-3, 169);
            button6.Name = "button6";
            button6.Size = new Size(200, 50);
            button6.TabIndex = 8;
            button6.Text = "Create Room";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.AccessibleName = "btnStatistics";
            button7.BackgroundImageLayout = ImageLayout.None;
            button7.Cursor = Cursors.Hand;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Segoe UI Symbol", 12F);
            button7.ForeColor = SystemColors.Control;
            button7.Location = new Point(-3, 225);
            button7.Name = "button7";
            button7.Size = new Size(200, 50);
            button7.TabIndex = 9;
            button7.Text = "Statistics";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.AccessibleName = "btnExit";
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.Cursor = Cursors.Hand;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Segoe UI Symbol", 12F);
            button8.ForeColor = SystemColors.Control;
            button8.Location = new Point(-3, 691);
            button8.Name = "button8";
            button8.Size = new Size(200, 50);
            button8.TabIndex = 10;
            button8.Text = "Exit";
            button8.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 24F, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(354, 9);
            label1.Name = "label1";
            label1.Size = new Size(278, 65);
            label1.TabIndex = 4;
            label1.Text = "Main Menu";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AccessibleName = "lblWelcome";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(581, 74);
            label2.Name = "label2";
            label2.Size = new Size(215, 38);
            label2.TabIndex = 5;
            label2.Text = "Welcom, Player!";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(978, 744);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuForm";
            Load += MenuForm_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
    }
}