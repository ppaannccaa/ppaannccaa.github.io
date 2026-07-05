using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public class MainForm : Form
    {
        private Button btnPlay;
        private Button btnStats;
        private CheckBox chkTheme;

        public MainForm()
        {
            this.Text = "🎲 Dice Battle Game";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            ThemeManager.LoadTheme();
            InitializeControls();
            ThemeManager.Apply(this);
        }

        private void InitializeControls()
        {
            // ====== PLAY BUTTON ======
            btnPlay = new Button();
            btnPlay.Text = "PLAY";
            btnPlay.Size = new Size(150, 50);
            btnPlay.Location = new Point((this.ClientSize.Width - btnPlay.Width) / 2, 50);
            btnPlay.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnPlay.Click += BtnPlay_Click;
            this.Controls.Add(btnPlay);

            // ====== STATS BUTTON ======
            btnStats = new Button();
            btnStats.Text = "STATS";
            btnStats.Size = new Size(150, 50);
            btnStats.Location = new Point((this.ClientSize.Width - btnStats.Width) / 2, 120);
            btnStats.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            btnStats.Click += BtnStats_Click;
            this.Controls.Add(btnStats);

            // ====== DARK MODE CHECKBOX ======
            chkTheme = new CheckBox();
            chkTheme.Text = "Dark Mode";
            chkTheme.Size = new Size(120, 30);
            chkTheme.Location = new Point((this.ClientSize.Width - chkTheme.Width) / 2, 190);
            chkTheme.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chkTheme.Checked = ThemeManager.IsDark;
            chkTheme.CheckedChanged += ChkTheme_CheckedChanged;
            this.Controls.Add(chkTheme);
        }

        // ====== BUTTON EVENTS ======
        private void BtnPlay_Click(object sender, EventArgs e)
        {
            PlayForm playForm = new PlayForm();
            playForm.Show();
            this.Hide();
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {
            StatsForm statsForm = new StatsForm();
            statsForm.Show();
            this.Hide();
        }

        private void ChkTheme_CheckedChanged(object sender, EventArgs e)
        {
            ThemeManager.IsDark = chkTheme.Checked;
            ThemeManager.SaveTheme();
            ThemeManager.Apply(this);
        }

        // Optional: Ensure app exits if MainForm is closed while others are open
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}