using System.Collections.Generic;

namespace CircleInput2
{
    /// <summary>
    /// プリセットごとの設定値
    /// </summary>
    public class Config
    {
        /// <summary>
        /// スティック傾き判定のしきい値
        /// </summary>
        public int anarogStickThreshold { get; set; }

        /// <summary>
        /// Zスライダーの倒した判定しきい値
        /// </summary>
        public int zSliderThreshold { get; set; }

        /// <summary>
        /// 同時押しでモードが変わるボタンか
        /// </summary>
        public Dictionary<string, bool> isMultiPurpose { get; set; }

        /// <summary>
        /// モード親
        /// </summary>
        public Dictionary<string, Mode> modes { get; set; }
    }

    /// <summary>
    /// 各モードごとの設定値
    /// </summary>
    public class Mode
    {
        /// <summary>
        /// 各ボタンや軸の割当
        /// </summary>
        public Dictionary<string, string> keymap { get; set; }

        /// <summary>
        /// Xホイールの反転
        /// </summary>
        public bool reverseX { get; set; }

        /// <summary>
        /// Yホイールの反転
        /// </summary>
        public bool reverseY { get; set; }

        /// <summary>
        /// CircleInputを利用する場合、1サークルのアイテム数
        /// 4 / 8 / 12
        /// </summary>
        public int circleItemCount { get; set; }

        /// <summary>
        /// ホイール速度
        /// </summary>
        public int wheelSpeed { get; set; }

        /// <summary>
        /// マウス速度
        /// </summary>
        public int mouseSpeed { get; set; }

        public List<CircleInputPreset> circlePresets { get; set; }
    }

    /// <summary>
    /// サークルインプットのプリセット
    /// </summary>
    public class CircleInputPreset
    {
        /// <summary>
        /// プリセット名
        /// </summary>
        public string presetName { get; set; }

        /// <summary>
        /// アイテム列。
        /// </summary>
        public List<CircleItem> circleItem { get; set; }

        /// <summary>
        /// サークルグループのIME指定。必須の場合、IMEが変更できない場合はこのモードへ遷移することができなくなります。(スキップ)
        /// (0: 禁止 / 1: 必須 / 2: 変更しない)
        /// </summary>
        public int usingIme { get; set; }

        /// <summary>
        /// プリセット切り替えキーで移行できる(非ビルトインプリセット)
        /// </summary>
        public bool enumeration { get; set; }
    }

    public class CircleItem
    {
        /// <summary>
        /// サークルアイテムのラベル
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// アイテムのロール
        /// (0: 無効(ブランク) / 1: アイテムグループ / 2: マクロキー入力 / 3: 文字列転送)
        /// </summary>
        public int role { get; set; }

        /// <summary>
        /// ロールが1の場合のみ1階層だけ子要素を含むことができます。
        /// </summary>
        public List<CircleItem> innerItems { get; set; }

        /// <summary>
        /// ロールが1の場合のみ子要素を含むことができます。
        /// </summary>
        public List<List<CircleItem>> subInnerItems { get; set; }

        /// <summary>
        /// ロールが1以外の場合、入力される文字またはマクロキー
        /// </summary>
        public string dispatch { get; set; }

        /// <summary>
        /// 2: マクロキー入力の場合かつ、サークルグループがIMEの利用を行える場合、IMEの指定ができます。
        /// (0: 禁止 / 1: 必須 / 2: 変更しない)
        /// </summary>
        public int usingIme { get; set; }
    }
}
