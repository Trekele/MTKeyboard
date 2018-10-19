using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Keyboard;
using CUE.NET.Devices.Keyboard.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKeyboardPlugin
{
    class Corsair
    {
        private bool runWithoutKeyboard;
        private CorsairKeyboard keyboard;

        public Corsair(bool runWithoutKeyboard = false)
        {
            this.runWithoutKeyboard = runWithoutKeyboard;
            if (runWithoutKeyboard)
                return;
            if (!CueSDK.IsInitialized)
            {
                CueSDK.Initialize();
            }

            keyboard = CueSDK.KeyboardSDK;
            keyboard.Brush = (SolidColorBrush)Color.Transparent;
        }

        public void SetColor(char key, string name)
        {
            if (runWithoutKeyboard)
                return;
            switch (key)
            {
                case '1':
                    keyboard[CorsairKeyboardLedId.D1].Color = Color.FromName(name);
                    break;
                case '2':
                    keyboard[CorsairKeyboardLedId.D2].Color = Color.FromName(name);
                    break;
                case '3':
                    keyboard[CorsairKeyboardLedId.D3].Color = Color.FromName(name);
                    break;
                case '4':
                    keyboard[CorsairKeyboardLedId.D4].Color = Color.FromName(name);
                    break;
                case '5':
                    keyboard[CorsairKeyboardLedId.D5].Color = Color.FromName(name);
                    break;
                case '6':
                    keyboard[CorsairKeyboardLedId.D6].Color = Color.FromName(name);
                    break;
                case '7':
                    keyboard[CorsairKeyboardLedId.D7].Color = Color.FromName(name);
                    break;
                case '8':
                    keyboard[CorsairKeyboardLedId.D8].Color = Color.FromName(name);
                    break;
                case '9':
                    keyboard[CorsairKeyboardLedId.D9].Color = Color.FromName(name);
                    break;
                case '0':
                    keyboard[CorsairKeyboardLedId.D0].Color = Color.FromName(name);
                    break;
                default:
                    keyboard[key].Color = Color.FromName(name);
                    break;
            }
            keyboard.Update();
        }

        public void SetScore(int score)
        {
            if (runWithoutKeyboard)
                return;
            foreach (char character in score.ToString())
            {
                SetColor(character, "Red");
            }
        }
    }
}
