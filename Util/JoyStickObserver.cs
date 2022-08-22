using System;
using System.Threading;
using SharpDX.DirectInput;

namespace CircleInput2
{
    class JoyStickObserver
    {
        #region JoyStickEvent
        public class JoyStickEventArg : EventArgs
        {
            public JoystickUpdate[] Status { get; }

            public JoyStickEventArg(JoystickUpdate[] status)
            {
                Status = status;
            }
        }
        public delegate void JoyStickEventHandler(object sender, JoyStickEventArg e);
        public event JoyStickEventHandler JoyStickEvent;

        protected void On(JoystickUpdate[] status)
        {
            JoyStickEvent?.Invoke(this, new JoyStickEventArg(status));
        }
        #endregion

        /// <summary>
        /// 監視中フラグ(制御用)
        /// </summary>
        private bool observeFlag = true;

        /// <summary>
        /// (物理)ジョイスティック
        /// </summary>
        public Joystick joystick = null;

        /// <summary>
        /// 監視スレッド
        /// </summary>
        Thread thread = null;

        public JoyStickObserver()
        {
            observe();
        }

        /// <summary>
        /// 監視を完全に停止します。
        /// </summary>
        public void Stop() 
        {
            observeFlag = false;
            thread.Join();
            // TODO: ジョイパッドのClose
        }

        /// <summary>
        /// 監視を再開します。
        /// </summary>
        public void Restart() 
        {
            if (!thread.IsAlive && observeFlag == false) 
            {
                observeFlag = true;
                observe();
            }
        }

        /// <summary>
        /// 別スレッドを生成し、ジョイパッドを監視します。
        /// </summary>
        private void observe ()
        {
            thread = new Thread(new ThreadStart(observeJoystick));
            thread.Start();
        }

        /// <summary>
        /// ジョイパッド監視本体
        /// </summary>
        private void observeJoystick() 
        {

            while (observeFlag) 
            {
                Thread.Sleep(1000 / Value.BASE_FPS);

                if (joystick == null)
                {
                    initialize();
                    continue;
                }

                joystick.Poll();
                var datas = joystick.GetBufferedData();

                if (datas.Length != 0) 
                {
                    this.On(datas);
                }
            }
        }

        /// <summary>
        /// ジョイパッド初期化
        /// </summary>
        private void initialize()
        {
            var dinput = new DirectInput();
            var joystickGuid = Guid.Empty;

            // FPSコントローラーからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.FirstPerson, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }
            // ゲームパッドからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }
            // ジョイスティックからゲームパッドを取得する
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance device in dinput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = device.InstanceGuid;
                    break;
                }
            }

            if (joystickGuid == Guid.Empty)
            {
                // ジョイスティックは発見できなかった
                return;
            }

            this.joystick = new Joystick(dinput, joystickGuid);

            if (this.joystick == null)
            {
                return;
            }

            // バッファサイズを指定
            this.joystick.Properties.BufferSize = 128;

            // 相対軸・絶対軸の最小値と最大値を
            // 指定した値の範囲に設定する
            foreach (DeviceObjectInstance deviceObject in this.joystick.GetObjects())
            {
                switch (deviceObject.ObjectId.Flags)
                {
                    case DeviceObjectTypeFlags.Axis:
                    // 絶対軸or相対軸
                    case DeviceObjectTypeFlags.AbsoluteAxis:
                    // 絶対軸
                    case DeviceObjectTypeFlags.RelativeAxis:
                        // 相対軸
                        var ir = this.joystick.GetObjectPropertiesById(deviceObject.ObjectId);
                        if (ir != null)
                        {
                            try
                            {
                                ir.Range = new InputRange(-1000, 1000);
                            }
                            catch (Exception) { }
                        }
                        break;
                }
            }
            joystick.Acquire();
        }
    }
}
