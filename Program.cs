using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput;

namespace CircleInput2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InputSimulator sim = new InputSimulator();

            ConfigMainDialog configForm = new ConfigMainDialog();

            ConfigController cc = new ConfigController();
            bool isExists = ConfigLoader.IsExists();
            cc.configList = ConfigLoader.LoadConfig();
            if (cc.currentInnerMode.circlePresets.Count == 0)
            {
                cc.currentInnerMode.circlePresets.Add(new CircleInputPreset()
                {
                    presetName = "",
                    circleItem = new List<CircleItem>(),
                    usingIme = 2
                });
            }
            if (!isExists)
            {
                var result = configForm.ShowDialog();
                if (System.Windows.Forms.DialogResult.OK == result)
                {
                    // 設定リロード
                    cc.configList = ConfigLoader.LoadConfig();

                }
            }

            ImeController imeController = new ImeController(sim);

            CircleDialog circleDialog = new CircleDialog(sim, cc, imeController);
            var joystickController = new JoystickController(sim, cc, circleDialog, imeController);
            joystickController.DispatchCircleEvent += circleDialog.DispatchVirtualKey;
            circleDialog.FormClosing += (sender, e) => { joystickController.Stop(); };

            Application.Run(circleDialog);
        }
    }
}
