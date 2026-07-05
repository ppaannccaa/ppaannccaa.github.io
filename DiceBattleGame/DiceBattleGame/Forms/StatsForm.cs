using DiceBattleGame.Models;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public class StatsForm : Form
    {
        private Label lblStats;
        private Button btnBack;

        public StatsForm()
        {
            this.Text = "📊 Game Stats";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeControls();
            ThemeManager.Apply(this);
            LoadStats();
        }

        private void InitializeControls()
        {
            // ===== Stats Label =====
            lblStats = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(30, 30)
            };
            this.Controls.Add(lblStats);

            // ===== Back Button =====
            btnBack = new Button
            {
                Text = "BACK",
                Size = new Size(100, 40),
                Location = new Point(150, 200),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);
        }

        private void LoadStats()
        {
            if (!File.Exists("stats.json"))
            {
                lblStats.Text = "No stats yet.";
                return;
            }

            var s = JsonSerializer.Deserialize<GameStats>(File.ReadAllText("stats.json"));

            lblStats.Text =
                $"Games Played: {s.GamesPlayed}\n" +
                $"Wins: {s.GamesWon}\n" +
                $"Losses: {s.GamesLost}";
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Close();
        }
    }
}