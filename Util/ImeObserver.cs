using System;
using System.Runtime.InteropServices;

namespace CircleInput2
{
    /// <summary>
    /// IMEモードの取得を行います。
    /// </summary>
    static class ImeObserver
    {
        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("imm32.dll")]
        static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "GetGUIThreadInfo", CallingConvention = CallingConvention.Winapi)]
        static extern uint GetGUIThreadInfo(uint dwthreadid, ref GUITHREADINFO lpguithreadinfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct GUITHREADINFO
        {
            public int cbSize;
            public int flags;
            public IntPtr hwndActive;
            public IntPtr hwndFocus;
            public IntPtr hwndCapture;
            public IntPtr hwndMenuOwner;
            public IntPtr hwndMoveSize;
            public IntPtr hwndCaret;
            public System.Drawing.Rectangle rcCaret;
        }

        const int WM_IME_CONTROL = 0x283;
        const int IMC_GETCONVERSIONMODE = 1;
        const int IMC_SETCONVERSIONMODE = 2;
        const int IMC_GETOPENSTATUS = 5;
        const int IMC_SETOPENSTATUS = 6;

        const int IME_CMODE_NATIVE = 1;
        const int IME_CMODE_KATAKANA = 2;
        const int IME_CMODE_FULLSHAPE = 8;
        const int IME_CMODE_ROMAN = 16;

        const int CMode_HankakuKana = IME_CMODE_ROMAN | IME_CMODE_KATAKANA | IME_CMODE_NATIVE;
        const int CMode_ZenkakuEisu = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE;
        const int CMode_Hiragana = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE | IME_CMODE_NATIVE;
        const int CMode_ZenkakuKana = IME_CMODE_ROMAN | IME_CMODE_FULLSHAPE | IME_CMODE_KATAKANA | IME_CMODE_NATIVE;

        /// <summary>
        /// IMEが有効であるかを問い合わせます。
        /// </summary>
        static public bool IsImeEnabled()
        {
            // IME状態の取得
            GUITHREADINFO gti = new GUITHREADINFO();
            gti.cbSize = Marshal.SizeOf(gti);

            uint result = GetGUIThreadInfo(0, ref gti);
            if (result == 0)
            {
                Console.WriteLine("GetGUIThreadInfo failed");
                throw new System.ComponentModel.Win32Exception(); // 2019.8.21追記:まれにここに来てしまう場合あるようなので throw せずに return; させたほうがよいかも
            }
            IntPtr imwd = ImmGetDefaultIMEWnd(gti.hwndFocus);

            int imeConvMode = SendMessage(imwd, WM_IME_CONTROL, (IntPtr)IMC_GETCONVERSIONMODE, IntPtr.Zero);
            bool imeEnabled = (SendMessage(imwd, WM_IME_CONTROL, (IntPtr)IMC_GETOPENSTATUS, IntPtr.Zero) != 0);
            return imeEnabled;
        }
    }
}
