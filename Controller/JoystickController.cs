using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using static CircleInput2.JoystickWrapper;

namespace CircleInput2
{
    public class JoystickController
    {
        #region DispatchCircleEvent
        public class DispatchCircleEventArg : EventArgs
        {
            public CircleDispatchCode.Code DispatchID { get; }

            public DispatchCircleEventArg(CircleDispatchCode.Code id)
            {
                DispatchID = id;
            }
        }
        public delegate void DispatchCircleEventHandler(object sender, DispatchCircleEventArg e);
        public event DispatchCircleEventHandler DispatchCircleEvent;

        protected void On(CircleDispatchCode.Code id)
        {
            DispatchCircleEvent?.Invoke(this, new DispatchCircleEventArg(id));
        }
        #endregion

        /// <summary>
        /// ジョイスティックの状態を監視します。
        /// </summary>
        public JoystickWrapper jso = new JoystickWrapper();

        /// <summary>
        /// 設定を管理します。
        /// </summary>
        ConfigController configManager;

        /// <summary>
        /// 入力スレッド
        /// </summary>
        Thread thread = null;

        /// <summary>
        /// プリセットごとの設定値
        /// </summary>
        Dictionary<string, Config> configList
        {
            get
            {
                return this.configManager.configList;
            }
            set
            {
                this.configManager.configList = value;
            }
        }

        /// <summary>
        /// 現在のプリセットの設定値
        /// </summary>
        Config config
        {
            get
            {
                return this.configManager.config;
            }
        }

        /// <summary>
        /// 現在の同時押しモード
        /// </summary>
        Mode currentInnerMode
        {
            get
            {
                return this.configManager.currentInnerMode;
            }
        }

        /// <summary>
        /// 同時押しを始めたキー
        /// </summary>
        string currentInnerModeIdx
        {
            get
            {
                return this.configManager.StartButton;
            }
            set
            {
                this.configManager.StartButton = value;
            }
        }
        Dictionary<string, string> pressInModeIdx = new Dictionary<string, string>();

        /// <summary>
        /// 前のフレームでのボタン押下状態を記録します
        /// </summary>
        Dictionary<string, int> latestJoystickHoldStatus = new Dictionary<string, int>();
        Dictionary<string, int> currentJoystickHoldStatus = new Dictionary<string, int>();

        /// <summary>
        /// 前のフレームでのボタン押下状態を記録します
        /// </summary>メインスティックの倒れ具合。
        /// </summary>
        public AnalogStickStatus latestMainpadStatus;

        /// <summary>
        /// 前のフレームでのボタン押下状態を記録します
        /// </summary>サブスティックの倒れ具合。
        /// </summary>
        public AnalogStickStatus latestRotationStatus;

        int wheelThresholdX = 0;
        int wheelThresholdY = 0;
        int latestWheelX = 0;
        int latestWheelY = 0;
        string latestWheelXCombi = "";
        string latestWheelYCombi = "";

        bool prevAlive = false;

        private InputSimulator sim;

        private CircleDialog circleDialog = null;

        ImeController imeController;

        public JoystickController(InputSimulator i, ConfigController cc, CircleDialog cd, ImeController ime)
        {
            sim = i;
            configManager = cc;
            jso.JoystickWrapperEvent += joystickWrapper_JoystickWrapperEventHandler;
            circleDialog = cd;
            imeController = ime;
        }

        /// <summary>
        /// ジョイパッド監視本体
        /// </summary>
        private void dispatch()
        {
            bool currentAlive = isAlive();
            do
            {
                string cur = WindowObserver.GetActiveWindowName();
                if (cur != this.configManager.currentUsingConfig)
                {
                    this.configManager.currentUsingConfig = cur;
                    imeController.CheckImeMode();
                }

                prevAlive = currentAlive;
                currentAlive = isAlive();
                Thread.Sleep(1000 / Value.BASE_FPS);
                if (currentJoystickHoldStatus.ContainsKey("buttons0")) Console.WriteLine(currentJoystickHoldStatus["buttons0"]);
                setCurrentInnerMode();
                dispatchSticks(latestMainpadStatus, latestRotationStatus);
                dispatchButtons(currentJoystickHoldStatus);
                prevAlive = currentAlive;
                copyJoyStatus(this.currentJoystickHoldStatus, ref this.latestJoystickHoldStatus);
            }
            while (currentAlive || prevAlive);
        }

