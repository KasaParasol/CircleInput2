using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using WindowsInput;

namespace CircleInput2
{
    /// <summary>
    /// 文字列などを入力する円形のウィンドウ
    /// </summary>
    public partial class CircleDialog : Form
    {
        /// <summary>
        /// 設定を管理します。
        /// </summary>
        ConfigController configManager;

        /// <summary>
        /// ウィンドウを表示する期間の長さ(frame)
        /// </summary>
        public const int ANIMATE_FRAME = 60 * 1;/* sec */

        public const int CIRCLE_DISP_FRAME = 60 * 5;

        /// <summary>
        /// ウィンドウの透過を管理します。
        /// </summary>
        int showframe = 0;

        int latestWindowX = 0;
        int latestWindowY = 0;
        double latestOpacity = 0;

        Form form;

        Thread windowThread;

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
        /// 現在のサークルプリセット番号
        /// </summary>
        int circlePreset
        {
            get
            {
                return this.configManager.currentCirclePreset;
            }
            set
            {
                this.configManager.currentCirclePreset = value;
            }
        }

        /// <summary>
        /// 現在のサークルページ番号
        /// </summary>
        List<int> circlePage
        {
            get
            {
                return this.configManager.circlePage;
            }
            set
            {
                this.configManager.circlePage = value;
            }
        }

        /// <summary>
        /// 現在のサークル選択番号
        /// </summary>
        List<int> circleSelect = new List<int>{};

        /// <summary>
        /// 現在のサークルサブ番号
        /// </summary>
        List<int> circleAlt = new List<int>{ -1 };

        ConfigMainDialog configForm = new ConfigMainDialog();
        Author aboutForm = new Author();

        List<CircleItem> currentDisp {
            get {
                List<CircleItem> master = currentInnerMode.circlePresets[this.circlePreset].circleItem;

                if (circlePage.Count == 1) return master;
                if (circleSelect.Count == 1 && circleAlt[0] == -1) return master[circleSelect[0]].innerItems;
                if (circleSelect.Count == 1 && circleAlt[0] > -1) return master[circleSelect[0]].subInnerItems[circleAlt[0]];
                else return new List<CircleItem> { };
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
        /// (0: none(入力なし), 1-128: ボタン, 129: Up, 130: Down, 131: Left, 132: Right, 133: Z+, 134: Z-, 135: Sticks)
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

        /// <summary>
        /// 単キーまたはマウスの操作を行います。
        /// </summary>
        InputSimulator sim;

        ImeController imeController;
        int imeHandlerEnable = 0;

        bool subItemsCircleActive = false;

        CircleItem activeCircleItem;
        int activeCircleItemIdx;

        /// <summary>
        /// このダイアログはフォーカスを取得しない
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }

        public CircleDialog(InputSimulator i, ConfigController cc, ImeController ime)
        {
            form = this;
            InitializeComponent();

            sim = i;
            configManager = cc;
            imeController = ime;
            imeController.ImeToggleEvent += ImeChanged;

            int currentime = 2;
            try
            {
                currentime = ImeObserver.IsImeEnabled() ? 1 : 0;
            }
            catch
            {
            }

            if (currentime == 0 && (this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 1))
            {
                procPreset();
            }
            else if (currentime == 1 && (this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 0))
            {
                procPreset();
            }

            Show();
            createNotifyIcon();

            var threadParameters = new ThreadStart(delegate { manageWindow(); });
            windowThread = new Thread(threadParameters);
            windowThread.Start();

            Opacity = 0;
        }

        private void createNotifyIcon()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            notifyIcon1.ContextMenuStrip = contextMenuStrip;

            // コンテキストメニュー「Configure」を追加
            ToolStripMenuItem configure = createToolStripMenuItem("&Configure", ToolStripMenuItem_Configure);
            contextMenuStrip.Items.Add(configure);

            // コンテキストメニュー「About」を追加
            ToolStripMenuItem about = createToolStripMenuItem("&About", ToolStripMenuItem_About);
            contextMenuStrip.Items.Add(about);

            // コンテキストメニュー「Exit」を追加
            ToolStripMenuItem exit = createToolStripMenuItem("&Exit", ToolStripMenuItem_Exit);
            contextMenuStrip.Items.Add(exit);
        }

