using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CircleInput2
{
    static class WindowObserver
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        /// <summary>
        /// アクティブウィンドウのプロセス名を取得します。
        /// </summary>
        static public string GetActiveWindowName()
        {
            IntPtr hWnd = GetForegroundWindow();
            int id;
            GetWindowThreadProcessId(hWnd, out id);
            return Process.GetProcessById(id).ProcessName;
        }

        static public Process GetActuveWindowProcess()
        {
            IntPtr hWnd = GetForegroundWindow();
            int id;
            GetWindowThreadProcessId(hWnd, out id);
            return Process.GetProcessById(id);
        }
    }
}
