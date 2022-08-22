using System.Runtime.InteropServices;

namespace CircleInput2
{
    static class AutoHotKeyUtil
    {
        [DllImport(
            "AutoHotkey.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode,
            EntryPoint = "ahkdll"
        )]
        private static extern int ahkdll(
            [MarshalAs(UnmanagedType.LPWStr)] string scriptFilePath,
            [MarshalAs(UnmanagedType.LPWStr)] string parameters = "",
            [MarshalAs(UnmanagedType.LPWStr)] string title = ""
        );

        [DllImport(
            "AutoHotkey.dll",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Unicode,
            EntryPoint = "ahktextdll"
        )]
        private static extern int ahktextdll(
            [MarshalAs(UnmanagedType.LPWStr)] string script,
            [MarshalAs(UnmanagedType.LPWStr)] string parameters = "",
            [MarshalAs(UnmanagedType.LPWStr)] string title = ""
        );

        /// <summary>
        /// AHKを呼び出します。(スクリプト直指定)
        /// </summary>
        /// <param name="script">AHKが実行するコマンド列</param>
        /// <param name="parameters">AHKの引数</param>
        /// <param name="title">実効するAHKのタイトル</param>
        /// <returns></returns>
        public static int CallAhkFromScript(string script, string parameters = "", string title = "")
        {
            try
            {
                return ahktextdll(script, parameters, title);
            }
            catch
            {
                AHKError form = new AHKError();
                form.ShowDialog();
            }
            return -1;
        }

        /// <summary>
        /// AHKを呼び出します。(ファイル指定)
        /// </summary>
        /// <param name="script">AHKが実行するファイル名</param>
        /// <param name="parameters">AHKの引数</param>
        /// <param name="title">実効するAHKのタイトル</param>
        /// <returns></returns>
        public static int CallAhkFromFile(string filePath, string parameters = "", string title = "")
        {
            try
            {
                return ahkdll(filePath, parameters, title);
            }
            catch
            {
                AHKError form = new AHKError();
                form.ShowDialog();
            }
            return -1;
        }
    }
}