        private bool isAlive()
        {
            bool stickIsAlive = Math.Abs(latestMainpadStatus.x) > 10 || Math.Abs(latestMainpadStatus.y) > 10 || Math.Abs(latestRotationStatus.x) > 10 || Math.Abs(latestRotationStatus.y) > 10;
            bool buttonAlive = false;

            try
            {
                if (!stickIsAlive) foreach (var kvp in currentJoystickHoldStatus)
                {
                    if (kvp.Key != "x_slider" && kvp.Key != "y_slider" && kvp.Key != "x_rotate" && kvp.Key != "y_rotate" && kvp.Value != 0)
                    {
                        buttonAlive = true;
                        break;
                    }
                }
                return stickIsAlive || buttonAlive;
            }
            catch 
            {
                Thread.Sleep(16);
                return isAlive();
            }
        }

        public void Stop()
        {
            jso.Stop();
            thread.Abort();
        }

        private void joystickWrapper_JoystickWrapperEventHandler(object sender, JoystickWrapperEventArg e)
        {
            copyJoyStatus(e.RawJoystickHoldStatus, ref this.currentJoystickHoldStatus);
            copyStickStatus(e.RawMainpadStatus, ref this.latestMainpadStatus);
            copyStickStatus(e.RawRotationStatus, ref this.latestRotationStatus);
            if (thread == null || !thread.IsAlive) 
            {
                thread = new Thread(new ThreadStart(dispatch));
                thread.Start();
            }
        }

        /// <summary>
        /// スティックの情報をコピーします.
        /// </summary>
        private void copyStickStatus(AnalogStickStatus src, ref AnalogStickStatus target)
        {
            target.x = src.x;
            target.y = src.y;
        }

        /// <summary>
        /// ボタンの情報をコピーします.
        /// </summary>
        private void copyJoyStatus(Dictionary<string, int> src, ref Dictionary<string, int> target)
        {
            try
            {
                src = new Dictionary<string, int>(src);
                foreach (var kvp in src)
                {
                    if (!target.ContainsKey(kvp.Key)) target[kvp.Key] = 0;
                    target[kvp.Key] = src[kvp.Key] == 0 ? 0 : target[kvp.Key] + 1;
                    if (target[kvp.Key] > 128)
                    {
                        target[kvp.Key] = 127;
                    }
                }
            }
            catch
            { }
        }

