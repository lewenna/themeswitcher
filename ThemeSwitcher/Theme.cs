using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeSwitcher
{
    public enum Theme
    {
        DARK, WHITE
    }

    public static class ThemeValue
    {
        public static int GetValue(Theme theme)
        {
            switch (theme)
            {
                case Theme.DARK:
                    return 0;
                case Theme.WHITE:
                    return 1;
                default:
                    break;
            }
            return 0;
        }
    }
}
