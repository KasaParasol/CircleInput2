using System.Collections.Generic;

namespace CircleInput2
{
    public class ConfigController
    {
        /// <summary>
        /// プリセットごとの設定値
        /// </summary>
        Dictionary<string, Config> _configList;
        public Dictionary<string, Config> configList
        {
            get
            {
                return this._configList;
            }
            set
            {
                this._configList = value;
                this._currentUsingConfig = "*";
            }
        }

        /// <summary>
        /// 現在利用中のConfig
        /// </summary>
        string _currentUsingConfig = "*";
        public string currentUsingConfig
        {
            get
            {
                return this._currentUsingConfig;
            }
            set
            {
                string cur = value;
                string next = this.configList.ContainsKey(cur) ? cur : "*";

                if (this._currentUsingConfig != next)
                {
                    this._currentUsingConfig = next;
                    this.StartButton = "none";
                    this.currentCirclePreset = 0;
                    this._circlePage = new List<int> { 0 };
                }
            }
        }

        string startButton = "none";

        public string StartButton
        {
            get
            {
                return this.startButton;
            }
            set
            {
                bool isPossible = config.isMultiPurpose.ContainsKey(value) ? config.isMultiPurpose[value]: false;

                string next = isPossible ? value : "none";
                if (this.startButton != next && (config.modes[this.startButton].circlePresets.Count != config.modes[next].circlePresets.Count || config.modes[this.startButton].circlePresets[this.currentCirclePreset].presetName != config.modes[next].circlePresets[this.currentCirclePreset].presetName) )
                {
                    this.currentCirclePreset = 0;
                }
                this.startButton = next;
            }
        }

        /// <summary>
        /// 現在のプリセットの設定値
        /// </summary>
        public Config config
        {
            get
            {
                return this._configList[this._currentUsingConfig];
            }
        }

        /// <summary>
        /// 現在の同時押しモード
        /// </summary>
        public Mode currentInnerMode
        {
            get
            {
                Mode imc = config.modes[this.startButton];

                if (imc.circlePresets.Count == 0)
                {
                    imc.circlePresets.Add(new CircleInputPreset()
                    {
                        presetName = "",
                        circleItem = new List<CircleItem>(),
                        usingIme = 2
                    });
                }
                return imc;
            }
        }

        /// <summary>
        /// 現在のサークルプリセット番号
        /// </summary>
        int _currentCirclePreset;
        public int currentCirclePreset
        {
            get
            {
                return this._currentCirclePreset;
            }
            set
            {
                if (value != this._currentCirclePreset)
                {
                    this._circlePage = new List<int> { 0 };
                }
                this._currentCirclePreset = value;
            }
        }

        /// <summary>
        /// 現在のサークルページ番号
        /// </summary>
        List<int> _circlePage = new List<int> { 0 };
        public List<int> circlePage
        {
            get
            {
                return this._circlePage;
            }
            set
            {
                this._circlePage = value;
            }
        }
    }
}
