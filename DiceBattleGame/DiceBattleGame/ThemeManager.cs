using DiceBattleGame.Models;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

public static class ThemeManager
{
    public static bool IsDark = true;
    static string themeFile = "theme.json";

    public static void LoadTheme()
    {
        if (!File.Exists(themeFile)) return;
        var t = JsonSerializer.Deserialize<ThemeSettings>(File.ReadAllText(themeFile));
        IsDark = t.IsDark;
    }

    public static void SaveTheme()
    {
        File.WriteAllText(themeFile,
            JsonSerializer.Serialize(new ThemeSettings { IsDark = IsDark }));
    }

    public static void Apply(Form f)
    {
        Color back = IsDark ? Color.FromArgb(30, 30, 60) : Color.WhiteSmoke;
        Color fore = IsDark ? Color.White : Color.Black;

        f.BackColor = back;

        foreach (Control c in f.Controls)
        {
            c.ForeColor = fore;
            if (c is Button)
                c.BackColor = IsDark ? Color.MediumPurple : Color.LightSteelBlue;
        }
    }
}