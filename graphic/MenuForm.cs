using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientGraphic
{
    public partial class MenuForm : Form
    {
        public static bool IsDarkMode { get; private set; } = true;

        public static event Action ThemeChanged;

        //night mode colors
        private readonly Color darkBg = Color.FromArgb(35, 35, 35);
        private readonly Color darkPanel = Color.FromArgb(45, 45, 45);
        private readonly Color darkText = Color.White;

        //day mode colors
        private readonly Color lightBg = Color.FromArgb(240, 240, 240);
        private readonly Color lightPanel = Color.FromArgb(220, 220, 220);
        private readonly Color lightText = Color.Black;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            if (Helper._currentUser.Name != null)
            {
                label2.Text = "Welcome, " + Helper._currentUser.Name + "!!";
            }
            else
            {
                label2.Text = "Welcome, Player!";
            }
            ApplyTheme();

            //glowing effect
            ButtonEffects.AddGlowEffect(btnExit, Color.Tomato);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                CreatRoomForm createRoomWindow = new CreatRoomForm();
                createRoomWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                PersonalStatisticsForm statsForm = new PersonalStatisticsForm();
                statsForm.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                HighScoresForm highScoresWindow = new HighScoresForm();
                highScoresWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm LoginFormWindow = new LoginForm();
            LoginFormWindow.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm SignUpFormWindow = new SignUpForm();
            SignUpFormWindow.Show();
            this.Hide();
        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            if (Helper._currentUser.IsLogged)
            {
                JoinRoomForm JoinRoomWindow = new JoinRoomForm();
                JoinRoomWindow.Show();
                this.Hide();
            }
            else
            {
                lblNotLoggedMessage.Visible = true;
                Helper.HideLabelAfterDelay(lblNotLoggedMessage, 5000);
            }
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            IsDarkMode = !IsDarkMode;
            ApplyTheme();
            ThemeChanged?.Invoke();
        }
        private void ApplyTheme()
        {
            if (IsDarkMode)
            {
                this.BackColor = darkBg;
                panel1.BackColor = darkPanel;
                label2.ForeColor = SystemColors.ControlLight;

                btnJoinRoom.ForeColor = darkText;
                btnCreateRoom.ForeColor = darkText;
                btnStatistics.ForeColor = darkText;

                btnToggleTheme.Text = "☀️ Light Mode";
                btnToggleTheme.ForeColor = darkText;
            }
            else
            {
                this.BackColor = lightBg;
                panel1.BackColor = lightPanel;
                label2.ForeColor = Color.FromArgb(60, 60, 60);

                btnJoinRoom.ForeColor = lightText;
                btnCreateRoom.ForeColor = lightText;
                btnStatistics.ForeColor = lightText;

                btnToggleTheme.Text = "🌙 Dark Mode";
                btnToggleTheme.ForeColor = lightText;
            }
        }

        //glowing effect
        public static class ButtonEffects
        {
            private class GlowState
            {
                public System.Windows.Forms.Timer Timer;
                public int AnimationStep;
                public bool IsHovered;
                public Color GlowColor;

                public EventHandler TickHandler;
                public EventHandler MouseEnterHandler;
                public EventHandler MouseLeaveHandler;
                public PaintEventHandler PaintHandler;
                public EventHandler SizeHandler;
            }

            private static readonly Dictionary<Button, GlowState> states = new();

            public static void AddGlowEffect(Button button, Color glowColor)
            {
                if (states.ContainsKey(button))
                {
                    states[button].GlowColor = glowColor;
                    return;
                }

                var state = new GlowState
                {
                    Timer = new System.Windows.Forms.Timer(),
                    AnimationStep = 0,
                    IsHovered = false,
                    GlowColor = glowColor
                };

                state.Timer.Interval = 16;

                int borderRadius = 20;

                GraphicsPath GetRoundPath(Rectangle bounds, int radius)
                {
                    GraphicsPath path = new GraphicsPath();
                    int diameter = radius * 2;

                    path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
                    path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
                    path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
                    path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
                    path.CloseFigure();
                    return path;
                }

                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;

                state.SizeHandler = (s, e) =>
                {
                    if (button.Width > borderRadius && button.Height > borderRadius)
                    {
                        using GraphicsPath path = GetRoundPath(
                            new Rectangle(0, 0, button.Width, button.Height),
                            borderRadius);

                        button.Region = new Region(path);
                    }
                };

                button.SizeChanged += state.SizeHandler;

                state.PaintHandler = (s, e) =>
                {
                    if (state.AnimationStep <= 0) return;

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    Color parentBg = button.Parent?.BackColor ?? Color.FromArgb(35, 35, 35);

                    float t = state.AnimationStep / 255f;

                    Color current = Color.FromArgb(
                        (int)(parentBg.R + (state.GlowColor.R - parentBg.R) * t),
                        (int)(parentBg.G + (state.GlowColor.G - parentBg.G) * t),
                        (int)(parentBg.B + (state.GlowColor.B - parentBg.B) * t)
                    );

                    using Pen pen = new Pen(current, 3);
                    using GraphicsPath path = GetRoundPath(
                        new Rectangle(1, 1, button.Width - 3, button.Height - 3),
                        borderRadius);

                    e.Graphics.DrawPath(pen, path);
                };

                button.Paint += state.PaintHandler;

                state.TickHandler = (s, e) =>
                {
                    if (state.IsHovered)
                    {
                        state.AnimationStep = Math.Min(255, state.AnimationStep + 40);
                        if (state.AnimationStep == 255)
                            state.Timer.Stop();
                    }
                    else
                    {
                        state.AnimationStep = Math.Max(0, state.AnimationStep - 25);
                        if (state.AnimationStep == 0)
                            state.Timer.Stop();
                    }

                    button.Invalidate();
                };

                state.MouseEnterHandler = (s, e) =>
                {
                    state.IsHovered = true;
                    state.Timer.Start();
                };

                state.MouseLeaveHandler = (s, e) =>
                {
                    state.IsHovered = false;
                    state.Timer.Start();
                };

                state.Timer.Tick += state.TickHandler;
                button.MouseEnter += state.MouseEnterHandler;
                button.MouseLeave += state.MouseLeaveHandler;

                states[button] = state;
            }

            public static void RemoveGlowEffect(Button button)
            {
                if (!states.ContainsKey(button))
                    return;

                var state = states[button];

                state.Timer.Stop();
                state.Timer.Tick -= state.TickHandler;
                state.Timer.Dispose();

                button.MouseEnter -= state.MouseEnterHandler;
                button.MouseLeave -= state.MouseLeaveHandler;
                button.Paint -= state.PaintHandler;
                button.SizeChanged -= state.SizeHandler;

                states.Remove(button);
            }
        }
    }
}