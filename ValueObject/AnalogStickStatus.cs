using System;

namespace CircleInput2
{
    public struct AnalogStickStatus
    {
        /// <summary>
        /// X軸の傾き(-1000 - 1000)
        /// </summary>
        public int x;

        /// <summary>
        /// Y軸の傾き(-1000 - 1000)
        /// </summary>
        public int y;

        /// <summary>
        /// (READONLY) 傾きの強さ
        /// </summary>
        public int topple
        {
            get
            {
                return (Math.Abs(this.x) + Math.Abs(this.y)) / 2;
            }
        }

        /// <summary>
        /// (READONLY) 傾けているラジアン角度
        /// </summary>
        public double radius
        {
            get
            {
                return Math.Atan2(this.y, this.x);
            }
        }

        public AnalogStickStatus(AnalogStickStatus orig) {
            x = orig.x;
            y = orig.y;
        }
    }
}
