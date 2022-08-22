using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class ConfigMainDialog : Form
    {
        Dictionary<string, Config> configList;
        Config config;
        Mode imc;
        bool addMode = false;

        public ConfigMainDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 設定済みのアプリケーションの一覧を表示します
        /// </summary>
        private void dispConfigList()
        {
            combo_Application.Items.Clear();
            foreach (var item in configList.Keys)
            {
                combo_Application.Items.Add(item);
            }
            combo_Application.SelectedItem = "*";
            dispCombination();
        }

        /// <summary>
        /// 適用ボタンを押して設定を保存します。
        /// </summary>
        private void button_Apply_Click(object sender, EventArgs e)
        {
            string CONFIG_FILE_NAME = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\configure.json";
            try
            {
                using (FileStream fs = File.Create(CONFIG_FILE_NAME))
                {
                    string jsonString = JsonSerializer.Serialize(configList);
                    byte[] info = new UTF8Encoding(true).GetBytes(jsonString);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch
            {
                throw;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        /// <summary>
        /// アプリケーションプリセットの選択変更
        /// </summary>
        private void combo_Application_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!addMode)
            {
                // TODO: 保存処理

                if (combo_Application.SelectedItem.ToString() == "*")
                {
                    button_RemoveApplication.Enabled = false;
                }
                else
                {
                    button_RemoveApplication.Enabled = true;
                }
                config = configList[combo_Application.SelectedItem.ToString()];

                dispCombination();
            }
        }

        /// <summary>
        /// プロセスの一覧を表示します。
        /// </summary>
        private void dispProcessList()
        {
            combo_Application.Items.Clear();
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Length != 0)
                {
                    // プロセス名(string)
                    combo_Application.Items.Add(p.ProcessName);
                }
            }
        }

        private void button_AddApplication_Click(object sender, EventArgs e)
        {
            addMode = !addMode;
            button_RemoveApplication.Text = addMode ? "×" : "-";
            button_RemoveApplication.Enabled = true;

            if (!addMode)
            {
                var select = combo_Application.SelectedItem.ToString();

                if (configList.ContainsKey(select))
                {
                    // TODO: 保存処理
                }
                else
                {
                    config = ConfigLoader.LoadConfig()["*"];
                    configList.Add(select, config);
                }
                dispConfigList();
                combo_Application.SelectedItem = select;
            }
            else
            {
                dispProcessList();
                combo_Application.DroppedDown = true;
            }
        }

        private void button_RemoveApplication_Click(object sender, EventArgs e)
        {
            if (!addMode && combo_Application.SelectedItem.ToString() == "*") return;

            if (addMode)
            {
                addMode = false;
                button_RemoveApplication.Text = addMode ? "×" : "-";
                dispConfigList();
            }
            else
            {
                if (MessageBox.Show("すべての子要素が削除されます。よろしいですか？", "確認", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) {
                    configList.Remove(combo_Application.SelectedItem.ToString());
                    dispConfigList();

                    config = configList[combo_Application.SelectedItem.ToString()];
                }
            }
        }

        private void button_Button_Click(object sender, EventArgs e)
        {
            string value = "";
            switch (((Button)sender).Name) {
                case "button_PovLeft": value = imc.keymap["arrow_left"]; break;
                case "button_PovRight": value = imc.keymap["arrow_right"]; break;
                case "button_PovUp": value = imc.keymap["arrow_top"]; break;
                case "button_PovDown": value = imc.keymap["arrow_bottom"]; break;
                case "button_ZPlus": value = imc.keymap["z_plus"]; break;
                case "button_ZMinus": value = imc.keymap["z_minus"]; break;
                case "button_ST": value = imc.keymap["buttons7"]; break;
                case "button_BK": value = imc.keymap["buttons6"]; break;
                case "button_RP": value = imc.keymap["buttons9"]; break;
                case "button_LP": value = imc.keymap["buttons8"]; break;
                case "button_L": value = imc.keymap["buttons5"]; break;
                case "button_R": value = imc.keymap["buttons4"]; break;
                case "button_Y": value = imc.keymap["buttons3"]; break;
                case "button_X": value = imc.keymap["buttons2"]; break;
                case "button_B": value = imc.keymap["buttons1"]; break;
                case "button_A": value = imc.keymap["buttons0"]; break;
            }
            ButtonConfigInput form = new ButtonConfigInput(value);
            form.ShowDialog();
            switch (((Button)sender).Name)
            {
                case "button_PovLeft":  imc.keymap["arrow_left"]   = form.Value; break;
                case "button_PovRight": imc.keymap["arrow_right"]  = form.Value; break;
                case "button_PovUp":    imc.keymap["arrow_top"]    = form.Value; break;
                case "button_PovDown":  imc.keymap["arrow_bottom"] = form.Value; break;
                case "button_ZPlus":    imc.keymap["z_plus"]       = form.Value; break;
                case "button_ZMinus":   imc.keymap["z_minus"]      = form.Value; break;
                case "button_ST":       imc.keymap["buttons7"]   = form.Value; break;
                case "button_BK":       imc.keymap["buttons6"]   = form.Value; break;
                case "button_RP":       imc.keymap["buttons9"]   = form.Value; break;
                case "button_LP":       imc.keymap["buttons8"]   = form.Value; break;
                case "button_L":        imc.keymap["buttons5"]   = form.Value; break;
                case "button_R":        imc.keymap["buttons4"]   = form.Value; break;
                case "button_Y":        imc.keymap["buttons3"]   = form.Value; break;
                case "button_X":        imc.keymap["buttons2"]   = form.Value; break;
                case "button_B":        imc.keymap["buttons1"]   = form.Value; break;
                case "button_A":        imc.keymap["buttons0"]   = form.Value; break;
            }
            displayButtonTitle();
        }

        private void dispCombination()
        {
            combo_Combination.Items.Clear();
            combo_Combination.Items.Add("None");
            if (config.isMultiPurpose["arrow_top"])    combo_Combination.Items.Add("Pov-Up");
            if (config.isMultiPurpose["arrow_bottom"]) combo_Combination.Items.Add("Pov-Down");
            if (config.isMultiPurpose["arrow_left"])   combo_Combination.Items.Add("Pov-Left");
            if (config.isMultiPurpose["arrow_right"])  combo_Combination.Items.Add("Pov-Right");

            if (config.isMultiPurpose["z_minus"]) combo_Combination.Items.Add("Z -");
            if (config.isMultiPurpose["z_plus"]) combo_Combination.Items.Add("Z +");

            string[] buttonDict= new string[] {"A", "B", "X", "Y", "R", "L", "Back", "Start", "L-Axis", "R-Axis"};

            Dictionary<string, bool> buttons = config.isMultiPurpose.Where(x => x.Key.StartsWith("buttons")).ToDictionary(x => x.Key, x => x.Value);
            int i = 0;
            foreach (KeyValuePair<string, bool> kvp in buttons)
            {
                if (kvp.Value) 
                {
                    string title = (i < buttonDict.Length ? buttonDict[i] : "Additional") + " Button@" + (i + 1).ToString();
                    combo_Combination.Items.Add(title);
                }
                i++;
                
            }
            combo_Combination.SelectedIndex = 0;
        }

        private void button_Axis_Click(object sender, EventArgs e)
        {
            StickConfigInput form = new StickConfigInput(imc, ((Button)sender).Name, config.anarogStickThreshold);
            form.ShowDialog();
            config.anarogStickThreshold = form.AnarogStickThreshold;
        }

        private void combo_Combination_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mode = combo_Combination.SelectedItem.ToString();
            switch (mode)
            {
                case "None": imc = config.modes["none"]; break;
                case "Pov-Up": imc = config.modes["arrow_top"]; break;
                case "Pov-Down": imc = config.modes["arrow_bottom"]; break;
                case "Pov-Left": imc = config.modes["arrow_left"]; break;
                case "Pov-Right": imc = config.modes["arrow_right"]; break;
                case "Z -": imc = config.modes["z_minus"]; break;
                case "Z +": imc = config.modes["z_plus"]; break;
                default:
                    var strs = mode.Split('@');
                    if (strs.Length == 2) {
                        try
                        {
                            imc = config.modes["buttons" + (Int32.Parse(strs[1]) - 1).ToString()];
                        }
                        catch { }
                    }
                    break;
            }
            displayButtonTitle();
        }

        private void button_Combi_Click(object sender, EventArgs e)
        {
            MultiPurposeConfigure form = new MultiPurposeConfigure(config.isMultiPurpose);
            form.ShowDialog();

            config.isMultiPurpose = form.Value;
            dispCombination();
        }

        private void check_View_CheckedChanged(object sender, EventArgs e)
        {
            displayButtonTitle();
        }

        private void displayButtonTitle()
        {
            if (!check_View.Checked)
            {
                button_PovUp.Text = "↑";
                button_PovDown.Text = "↓";
                button_PovLeft.Text = "←";
                button_PovRight.Text = "→";
                button_ZMinus.Text = "Z -";
                button_ZPlus.Text = "Z +";
                button_A.Text = "A (1)";
                button_B.Text = "B (2)";
                button_X.Text = "X (3)";
                button_Y.Text = "Y (4)";
                button_R.Text = "R (5)";
                button_L.Text = "L (6)";
                button_BK.Text = "Back (7)";
                button_ST.Text = "Start (8)";
                button_LP.Text = "LAxis-Press (9)";
                button_RP.Text = "RAxis-Press (10)";
                button_LAxis.Text = "LAxis";
                button_RAxis.Text = "RAxis";
            }
            else
            {
                button_PovUp.Text = imc.keymap["arrow_top"];
                button_PovDown.Text = imc.keymap["arrow_bottom"];
                button_PovLeft.Text = imc.keymap["arrow_left"];
                button_PovRight.Text = imc.keymap["arrow_right"];
                button_ZMinus.Text = imc.keymap["z_minus"];
                button_ZPlus.Text = imc.keymap["z_plus"];
                button_A.Text = imc.keymap["buttons0"];
                button_B.Text = imc.keymap["buttons1"];
                button_X.Text = imc.keymap["buttons2"];
                button_Y.Text = imc.keymap["buttons3"];
                button_R.Text = imc.keymap["buttons4"];
                button_L.Text = imc.keymap["buttons5"];
                button_BK.Text = imc.keymap["buttons6"];
                button_ST.Text = imc.keymap["buttons7"];
                button_LP.Text = imc.keymap["buttons8"];
                button_RP.Text = imc.keymap["buttons9"];
                button_LAxis.Text = "(Detail)";
                button_RAxis.Text = "(Detail)";
            }
        }

        private void button_Other_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> buttons = imc.keymap.Where(x => x.Key.StartsWith("buttons")).ToDictionary(x => x.Key, x => x.Value);
            string[] vals = new string[buttons.Values.Count];
            buttons.Values.CopyTo(vals, 0);
            AdditionalButtonDialog form = new AdditionalButtonDialog(vals);
            form.ShowDialog();
            int i = 0;
            foreach (KeyValuePair<string, string> kvp in buttons) 
            {
                if (i >= form.Value.Length) break;
                imc.keymap[kvp.Key] = form.Value[i];
                i++;

            }
            displayButtonTitle();
        }

        private void ConfigMainDialog_Load(object sender, EventArgs e)
        {
            configList = ConfigLoader.LoadConfig();
            config = configList["*"];

            dispConfigList();
        }
    }
}
