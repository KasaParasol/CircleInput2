namespace CircleInput2
{
    /// <summary>
    /// 定数クラス
    /// </summary>
    static class Value
    {
        /// <summary>
        /// FPS
        /// </summary>
        public const int BASE_FPS = 120;

        /// <summary>
        /// ボタンのロングプレス判定しきい値(単位: フレーム)
        /// </summary>
        public const int DIGITAL_BUTTONS_HOLD_THRESHOLD = 5;

        /// <summary>
        /// 同時押しモードしきい値(単位: フレーム)
        /// </summary>
        public const int INNER_MODE_CHANGE_THRESHOLD = 3;
    }
}
