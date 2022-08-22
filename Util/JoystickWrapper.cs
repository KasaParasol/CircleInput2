using System;
using System.Collections.Generic;

namespace CircleInput2
{
    public class JoystickWrapper
    {
        #region JoyStickEvent
        public class JoystickWrapperEventArg : EventArgs
        {
            /// <summary>
            /// メインスティックの倒れ具合。
            /// </summary>
            public AnalogStickStatus RawMainpadStatus { get; }

            /// <summary>
            /// サブスティックの倒れ具合。
            /// </summary>
            public AnalogStickStatus RawRotationStatus { get; }

            /// <summary>
            /// ジョイスティックの各ボタンが入力されているか、X-Yスライダ・ローテートはここでは使わない。
            /// </summary>
            public Dictionary<string, int> RawJoystickHoldStatus { get; }

        public JoystickWrapperEventArg(AnalogStickStatus rawMainpadStatus, AnalogStickStatus rawRotationStatus, Dictionary<string, int> rawJoystickHoldStatus)
            {
                RawMainpadStatus = new AnalogStickStatus (rawMainpadStatus);
                RawRotationStatus = new AnalogStickStatus(rawRotationStatus);
                RawJoystickHoldStatus = new Dictionary<string, int>(rawJoystickHoldStatus);
            }
        }
        public delegate void JoystickWrapperEventHandler(object sender, JoystickWrapperEventArg e);
        public event JoystickWrapperEventHandler JoystickWrapperEvent;

        protected void On(AnalogStickStatus rawMainpadStatus, AnalogStickStatus rawRotationStatus, Dictionary<string, int> rawJoystickHoldStatus)
        {
            JoystickWrapperEvent?.Invoke(this, new JoystickWrapperEventArg(rawMainpadStatus, rawRotationStatus, rawJoystickHoldStatus));
        }
        #endregion

        /// <summary>
        /// ジョイスティックを監視するオブザーバ
        /// </summary>
        private JoyStickObserver jso = new JoyStickObserver();

        /// <summary>
        /// メインスティックの倒れ具合。
        /// </summary>
        public AnalogStickStatus rawMainpadStatus;

        /// <summary>
        /// サブスティックの倒れ具合。
        /// </summary>
        public AnalogStickStatus rawRotationStatus;

        /// <summary>
        /// ジョイスティックの各ボタンが何フレーム連続入力されているか、X-Yスライダ・ローテートはここでは使わない。
        /// </summary>
        public Dictionary<string, int> rawJoystickHoldStatus = new Dictionary<string, int>();

        public JoystickWrapper() 
        {
            jso.JoyStickEvent += joyStickObserver_JoyStickEvent;
        }

        /// <summary>
        /// 監視を完全に停止します。
        /// </summary>
        public void Stop()
        {
            jso.Stop();
        }

        /// <summary>
        /// 監視を再開します。
        /// </summary>
        public void Restart()
        {
            jso.Restart();
        }

        /// <summary>
        /// ジョイスティックの操作を受け取るイベントハンドラ
        /// </summary>
        private void joyStickObserver_JoyStickEvent(object sender, JoyStickObserver.JoyStickEventArg e)
        {
            foreach (var state in e.Status)
            {
                string configName = PhysicalButtonAssociationUtil.GetConfigName(state).Key;

                if (configName == "x_slider")
                {
                    this.rawMainpadStatus.x = state.Value;
                    break;
                }
                if (configName == "y_slider")
                {
                    this.rawMainpadStatus.y = state.Value;
                    break;
                }
                if (configName == "x_rotate")
                {
                    this.rawRotationStatus.x = state.Value;
                    break;
                }
                if (configName == "y_rotate")
                {
                    this.rawRotationStatus.y = state.Value;
                    break;
                }

                if (configName == "_pov")
                {
                    if (!rawJoystickHoldStatus.ContainsKey("arrow_top"))
                    {
                        this.rawJoystickHoldStatus["arrow_top"] = 0;
                        this.rawJoystickHoldStatus["arrow_right"] = 0;
                        this.rawJoystickHoldStatus["arrow_left"] = 0;
                        this.rawJoystickHoldStatus["arrow_bottom"] = 0;
                    }
                    // POVキー(↑)
                    if ((state.Value >= 0 && state.Value < 9000) || state.Value > 27000)
                    {
                        this.rawJoystickHoldStatus["arrow_top"] = 1;
                    }
                    else
                    {
                        this.rawJoystickHoldStatus["arrow_top"] = 0;
                    }

                    // POVキー(→)
                    if (state.Value > 0 && state.Value < 18000)
                    {
                        this.rawJoystickHoldStatus["arrow_right"] = 1;
                    }
                    else
                    {
                        this.rawJoystickHoldStatus["arrow_right"] = 0;
                    }

                    // POVキー(↓)
                    if (state.Value > 9000 && state.Value < 27000)
                    {
                        this.rawJoystickHoldStatus["arrow_bottom"] = 1;
                    }
                    else
                    {
                        this.rawJoystickHoldStatus["arrow_bottom"] = 0;
                    }

                    // POVキー(←)
                    if (state.Value > 18000)
                    {
                        this.rawJoystickHoldStatus["arrow_left"] = 1;
                    }
                    else
                    {
                        this.rawJoystickHoldStatus["arrow_left"] = 0;
                    }
                    break;
                }
                if (configName == "z_minus")
                {
                    this.rawJoystickHoldStatus["z_minus"] = Math.Abs(state.Value) > 500? 1: 0;
                    if (this.rawJoystickHoldStatus.ContainsKey("z_plus") && this.rawJoystickHoldStatus["z_plus"] == 1) this.rawJoystickHoldStatus["z_plus"] = 0;
                    break;
                }
                if (configName == "z_plus")
                {
                    this.rawJoystickHoldStatus["z_plus"] = Math.Abs(state.Value) > 500 ? 1 : 0;
                    if (this.rawJoystickHoldStatus.ContainsKey("z_minus") && this.rawJoystickHoldStatus["z_minus"] == 1) this.rawJoystickHoldStatus["z_minus"] = 0;
                    break;
                }


                if (!rawJoystickHoldStatus.ContainsKey(configName))
                {
                    this.rawJoystickHoldStatus[configName] = 0;
                }
                this.rawJoystickHoldStatus[configName] = state.Value == 0 ? 0 : 1;
            }
            On(rawMainpadStatus, rawRotationStatus, rawJoystickHoldStatus);
        }
    }
}
