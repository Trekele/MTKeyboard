using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUE.NET;
using CUE.NET.Brushes;
using CUE.NET.Devices.Keyboard;
using System.Drawing;
using CUE.NET.Devices.Keyboard.Enums;
using CUE.NET.Groups;
using CUE.NET.Gradients;
using CUE.NET.Effects;
using Newtonsoft.Json;


namespace MTKeyboardPlugin
{
    public partial class Plugin
    {

        public event Action<object> debug;

        public void print(string body)
        {
            Console.WriteLine(body);
            if (debug == null)
            {
                return;
            }

            Task.Run(() =>
            {
                debug(body);
            });
        }

        public void handleError(string json, Action<object> callback)
        {
            Result result = new Result();
            try
            {
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(result));
            }
            catch (Exception)
            {
                result.success = false;
                Task.Run(() => callback(result));
            }
        }

        public void handleInfoUpdates2(string json, Action<object> callback)
        {
            InfoUpdate.plugin = this;
            RocketLeagueLib.plugin = this;
            InfoUpdate infoUpdate = JsonConvert.DeserializeObject<InfoUpdate>(json);
            Result result = new Result();
            try
            {
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(result));
            }
            catch (Exception)
            {
                result.success = false;
                Task.Run(() => callback(result));
            }
        }

        public void handleNewEvents(string json, Action<object> callback)
        {
            Result result = new Result();
            try
            {
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(result));
            }
            catch (Exception)
            {
                result.success = false;
                Task.Run(() => callback(result));
            }
        }

        public void handleGameInfoUpdated(string json, Action<object> callback)
        {
            Result result = new Result();
            try
            {
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(result));
            }
            catch (Exception)
            {
                result.success = false;
                Task.Run(() => callback(result));
            }
        }

        public void handleGetRunningGameinfo(string json, Action<object> callback)
        {
            Result result = new Result();
            try
            {
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(result));
            }
            catch (Exception)
            {
                result.success = false;
                Task.Run(() => callback(result));
            }
        }

        public void setColor(string name, Action<object> callback)
        {
            try
            {
                print("setColor");
                //keyboard.SetColor('W', "Green");
                if (callback == null)
                {
                    return;
                }
                Task.Run(() => callback(true));
            }
            catch (Exception)
            {
                Task.Run(() => callback(false));
            }
        }

        //public void setScore(string json, Action<object> callback)
        //{
        //    try
        //    {
        //        print("setScore");
        //        dynamic jsonObject = JsonConvert.DeserializeObject(json);
        //        int score = (int)jsonObject.score;
        //        keyboard.SetScore(score);

        //        if (callback == null)
        //        {
        //            return;
        //        }

        //        Task.Run(() => callback(true));
        //    }
        //    catch (Exception)
        //    {
        //        Task.Run(() => callback(false));
        //    }
        //}

        public void Initialize(Action<object> callback, bool runWithoutKeyboard = false)
        {
            if (!CueSDK.IsInitialized)
            {
                CueSDK.Initialize();
            }

            RocketLeagueLib.keyboard = CueSDK.KeyboardSDK;
            RocketLeagueLib.keyboard.Brush = (SolidColorBrush)Color.Transparent;
            RocketLeagueLib.runWithoutKeyboard = runWithoutKeyboard;

            if (callback == null)
            {
                return;
            }

            Task.Run(() =>
            {
                try
                {
                    callback("initialized");
                }
                catch (Exception)
                {
                    callback("failed to initialize");
                }
            });
        }
    }
}
