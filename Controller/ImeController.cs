using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace CircleInput2
{
    public class ImeController
    {
        const int KEY_CODE_EISU = 240;
        const int KEY_CODE_KANA = 242;
        const int KEY_CODE_ESC = 243;
        const int KEY_CODE_HANZEN = 244;

        #region ImeEvent
        public delegate void ImeEventHandler(object sender, bool e);
        public event ImeEventHandler ImeToggleEvent;

        protected void OnImeToggleEvent(bool enable)
        {
            ImeToggleEvent?.Invoke(this, enable);
            this.latestImeMode = enable;
        }
        #endregion

        /// <summary>
        /// キーボードシュミレータ
        /// </summary>
        InputSimulator simulator;

        /// <summary>
        /// キーボード監視
        /// </summary>
        KeyboardObserver keyboardObserver = new KeyboardObserver();

        /// <summary>
        /// 最後に確認したIMEモード
        /// </summary>
        bool latestImeMode = false;

        public ImeController(InputSimulator sim)
        {
            this.simulator = sim;
            keyboardObserver.KeyDownEvent += keyboardObserver_KeyDownEvent;
            keyboardObserver.Hook();
            try
            {
                latestImeMode = ImeObserver.IsImeEnabled();
            }
            catch { }
        }

        /// <summary>
        /// 半／全キーを押下することでIMEモードを切り替えます。
        /// </summary>
        /// <param name="enable">有効化</param>
        /// <returns>成功(true)・失敗</returns>
        public bool SetImeMode(bool enable)
        {
            try
            {
                if (ImeObserver.IsImeEnabled() != enable)
                {
                    this.simulator.Keyboard.KeyPress(VirtualKeyCode.KANJI);
                    Thread.Sleep(16);
                    if (enable && ImeObserver.IsImeEnabled() != enable)
                    {
                        return false;
                    }
                    else if (ImeObserver.IsImeEnabled() != enable)
                    {
                        return SetImeMode(enable);
                    }
                    OnImeToggleEvent(ImeObserver.IsImeEnabled());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// IMEの有効・無効状態を確認して、切り替えタイミングでイベントを発砲します。
        /// </summary>
        public void CheckImeMode()
        {
            try
            {
                if (this.latestImeMode != ImeObserver.IsImeEnabled())
                {
                    OnImeToggleEvent(ImeObserver.IsImeEnabled());
                }
            }
            catch { }
        }

        /// <summary>
        /// keyboardObserverでIMEに関係するキーの押下状態を監視します。
        /// </summary>
        private void keyboardObserver_KeyDownEvent(object sender, KeyboardObserver.OriginalKeyEventArg e)
        {
            if (e.KeyCode == KEY_CODE_EISU
            || e.KeyCode == KEY_CODE_KANA
            || e.KeyCode == KEY_CODE_ESC
            || e.KeyCode == KEY_CODE_HANZEN)
            {
                CheckImeMode();
            }
        }

        ~ImeController()
        {
            keyboardObserver.UnHook();
        }
    }
}
