using CUE.NET.Brushes;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using System.Drawing;

namespace MTKeyboardPlugin
{
    class RocketLeagueLib
    {
        public static CorsairKeyboard keyboard { get; set; }
        public static Plugin plugin { get; set; }
        public static bool runWithoutKeyboard { get; set; } = false;
        public static void SetColor(Color color, char key)
        {
            if (runWithoutKeyboard)
                return;
            switch (key)
            {
                case '1':
                    keyboard[CorsairKeyboardLedId.D1].Color = color;
                    break;
                case '2':
                    keyboard[CorsairKeyboardLedId.D2].Color = color;
                    break;
                case '3':
                    keyboard[CorsairKeyboardLedId.D3].Color = color;
                    break;
                case '4':
                    keyboard[CorsairKeyboardLedId.D4].Color = color;
                    break;
                case '5':
                    keyboard[CorsairKeyboardLedId.D5].Color = color;
                    break;
                case '6':
                    keyboard[CorsairKeyboardLedId.D6].Color = color;
                    break;
                case '7':
                    keyboard[CorsairKeyboardLedId.D7].Color = color;
                    break;
                case '8':
                    keyboard[CorsairKeyboardLedId.D8].Color = color;
                    break;
                case '9':
                    keyboard[CorsairKeyboardLedId.D9].Color = color;
                    break;
                case '0':
                    keyboard[CorsairKeyboardLedId.D0].Color = color;
                    break;
                default:
                    keyboard[key].Color = color;
                    break;
            }
            keyboard.Update();
        }

        public static void clearKeyboard()
        {
            plugin.print("Clearing Keyboard");
            keyboard.Brush = (SolidColorBrush)Color.White;
            keyboard.Update();
        }

        public static void SetGoals(Color color, string score)
        {
            if (runWithoutKeyboard)
                return;
            //clearKeyboard();
            foreach (char character in score)
            {
                SetColor(color, character);
            }
        }
    }
}