        private void dispatchSticks(AnalogStickStatus rawMainpadStatus, AnalogStickStatus rawRotationStatus)
        {
            ///// Mouse
            int powerX = 0;
            int powerY = 0;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_X && Math.Abs(rawMainpadStatus.x) > this.config.anarogStickThreshold) powerX = rawMainpadStatus.x;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["y_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_X && Math.Abs(rawMainpadStatus.y) > this.config.anarogStickThreshold) powerX = rawMainpadStatus.y;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_X && Math.Abs(rawRotationStatus.x) > this.config.anarogStickThreshold) powerX = rawRotationStatus.x;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["y_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_X && Math.Abs(rawRotationStatus.y) > this.config.anarogStickThreshold) powerX = rawRotationStatus.y;

            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_Y && Math.Abs(rawMainpadStatus.x) > this.config.anarogStickThreshold) powerY = rawMainpadStatus.x;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["y_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_Y && Math.Abs(rawMainpadStatus.y) > this.config.anarogStickThreshold) powerY = rawMainpadStatus.y;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_Y && Math.Abs(rawRotationStatus.x) > this.config.anarogStickThreshold) powerY = rawRotationStatus.x;
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["y_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_MOUSE_Y && Math.Abs(rawRotationStatus.y) > this.config.anarogStickThreshold) powerY = rawRotationStatus.y;
            MoveMouseBy(powerX, powerY);

            ///// Wheel
            int wheelX = 0;
            if (Regex.Match(this.currentInnerMode.keymap["x_slider"], "WHEEL_X").Value.Length != 0 && Math.Abs(rawMainpadStatus.x) > this.config.anarogStickThreshold) { wheelX = calcWheelSpeed(rawMainpadStatus.x); latestWheelXCombi = this.currentInnerMode.keymap["x_slider"]; }
            if (Regex.Match(this.currentInnerMode.keymap["y_slider"], "WHEEL_X").Value.Length != 0 && Math.Abs(rawMainpadStatus.y) > this.config.anarogStickThreshold) { wheelX = calcWheelSpeed(rawMainpadStatus.y); latestWheelXCombi = this.currentInnerMode.keymap["y_slider"]; }
            if (Regex.Match(this.currentInnerMode.keymap["x_rotate"], "WHEEL_X").Value.Length != 0 && Math.Abs(rawRotationStatus.x) > this.config.anarogStickThreshold) { wheelX = calcWheelSpeed(rawRotationStatus.x); latestWheelXCombi = this.currentInnerMode.keymap["x_rotate"]; }
            if (Regex.Match(this.currentInnerMode.keymap["y_rotate"], "WHEEL_X").Value.Length != 0 && Math.Abs(rawRotationStatus.y) > this.config.anarogStickThreshold) { wheelX = calcWheelSpeed(rawRotationStatus.y); latestWheelXCombi = this.currentInnerMode.keymap["y_rotate"]; }

            int wheelY = 0;
            if (Regex.Match(this.currentInnerMode.keymap["x_slider"], "WHEEL_Y").Value.Length != 0 && Math.Abs(rawMainpadStatus.x) > this.config.anarogStickThreshold) { wheelY = calcWheelSpeed(rawMainpadStatus.x); latestWheelYCombi = this.currentInnerMode.keymap["x_slider"]; }
            if (Regex.Match(this.currentInnerMode.keymap["y_slider"], "WHEEL_Y").Value.Length != 0 && Math.Abs(rawMainpadStatus.y) > this.config.anarogStickThreshold) { wheelY = calcWheelSpeed(rawMainpadStatus.y); latestWheelYCombi = this.currentInnerMode.keymap["y_slider"]; }
            if (Regex.Match(this.currentInnerMode.keymap["x_rotate"], "WHEEL_Y").Value.Length != 0 && Math.Abs(rawRotationStatus.x) > this.config.anarogStickThreshold) { wheelY = calcWheelSpeed(rawRotationStatus.x); latestWheelYCombi = this.currentInnerMode.keymap["x_rotate"]; }
            if (Regex.Match(this.currentInnerMode.keymap["y_rotate"], "WHEEL_Y").Value.Length != 0 && Math.Abs(rawRotationStatus.y) > this.config.anarogStickThreshold) { wheelY = calcWheelSpeed(rawRotationStatus.y); latestWheelYCombi = this.currentInnerMode.keymap["y_rotate"]; }

            if (wheelX != 0)
            {
                if (latestWheelX == 0 && wheelY == 0 && latestWheelY == 0)
                {
                    if (Regex.Match(latestWheelXCombi, "V_KEY_SHIFT_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                    if (Regex.Match(latestWheelXCombi, "V_KEY_CTRL_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                    if (Regex.Match(latestWheelXCombi, "V_KEY_ALT_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LMENU);
                    if (Regex.Match(latestWheelXCombi, "V_KEY_SC_WHEEL").Value.Length != 0)
                    {
                        sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                        sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                    }
                }
                if (wheelThresholdX == 0)
                {
                    sim.Mouse.HorizontalScroll(wheelX * (this.currentInnerMode.reverseX ? -1 : 1));
                }
                wheelThresholdX++;
                if (wheelThresholdX >= 4) wheelThresholdX = 0;
            }
            else if (wheelX != latestWheelX)
            {
                if (Regex.Match(latestWheelXCombi, "V_KEY_SHIFT_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                if (Regex.Match(latestWheelXCombi, "V_KEY_CTRL_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                if (Regex.Match(latestWheelXCombi, "V_KEY_ALT_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LMENU);
                if (Regex.Match(latestWheelXCombi, "V_KEY_SC_WHEEL").Value.Length != 0)
                {
                    sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                    sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                }
            }

            if (wheelY != 0)
            {
                if (latestWheelY == 0 && wheelX == 0 && latestWheelX == 0)
                {
                    if (Regex.Match(latestWheelYCombi, "V_KEY_SHIFT_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                    if (Regex.Match(latestWheelYCombi, "V_KEY_CTRL_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                    if (Regex.Match(latestWheelYCombi, "V_KEY_ALT_WHEEL").Value.Length != 0) sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LMENU);
                    if (Regex.Match(latestWheelYCombi, "V_KEY_SC_WHEEL").Value.Length != 0)
                    {
                        sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                        sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                    }
                }
                if (wheelThresholdY == 0)
                {
                    sim.Mouse.VerticalScroll(wheelY * (this.currentInnerMode.reverseY ? -1 : 1));
                }
                wheelThresholdY++;
                if (wheelThresholdY >= 4) wheelThresholdY = 0;
            }
            else if (wheelY != latestWheelY)
            {
                if (Regex.Match(latestWheelYCombi, "V_KEY_SHIFT_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                if (Regex.Match(latestWheelYCombi, "V_KEY_CTRL_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                if (Regex.Match(latestWheelYCombi, "V_KEY_ALT_WHEEL").Value.Length != 0) sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LMENU);
                if (Regex.Match(latestWheelYCombi, "V_KEY_SC_WHEEL").Value.Length != 0)
                {
                    sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
                    sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LSHIFT);
                }
            }
            latestWheelX = wheelX;
            latestWheelY = wheelY;

            /// CircleInput
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_CIRCLE
            && KeyCode.convNameToCode(this.currentInnerMode.keymap["y_slider"]) == (int)KeyCode.CircleVirtualKey.V_KEY_CIRCLE)
            {
                circleDialog.DispatchCircleInput(rawMainpadStatus);
            }
            
            if (KeyCode.convNameToCode(this.currentInnerMode.keymap["x_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_CIRCLE
            && KeyCode.convNameToCode(this.currentInnerMode.keymap["y_rotate"]) == (int)KeyCode.CircleVirtualKey.V_KEY_CIRCLE)
            {
                circleDialog.DispatchCircleInput(rawRotationStatus);
            }
        }
        private int calcWheelSpeed(int power)
        {
            return (int)((power / 100) * (double)(currentInnerMode.wheelSpeed / 10.0));
        }

        private void MoveMouseBy(int powerX, int powerY)
        {
            int px = (int)((powerX / 100) * (double)(currentInnerMode.mouseSpeed / 10.0));
            int py = (int)((powerY / 100) * (double)(currentInnerMode.mouseSpeed / 10.0));
            sim.Mouse.MoveMouseBy(px, py);
        }

        private void dispatchButtons(Dictionary<string, int> rawJoystickHoldStatus)
        {
            try
            {
                rawJoystickHoldStatus = new Dictionary<string, int>(rawJoystickHoldStatus);
                foreach (KeyValuePair<string, int> kvp in rawJoystickHoldStatus)
                {
                    if (this.latestJoystickHoldStatus.ContainsKey(kvp.Key))
                    {
                        if (kvp.Value != 0 && this.latestJoystickHoldStatus[kvp.Key] == 0)
                        {
                            this.pressInModeIdx[kvp.Key] = this.currentInnerModeIdx;
                        }
                        string currentInnerModeKeymap = this.currentInnerMode.keymap.ContainsKey(kvp.Key) ? this.currentInnerMode.keymap[kvp.Key] : "V_KEY_NOTHING";
                        int latestStatus = this.latestJoystickHoldStatus.ContainsKey(kvp.Key) ? this.latestJoystickHoldStatus[kvp.Key] : 0;
                        bool isMultiPurpose = this.config.isMultiPurpose.ContainsKey(kvp.Key) ? this.config.isMultiPurpose[kvp.Key] : false;
                        string pressInModeIdx = this.pressInModeIdx.ContainsKey(kvp.Key) ? this.pressInModeIdx[kvp.Key] : "";
                        ignitionButton(currentInnerModeKeymap, kvp.Value, latestStatus, isMultiPurpose, pressInModeIdx, kvp.Key);
                    }
                }
            }
            catch 
            {
            }
        }

        private void ignitionButton(string currentInnerModeKeymap, int currentStatus, int latestStatus, bool isMultiPurpose, string pressInModeIdx, string currentButtonId)
        {
            if (currentStatus != 0 && latestStatus == 0)
            {
                if (stringIsSingleKey(currentInnerModeKeymap))
                {
                    int code = KeyCode.convNameToCode(currentInnerModeKeymap);
                    if (code > 0xFF)
                    {
                        switch (code)
                        {
                            case (int)KeyCode.CircleVirtualKey.V_KEY_FN_BS:
                            case (int)KeyCode.CircleVirtualKey.V_KEY_FN:
                                On(CircleDispatchCode.Code.FN_KEY);
                                break;
                            case (int)KeyCode.CircleVirtualKey.V_KEY_IN_ENT:
                            case (int)KeyCode.CircleVirtualKey.V_KEY_IN_NE:
                                break;
                        }
                    }

                    if (!isMultiPurpose)
                    {
                        if (code < 7)
                        {
                            switch ((WindowsInput.Native.VirtualKeyCode)code)
                            {
                                case WindowsInput.Native.VirtualKeyCode.LBUTTON: sim.Mouse.LeftButtonDown(); break;
                                case WindowsInput.Native.VirtualKeyCode.RBUTTON: sim.Mouse.RightButtonDown(); break;
                                case WindowsInput.Native.VirtualKeyCode.CANCEL: break;
                                case WindowsInput.Native.VirtualKeyCode.MBUTTON: sim.Mouse.XButtonDown(3); break;
                                case WindowsInput.Native.VirtualKeyCode.XBUTTON1: sim.Mouse.XButtonDown(1); break;
                                case WindowsInput.Native.VirtualKeyCode.XBUTTON2: sim.Mouse.XButtonDown(2); break;
                            }
                        }
                        if (6 < code && code <= 0xFF)
                        {
                            sim.Keyboard.KeyDown((WindowsInput.Native.VirtualKeyCode)code);
                        }
                    }
                }
            }
            if (currentStatus > Value.DIGITAL_BUTTONS_HOLD_THRESHOLD && stringIsSingleKey(currentInnerModeKeymap) && !isMultiPurpose && (pressInModeIdx == this.currentInnerModeIdx || this.currentInnerModeIdx == currentButtonId))
            {
                int code = KeyCode.convNameToCode(currentInnerModeKeymap);
                if (code > 0xFF)
                {
                    // TODO
                }

                if (6 < code && code <= 0xFF)
                {
                    sim.Keyboard.KeyPress((WindowsInput.Native.VirtualKeyCode)code);
                }
            }
            if (currentStatus == 0 && latestStatus != 0)
            {
                if (stringIsSingleKey(currentInnerModeKeymap))
                {
                    int code = KeyCode.convNameToCode(currentInnerModeKeymap);
                    if (code > 0xFF)
                    {
                        switch (code)
                        {
                            case (int)KeyCode.CircleVirtualKey.V_KEY_FN_BS:
                                On(CircleDispatchCode.Code.FN_KEY);
                                break;
                            case (int)KeyCode.CircleVirtualKey.V_KEY_FN:
                                break;
                            case (int)KeyCode.CircleVirtualKey.V_KEY_PRES:
                                On(CircleDispatchCode.Code.PRESET_KEY);
                                break;
                            case (int)KeyCode.CircleVirtualKey.V_KEY_IN_ENT:
                                if (circleDialog.Visible) On(CircleDispatchCode.Code.INPUT_KEY);
                                else
                                {
                                    sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                                }
                                break;
                            case (int)KeyCode.CircleVirtualKey.V_KEY_IN_NE:
                                if (circleDialog.Visible) On(CircleDispatchCode.Code.INPUT_KEY);
                                break;
                        }
                    }
                    if (code <= 0xFF && (pressInModeIdx == this.currentInnerModeIdx || this.currentInnerModeIdx == currentButtonId))
                    {
                        if (isMultiPurpose)
                        {
                            sim.Keyboard.KeyPress((WindowsInput.Native.VirtualKeyCode)code);
                        }
                        else
                        {
                            if (code < 7)
                            {
                                switch ((WindowsInput.Native.VirtualKeyCode)code)
                                {
                                    case WindowsInput.Native.VirtualKeyCode.LBUTTON: sim.Mouse.LeftButtonUp(); break;
                                    case WindowsInput.Native.VirtualKeyCode.RBUTTON: sim.Mouse.RightButtonUp(); break;
                                    case WindowsInput.Native.VirtualKeyCode.CANCEL: break;
                                    case WindowsInput.Native.VirtualKeyCode.MBUTTON: sim.Mouse.XButtonUp(3); break;
                                    case WindowsInput.Native.VirtualKeyCode.XBUTTON1: sim.Mouse.XButtonUp(1); break;
                                    case WindowsInput.Native.VirtualKeyCode.XBUTTON2: sim.Mouse.XButtonUp(2); break;
                                }
                            }
                            else
                            {
                                sim.Keyboard.KeyUp((WindowsInput.Native.VirtualKeyCode)code);
                            }
                        }

                    }
                }
                else
                {
                    AutoHotKeyUtil.CallAhkFromScript(currentInnerModeKeymap);
                }
            }
        }
        private bool stringIsSingleKey(string str)
        {
            string[] arr = str.Split('\n');
            if (arr.Length != 1) return false;

            Match matche = Regex.Match(str, "^[a-zA-Z0-9_]+$");

            return matche.Value.Length == 0 ? false : true;
        }

        /// <summary>
        /// 同時押しモードを制御します。
        /// </summary>
        private void setCurrentInnerMode()
        {
            if (currentInnerModeIdx != "none" && isAlive() == false)
            {
                currentInnerModeIdx = "none";
                return;
            }
            if (currentInnerModeIdx != "none") return;

            try
            {
                var cj = new Dictionary<string, int>(currentJoystickHoldStatus);
                foreach (var kvp in cj)
                {
                    if (kvp.Key != "x_slider" && kvp.Key != "y_slider" && kvp.Key != "x_rotate" && kvp.Key != "y_rotate" && kvp.Value > 1)
                    {
                        currentInnerModeIdx = kvp.Key;
                        break;
                    }
                }
            }
            catch { };
        }
    }
}
