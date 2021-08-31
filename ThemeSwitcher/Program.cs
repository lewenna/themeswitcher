using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading;

namespace ThemeSwitcher
{
    class Program
    {
        const string userRoot = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\";
        const string subkey = "Personalize";
        const string keyName = userRoot + "\\" + subkey;

        static void Main(string[] args)
        {
            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true).SetValue("ThemeSwitcher", System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("dll", "exe"));

            while (true)
            {
                int hour = DateTime.Now.Hour;
                int[] whiteHours = new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
                if (whiteHours.Contains(hour) && GetCurrentTheme() != Theme.WHITE)
                {
                    SetCurrentTheme(Theme.WHITE);
                }
                else if (!whiteHours.Contains(hour) && GetCurrentTheme() != Theme.DARK)
                {
                    SetCurrentTheme(Theme.DARK);
                }
                Thread.Sleep(30000);
            }
        }

        public static Theme GetCurrentTheme()
        {
            return (int)Registry.GetValue(keyName, "SystemUsesLightTheme", null) == 0 ? Theme.DARK : Theme.WHITE;
        }

        public static void SetCurrentTheme(Theme theme) //0 dark, 1 white
        {
            Registry.SetValue(keyName, "AppsUseLightTheme", ThemeValue.GetValue(theme));
            Registry.SetValue(keyName, "SystemUsesLightTheme", ThemeValue.GetValue(theme));
        }
    }
}
