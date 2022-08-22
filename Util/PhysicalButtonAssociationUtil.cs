using SharpDX.DirectInput;
using System;
using System.Collections.Generic;

namespace CircleInput2
{
    /// <summary>
    /// 物理キーの状態から設定ファイル上のボタン名に変換します。
    /// </summary>
    static class PhysicalButtonAssociationUtil
    {
        /// <summary>
        /// JoystickUpdate.Offset と 設定値名を紐づける(直接紐づけ可能なもののみ)
        /// </summary>
        static public Dictionary<string, string> map = new Dictionary<string, string>()
        {
            {"RotationX", "x_rotate"},
            {"RotationY", "y_rotate"},
            {"X", "x_slider"},
            {"Y", "y_slider"},
        };

        /// <summary>
        /// Zスライダーの倒した判定しきい値
        /// </summary>
        static public int ZSliderThreshold = 600;

        static private int lastZ = 0;

        static public KeyValuePair<string, int> GetConfigName(JoystickUpdate data)
        {
            var phy = data.Offset.ToString();
            if (map.ContainsKey(phy)) 
            {
                return new KeyValuePair<string, int>(map[phy], data.Value);
            }
            if (phy.IndexOf("Buttons") == 0)
            {
                return new KeyValuePair<string, int>(phy.Replace("Buttons", "buttons"), data.Value);
            }
            if (phy.IndexOf("PointOfViewControllers0") == 0)
            {
                return new KeyValuePair<string, int>("_pov", data.Value);
            }
            if (phy == "Z") 
            {
                if (Math.Abs(data.Value) > ZSliderThreshold)
                {
                    if (data.Value < 0)
                    {
                        lastZ = data.Value;
                        return new KeyValuePair<string, int>("z_minus", data.Value);
                    }
                    if (data.Value > 0)
                    {
                        lastZ = data.Value;
                        return new KeyValuePair<string, int>("z_plus", data.Value);
                    }
                }
                
                int last = lastZ;
                lastZ = 0;
                return new KeyValuePair<string, int>(last > 0? "z_plus": "z_minus", 0);


            }
            return new KeyValuePair<string, int>(phy, data.Value);
        }
    }
}