        private void manageWindow()
        {
            int wait = 1000 / 60;

            while (true)
            {
                // CPUがフル稼働しないようにFPSの制限をかける
                // ※簡易的に、おおよそ秒間120フレーム程度に制限
                Thread.Sleep(wait);

                int lx = latestWindowX;
                int ly = latestWindowY;
                double lo = latestOpacity;
                calcWindowProperty();

                if (lx != latestWindowX || ly != latestWindowY || lo != latestOpacity)
                {
                    ApplyWindowProperty();
                }
                if (imeHandlerEnable > 0) imeHandlerEnable--;
            }
        }

        private void ApplyWindowProperty()
        {
            if (form.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeAttach = delegate { ApplyWindowProperty(); };
                form.Invoke(safeAttach);
            }
            else
            {
                Left = latestWindowX;
                Top = latestWindowY;
                Opacity = latestOpacity;
            }
        }

        private void ImeChanged(object sender, bool e)
        {
            if (imeHandlerEnable > 0) return;
            
            if (e == true && this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 0)
            {
                for (int i = 0; i < this.currentInnerMode.circlePresets.Count; i++)
                {
                    if (this.currentInnerMode.circlePresets[i].usingIme == 1)
                    {
                        if (this.circlePage.Count != 1)
                        {
                            this.circlePage.RemoveAt(this.circlePage.Count - 1);
                            if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);
                        }
                        this.circlePage[this.circlePage.Count - 1] = 0;
                        this.circlePreset = i;
                        break;
                    }
                }
            }
            else if (this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 1)
            {
                for (int i = 0; i < this.currentInnerMode.circlePresets.Count; i++)
                {
                    if (this.currentInnerMode.circlePresets[i].usingIme == 0)
                    {
                        if (this.circlePage.Count != 1)
                        {
                            this.circlePage.RemoveAt(this.circlePage.Count - 1);
                            if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);
                        }
                        this.circlePage[this.circlePage.Count - 1] = 0;
                        this.circlePreset = i;
                        break;
                    }
                }
            }
        }

        public void DispatchVirtualKey(object sender, JoystickController.DispatchCircleEventArg arg)
        {
            switch (arg.DispatchID) {
                case CircleDispatchCode.Code.FN_BS_KEY:
                    if (subItemsCircleActive)
                    {
                        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.BACK);
                        subItemsCircleActive = false;
                        circleAlt[0] = -1;
                    }
                    break;
                case CircleDispatchCode.Code.PRESET_KEY:
                    procPreset();
                    break;
                case CircleDispatchCode.Code.INPUT_ENTER_KEY:
                    if (this.activeCircleItem != null) dispatchCircle();
                    else
                    {
                        sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                    }
                    subItemsCircleActive = false;
                    circleAlt[0] = -1;
                    break;
                case CircleDispatchCode.Code.INPUT_KEY:
                    if (this.activeCircleItem != null) dispatchCircle();
                    else
                    {
                        if (this.circlePage.Count != 1)
                        {
                            this.circlePage.RemoveAt(this.circlePage.Count - 1);
                            if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);
                        }
                        else
                        {
                            this.circlePage[this.circlePage.Count - 1]++;
                            if (currentDisp.Count <= this.circlePage[this.circlePage.Count - 1] * this.currentInnerMode.circleItemCount)
                            {
                                this.circlePage[this.circlePage.Count - 1] = 0;
                            }
                        }

                    }
                    subItemsCircleActive = false;
                    circleAlt[0] = -1;
                    break;
            }

            setCurrentInnerMode();
            var threadParameters = new ThreadStart(delegate { changeCircleLabel(); });
            var thread2 = new Thread(threadParameters);
            thread2.Start();
        }

        public void DispatchCircleInput(AnalogStickStatus status) 
        {
            changeCircleLabel();
            int toople = radiusToCircleIndex(status.radius);
            changeCircleActiveDisp(status.topple > 300, toople);
        }

        private ToolStripMenuItem createToolStripMenuItem(string title, EventHandler handler)
        {
            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Text = title;
            toolStripMenuItem.Click += handler;

            return toolStripMenuItem;
        }

        private void ToolStripMenuItem_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem_About(object sender, EventArgs e)
        {
            if (!aboutForm.Visible) {
                aboutForm.ShowDialog();
            }
        }

        private void ToolStripMenuItem_Configure(object sender, EventArgs e)
        {
            if (!configForm.Visible) {
                var result = configForm.ShowDialog();
                if (System.Windows.Forms.DialogResult.OK == result)
                {
                    // 設定リロード
                    configList = ConfigLoader.LoadConfig();

                }
            }
            
        }

        /// <summary>
        /// ウィンドウのプロパティを計算します。
        /// </summary>
        private void calcWindowProperty()
        {
            if (showframe == 0)
            {
                latestOpacity = 0;
                return;
            }
            else if (showframe <= ANIMATE_FRAME)
            {
                latestOpacity = ((double)showframe / ANIMATE_FRAME) * 0.9;
            }
            else if (showframe > ANIMATE_FRAME)
            {
                latestOpacity = 0.9;
            }
            showframe--;

            int mouseX = System.Windows.Forms.Cursor.Position.X;
            int mouseY = System.Windows.Forms.Cursor.Position.Y;
            latestWindowX = mouseX + 3;
            latestWindowY = mouseY + 3;
        }

        // TODO: D2Dで置き換えるかも
        /// <summary>
        /// サークルインプットのアイテム番号を表示に反映します。
        /// </summary>
        /// <param name="toople"></param>
        /// <param name="idx"></param>
        private void changeCircleActiveDisp(bool toople, int idx)
        {
            activeCircleItemIdx = -1;
            this.activeCircleItem = null;
            Label[] circleLabels = new Label[] {
                label_circle_9,
                label_circle_10,
                label_circle_11,
                label_circle_12,
                label_circle_1,
                label_circle_2,
                label_circle_3,
                label_circle_4,
                label_circle_5,
                label_circle_6,
                label_circle_7,
                label_circle_8
            };
            foreach (Label circleLabel in circleLabels)
            {
                circleLabel.ForeColor = Color.FromArgb(0, 222, 222, 222);
            }
            if (toople)
            {
                if (circleAlt[0] != -1) {
                    this.subItemsCircleActive = true;
                }
                activeCircleItemIdx = currentDisp.Count > this.circlePage.Last() * currentInnerMode.circleItemCount + idx ? this.circlePage.Last() * currentInnerMode.circleItemCount + idx : -1;
                if (activeCircleItemIdx != -1) 
                {
                    activeCircleItem = currentDisp[activeCircleItemIdx];
                }
                circleLabels[idx].ForeColor = Color.Red;
                this.showframe = CIRCLE_DISP_FRAME;
            }

        }

        /// <summary>
        /// アナログパッドのラジウス値からサークルインプットのアイテム番号を計算します。
        /// </summary>
        /// <param name="radius"></param>
        private int radiusToCircleIndex(double radius)
        {
            double step = 360 / this.currentInnerMode.circleItemCount;// TODO
            double degree = (radius * 180d / Math.PI) + 180d;

            if (degree < step / 2 || degree > (360 - (step / 2))) 
            {
                return 0;
            }
            for (int i = 1; i < this.currentInnerMode.circleItemCount - 1; i++)
            {
                if (degree > (step / 2) + (step * (i - 1)) && degree <= (step / 2) + (step * i))
                {
                    return i;
                }
            }
            return this.currentInnerMode.circleItemCount - 1;
        }

        private void changeCircleLabel()
        {
            Label[] circleLabels = new Label[] {
                label_circle_9,
                label_circle_10,
                label_circle_11,
                label_circle_12,
                label_circle_1,
                label_circle_2,
                label_circle_3,
                label_circle_4,
                label_circle_5,
                label_circle_6,
                label_circle_7,
                label_circle_8
            };

            CircleInputPreset preset = currentInnerMode.circlePresets[this.circlePreset];
            setLabelText(label_pres, preset.presetName);

            for (int l = 0; l < circleLabels.Length; l++)
            {
                int i = l + (this.circlePage.Last() * currentInnerMode.circleItemCount);
                setLabelText(circleLabels[l], i < currentDisp.Count ? currentDisp[i].label : "");
            }
        }

        private void setLabelText(Label target, string text)
        {
            if (target.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { setLabelText(target, text); };
                target.Invoke(safeWrite);
            }
            else
                target.Text = text;
        }

        /// <summary>
        /// 同時押しモードを制御します。
        /// </summary>
        private void setCurrentInnerMode()
        {
            if (currentInnerMode.circlePresets.Count == 0)
            {
                currentInnerMode.circlePresets.Add(new CircleInputPreset()
                {
                    presetName = "",
                    circleItem = new List<CircleItem>(),
                    usingIme = 2
                });
            }

            if (currentInnerMode.circlePresets.Count <= this.circlePreset)
            {
                if (this.circlePage.Count != 1)
                {
                    this.circlePage.RemoveAt(this.circlePage.Count - 1);
                    if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);

                }
                this.circlePage[this.circlePage.Count - 1] = 0;
                this.circleAlt[this.circleAlt.Count - 1] = -1;
                this.circlePreset = 0;
            }
            else if (circleSelect.Count == 1 && currentInnerMode.circlePresets[this.circlePreset].circleItem.Count < circleSelect[0])
            {
                if (this.circlePage.Count != 1)
                {
                    this.circlePage.RemoveAt(this.circlePage.Count - 1);
                    if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);

                }
                this.circlePage[this.circlePage.Count - 1] = 0;
                this.circleAlt[this.circleAlt.Count - 1] = -1;
                this.circlePreset = 0;
            }
            else if (circleSelect.Count == 1 && circleAlt[0] > -1 && currentInnerMode.circlePresets[this.circlePreset].circleItem[circleSelect[0]].subInnerItems.Count > circleAlt[0])
            {
                if (this.circlePage.Count != 1)
                {
                    this.circlePage.RemoveAt(this.circlePage.Count - 1);
                    if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);

                }
                this.circlePage[this.circlePage.Count - 1] = 0;
                this.circleAlt[this.circleAlt.Count - 1] = -1;
                this.circlePreset = 0;
            }
        }

        private void procPreset()
        {
            imeHandlerEnable = 5;
            if (this.circlePage.Count != 1)
            {
                this.circlePage.RemoveAt(this.circlePage.Count - 1);
                if (this.circleSelect.Count != 0) this.circleSelect.RemoveAt(this.circleSelect.Count - 1);
            }
            this.circlePage[this.circlePage.Count - 1] = 0;
            this.circlePreset++;
            if (this.circlePreset > this.currentInnerMode.circlePresets.Count - 1)
            {
                this.circlePreset = 0;
            }

            int currentime = 2;
            try
            {
                currentime = ImeObserver.IsImeEnabled() ? 1 : 0;
            }
            catch
            {
            }

            if (currentime == 0 && (this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 1))
            {
                if (!imeController.SetImeMode(true))
                {
                    procPreset();
                }
            }
            else if (currentime == 1 && (this.currentInnerMode.circlePresets[this.circlePreset].usingIme == 0))
            {
                imeController.SetImeMode(false);
            }
        }

        private bool stringIsSingleKey(string str) {
            string[] arr = str.Split('\n');
            if (arr.Length != 1) return false;

            Match matche = Regex.Match(str, "^[a-zA-Z0-9_]+$");

            return matche.Value.Length == 0 ? false : true;
        }

        private void dispatchCircle()
        {
            switch (activeCircleItem.role) {
                case 1:
                    this.circlePage.Add(0);
                    this.circleSelect.Add(activeCircleItemIdx);
                    break;
                case 2:
                    if (activeCircleItem.usingIme == 0)
                    {
                        imeController.SetImeMode(false);
                    }
                    else if (activeCircleItem.usingIme == 1) {
                        imeController.SetImeMode(true);
                    }
                    if (stringIsSingleKey(activeCircleItem.dispatch))
                    {
                        int code = KeyCode.convNameToCode(activeCircleItem.dispatch);
                        if (6 < code && code <= 0xFF) sim.Keyboard.KeyPress((WindowsInput.Native.VirtualKeyCode)code);
                    }
                    else if (!stringIsSingleKey(activeCircleItem.dispatch))
                    {
                        AutoHotKeyUtil.CallAhkFromScript(activeCircleItem.dispatch);
                    }
                    break;
                case 3:
                    Clipboard.SetText(activeCircleItem.dispatch);
                    sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
                    sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_V);
                    sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
                    break;
            }
        }

        private void CircleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            windowThread.Abort();
            Application.Exit();
        }
    }
}
