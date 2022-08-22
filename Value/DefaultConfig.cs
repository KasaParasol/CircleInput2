using System.Collections.Generic;

namespace CircleInput2
{
    public class DefaultConfig
    {
        public static Config defaultConfig
        {
            get
            {
                return new Config()
                {
                    anarogStickThreshold = 300,
                    zSliderThreshold = 600,
                    isMultiPurpose = new Dictionary<string, bool>()
                    {
                        {"z_minus", false},
                        {"z_plus", true},
                        {"buttons0", false},
                        {"buttons1", false},
                        {"buttons2", false},
                        {"buttons3", false},
                        {"buttons4", false},
                        {"buttons5", false},
                        {"buttons6", false},
                        {"buttons7", false},
                        {"buttons8", false},
                        {"buttons9", false},
                        {"buttons10", false},
                        {"buttons11", false},
                        {"buttons12", false},
                        {"buttons13", false},
                        {"buttons14", false},
                        {"buttons15", false},
                        {"arrow_top", false},
                        {"arrow_bottom", false},
                        {"arrow_left", false},
                        {"arrow_right", false},
                        {"x_slider", false},
                        {"y_slider", false},
                        {"x_rotate", false},
                        {"y_rotate",false},
                    },
                    modes = new Dictionary<string, Mode>()
                    {
                        { "none", DefaultConfig.defaultMode },
                        { "z_minus", DefaultConfig.defaultMode },
                        { "z_plus", new Mode(){
                            circleItemCount = 12,
                            keymap = new Dictionary<string, string>()
                            {
                                {"z_minus", "ESC" },
                                {"z_plus","V_KEY_FN"},
                                {"buttons0", "BACK" },
                                {"buttons1", "V_KEY_IN_ENT" },
                                {"buttons2", "TAB" },
                                {"buttons3", "LWIN" },
                                {"buttons4", "LCONTROL" },
                                {"buttons5", "LSHIFT" },
                                {"buttons6", "V_KEY_PRES" },
                                {"buttons7", "LMENU" },
                                {"buttons8", "V_KEY_IN_NE" },
                                {"buttons9", "RBUTTON" },
                                {"buttons10", "V_KEY_NOTHING"},
                                {"buttons11", "V_KEY_NOTHING"},
                                {"buttons12", "V_KEY_NOTHING"},
                                {"buttons13", "V_KEY_NOTHING"},
                                {"buttons14", "V_KEY_NOTHING"},
                                {"buttons15", "V_KEY_NOTHING" },
                                {"arrow_top", "UP" },
                                {"arrow_bottom", "DOWN" },
                                {"arrow_left", "LEFT" },
                                {"arrow_right", "RIGHT" },
                                {"x_slider", "V_KEY_CIRCLE" },
                                {"y_slider", "V_KEY_CIRCLE" },
                                {"x_rotate", "V_KEY_MOUSE_X" },
                                {"y_rotate", "V_KEY_MOUSE_Y" }
                            },
                            reverseX = false,
                            reverseY = true,
                            wheelSpeed = 1,
                            mouseSpeed = 12,
                            circlePresets = new List<CircleInputPreset> { fnKey }
                        }},
                        {"buttons0" ,DefaultConfig.defaultMode},
                        {"buttons1" ,DefaultConfig.defaultMode},
                        {"buttons2" ,DefaultConfig.defaultMode},
                        {"buttons3" ,DefaultConfig.defaultMode},
                        {"buttons4" ,DefaultConfig.defaultMode},
                        {"buttons5" ,DefaultConfig.defaultMode},
                        {"buttons6" ,DefaultConfig.defaultMode},
                        {"buttons7" ,DefaultConfig.defaultMode},
                        {"buttons8" ,DefaultConfig.defaultMode},
                        {"buttons9" ,DefaultConfig.defaultMode},
                        {"buttons10" ,DefaultConfig.defaultMode},
                        {"buttons11" ,DefaultConfig.defaultMode},
                        {"buttons12" ,DefaultConfig.defaultMode},
                        {"buttons13" ,DefaultConfig.defaultMode},
                        {"buttons14" ,DefaultConfig.defaultMode},
                        {"buttons15" ,DefaultConfig.defaultMode},
                        {"arrow_top", DefaultConfig.defaultMode },
                        {"arrow_bottom",  DefaultConfig.defaultMode },
                        {"arrow_left", DefaultConfig.defaultMode },
                        {"arrow_right",  DefaultConfig.defaultMode },
                    }
                };
            }
        }

        public static Mode defaultMode
        {
            get
            {
                return new Mode()
                {
                    circleItemCount = 12,
                    keymap = new Dictionary<string, string>()
                    {
                        {"z_minus", "ESC" },
                        {"z_plus", "V_KEY_FN" },
                        {"buttons0", "BACK" },
                        {"buttons1", "V_KEY_IN_ENT" },
                        {"buttons2", "TAB" },
                        {"buttons3", "LWIN" },
                        {"buttons4", "LCONTROL" },
                        {"buttons5", "LSHIFT" },
                        {"buttons6", "V_KEY_PRES" },
                        {"buttons7", "LMENU" },
                        {"buttons8", "V_KEY_IN_NE" },
                        {"buttons9", "LBUTTON" },
                        {"buttons10", "V_KEY_NOTHING"},
                        {"buttons11", "V_KEY_NOTHING"},
                        {"buttons12", "V_KEY_NOTHING"},
                        {"buttons13", "V_KEY_NOTHING"},
                        {"buttons14", "V_KEY_NOTHING"},
                        {"buttons15", "V_KEY_NOTHING" },
                        {"arrow_top", "UP" },
                        {"arrow_bottom", "DOWN" },
                        {"arrow_left", "LEFT" },
                        {"arrow_right", "RIGHT" },
                        {"x_slider", "V_KEY_CIRCLE" },
                        {"y_slider", "V_KEY_CIRCLE" },
                        {"x_rotate", "V_KEY_MOUSE_X" },
                        {"y_rotate", "V_KEY_MOUSE_Y" },
                    },
                    reverseX = false,
                    reverseY = true,
                    wheelSpeed = 1,
                    mouseSpeed = 12,
                    circlePresets = DefaultConfig.defaultCirclePresets
                };
            }
        }

        public static List<CircleInputPreset> defaultCirclePresets
        {
            get
            {
                return new List<CircleInputPreset> {
                    new CircleInputPreset()
                    {
                        presetName = "あ",
                        usingIme = 1,
                        circleItem = new List<CircleItem> {
                            new CircleItem() { label = "あ", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "あ", role = 2, usingIme = 1, dispatch = "VK_A", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "い", role = 2, usingIme = 1, dispatch = "VK_I", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "う", role = 2, usingIme = 1, dispatch = "VK_U", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "え", role = 2, usingIme = 1, dispatch = "VK_E", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "お", role = 2, usingIme = 1, dispatch = "VK_O", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "ぁ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぃ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぅ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぇ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぉ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                },
                                new List<CircleItem>{
                                    new CircleItem() { label = "あ゙", role = 2, usingIme = 1, dispatch = "Send, a\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "い゙", role = 2, usingIme = 1, dispatch = "Send, i\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ゔ", role = 2, usingIme = 1, dispatch = "Send, v\r\nSend, u\r\n"         , innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "え゙", role = 2, usingIme = 1, dispatch = "Send, e\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "お゙", role = 2, usingIme = 1, dispatch = "Send, o\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            }},
                            new CircleItem() { label = "か", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "か", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "き", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "く", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "け", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "こ", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "が", role = 2, usingIme = 1, dispatch = "Send, g\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぎ", role = 2, usingIme = 1, dispatch = "Send, g\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぐ", role = 2, usingIme = 1, dispatch = "Send, g\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "げ", role = 2, usingIme = 1, dispatch = "Send, g\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ご", role = 2, usingIme = 1, dispatch = "Send, g\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                },
                                 new List<CircleItem>{
                                    new CircleItem() { label = "ヵ", role = 2, usingIme = 1, dispatch = "Send, x\r\nSend, k\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "き", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "く", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ヶ", role = 2, usingIme = 1, dispatch = "Send, x\r\nSend, k\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "こ", role = 2, usingIme = 1, dispatch = "Send, k\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "さ", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "さ", role = 2, usingIme = 1, dispatch = "Send, s\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "し", role = 2, usingIme = 1, dispatch = "Send, s\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "す", role = 2, usingIme = 1, dispatch = "Send, s\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "せ", role = 2, usingIme = 1, dispatch = "Send, s\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "そ", role = 2, usingIme = 1, dispatch = "Send, s\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "ざ", role = 2, usingIme = 1, dispatch = "Send, z\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "じ", role = 2, usingIme = 1, dispatch = "Send, z\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ず", role = 2, usingIme = 1, dispatch = "Send, z\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぜ", role = 2, usingIme = 1, dispatch = "Send, z\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぞ", role = 2, usingIme = 1, dispatch = "Send, z\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "た", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "た", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ち", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "つ", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "て", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "と", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "だ", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぢ", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "づ", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "で", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ど", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                },
                                 new List<CircleItem>{
                                    new CircleItem() { label = "た", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ち", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "っ", role = 2, usingIme = 1, dispatch = "Send, x\r\nSend, t\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "て", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "と", role = 2, usingIme = 1, dispatch = "Send, t\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "な", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "な", role = 2, usingIme = 1, dispatch = "Send, n\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "に", role = 2, usingIme = 1, dispatch = "Send, n\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ぬ", role = 2, usingIme = 1, dispatch = "Send, n\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ね", role = 2, usingIme = 1, dispatch = "Send, n\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "の", role = 2, usingIme = 1, dispatch = "Send, n\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{}
                            } },
                            new CircleItem() { label = "は", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "は", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ひ", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ふ", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "へ", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ほ", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "ば", role = 2, usingIme = 1, dispatch = "Send, b\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "び", role = 2, usingIme = 1, dispatch = "Send, b\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぶ", role = 2, usingIme = 1, dispatch = "Send, b\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "べ", role = 2, usingIme = 1, dispatch = "Send, b\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぼ", role = 2, usingIme = 1, dispatch = "Send, b\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                },
                                 new List<CircleItem>{
                                    new CircleItem() { label = "ぱ", role = 2, usingIme = 1, dispatch = "Send, p\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぴ", role = 2, usingIme = 1, dispatch = "Send, p\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぷ", role = 2, usingIme = 1, dispatch = "Send, p\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぺ", role = 2, usingIme = 1, dispatch = "Send, p\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぽ", role = 2, usingIme = 1, dispatch = "Send, p\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "ま", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "ま", role = 2, usingIme = 1, dispatch = "Send, m\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "み", role = 2, usingIme = 1, dispatch = "Send, m\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "む", role = 2, usingIme = 1, dispatch = "Send, m\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "め", role = 2, usingIme = 1, dispatch = "Send, m\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "も", role = 2, usingIme = 1, dispatch = "Send, m\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{}
                            } },
                            new CircleItem() { label = "や", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "や", role = 2, usingIme = 1, dispatch = "Send, y\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ゐ", role = 2, usingIme = 1, dispatch = "Send, y\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ゆ", role = 2, usingIme = 1, dispatch = "Send, y\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ゑ", role = 2, usingIme = 1, dispatch = "Send, y\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "よ", role = 2, usingIme = 1, dispatch = "Send, y\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "ゃ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, y\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぃ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, y\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ゅ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, y\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ぇ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, y\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ょ", role = 2, usingIme = 1, dispatch = "Send, l\r\nSend, y\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "ら", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "ら", role = 2, usingIme = 1, dispatch = "Send, r\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "り", role = 2, usingIme = 1, dispatch = "Send, r\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "る", role = 2, usingIme = 1, dispatch = "Send, r\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "れ", role = 2, usingIme = 1, dispatch = "Send, r\r\nSend, e\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ろ", role = 2, usingIme = 1, dispatch = "Send, r\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{}
                            } },
                            new CircleItem() { label = "わ", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "わ", role = 2, usingIme = 1, dispatch = "Send, w\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "を", role = 2, usingIme = 1, dispatch = "Send, w\r\nSend, i\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ん", role = 2, usingIme = 1, dispatch = "Send, w\r\nSend, u\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "ー", role = 2, usingIme = 1, dispatch = "OEM_MINUS", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "、", role = 2, usingIme = 1, dispatch = "OEM_COMMA", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "。", role = 2, usingIme = 1, dispatch = "OEM_PERIOD", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "濁", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "半", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{
                                new List<CircleItem>{
                                    new CircleItem() { label = "ゎ", role = 2, usingIme = 1, dispatch = "Send, x\r\nSend, w\r\nSend, a\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "を゙", role = 2, usingIme = 1, dispatch = "Send, w\r\nSend, i\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ん゙", role = 2, usingIme = 1, dispatch = "Send, w\r\nSend, u\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "ー", role = 2, usingIme = 1, dispatch = "OEM_MINUS", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "、", role = 2, usingIme = 1, dispatch = "OEM_COMMA", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "。", role = 2, usingIme = 1, dispatch = "OEM_PERIOD", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "濁", role = 2, usingIme = 1, dispatch = "Send, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                    new CircleItem() { label = "半", role = 2, usingIme = 1, dispatch = "Send, h\r\nSend, d\r\nSend, k\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                }
                            } },
                            new CircleItem() { label = "数", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "0", role = 2, usingIme = 0, dispatch = "VK_0", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "1", role = 2, usingIme = 0, dispatch = "VK_1", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "2", role = 2, usingIme = 0, dispatch = "VK_2", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "3", role = 2, usingIme = 0, dispatch = "VK_3", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "4", role = 2, usingIme = 0, dispatch = "VK_4", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "5", role = 2, usingIme = 0, dispatch = "VK_5", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "6", role = 2, usingIme = 0, dispatch = "VK_6", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "7", role = 2, usingIme = 0, dispatch = "VK_7", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "8", role = 2, usingIme = 0, dispatch = "VK_8", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "9", role = 2, usingIme = 0, dispatch = "VK_9", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "-", role = 2, usingIme = 0, dispatch = "OEM_MINUS", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = ".", role = 2, usingIme = 0, dispatch = "OEM_PERIOD", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "記", role = 1, usingIme = 1, dispatch = "", innerItems = new List<CircleItem>{
                                new CircleItem() { label = "😀", role = 2, usingIme = 1, dispatch = "Send, @\r\nSend, k\r\nSend, a\r\nSend, o\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = ";", role = 2, usingIme = 1, dispatch = "OEM_PLUS", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = ":", role = 2, usingIme = 1, dispatch = "OEM_1", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "/", role = 2, usingIme = 1, dispatch = "OEM_2", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "@", role = 2, usingIme = 1, dispatch = "OEM_3", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "[", role = 2, usingIme = 1, dispatch = "OEM_4", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "]", role = 2, usingIme = 1, dispatch = "OEM_6", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "\\ |", role = 2, usingIme = 1, dispatch = "OEM_5", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "^", role = 2, usingIme = 1, dispatch = "OEM_7", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = "\\ _", role = 2, usingIme = 1, dispatch = "OEM_102", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = ",", role = 2, usingIme = 1, dispatch = "OEM_COMMA", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                                new CircleItem() { label = ".", role = 2, usingIme = 1, dispatch = "OEM_PERIOD", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            }, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                        },
                        enumeration = true
                    },
                    new CircleInputPreset()
                    {
                        presetName = "A",
                        usingIme = 0,
                        circleItem = new List<CircleItem> {
                            new CircleItem() { label = "A", role = 2, usingIme = 0, dispatch = "VK_A", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "B", role = 2, usingIme = 0, dispatch = "VK_B", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "C", role = 2, usingIme = 0, dispatch = "VK_C", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "D", role = 2, usingIme = 0, dispatch = "VK_D", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "E", role = 2, usingIme = 0, dispatch = "VK_E", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F", role = 2, usingIme = 0, dispatch = "VK_F", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "G", role = 2, usingIme = 0, dispatch = "VK_G", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "H", role = 2, usingIme = 0, dispatch = "VK_H", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "I", role = 2, usingIme = 0, dispatch = "VK_I", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "J", role = 2, usingIme = 0, dispatch = "VK_J", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "K", role = 2, usingIme = 0, dispatch = "VK_K", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "L", role = 2, usingIme = 0, dispatch = "VK_L", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "M", role = 2, usingIme = 0, dispatch = "VK_M", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "N", role = 2, usingIme = 0, dispatch = "VK_N", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "O", role = 2, usingIme = 0, dispatch = "VK_O", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "P", role = 2, usingIme = 0, dispatch = "VK_P", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "Q", role = 2, usingIme = 0, dispatch = "VK_Q", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "R", role = 2, usingIme = 0, dispatch = "VK_R", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "S", role = 2, usingIme = 0, dispatch = "VK_S", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "T", role = 2, usingIme = 0, dispatch = "VK_T", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "U", role = 2, usingIme = 0, dispatch = "VK_U", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "V", role = 2, usingIme = 0, dispatch = "VK_V", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "W", role = 2, usingIme = 0, dispatch = "VK_W", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "X", role = 2, usingIme = 0, dispatch = "VK_X", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "Y", role = 2, usingIme = 0, dispatch = "VK_Y", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "Z", role = 2, usingIme = 0, dispatch = "VK_Z", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "0", role = 2, usingIme = 0, dispatch = "VK_0", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "1", role = 2, usingIme = 0, dispatch = "VK_1", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "2", role = 2, usingIme = 0, dispatch = "VK_2", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "3", role = 2, usingIme = 0, dispatch = "VK_3", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "4", role = 2, usingIme = 0, dispatch = "VK_4", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "5", role = 2, usingIme = 0, dispatch = "VK_5", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "6", role = 2, usingIme = 0, dispatch = "VK_6", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "7", role = 2, usingIme = 0, dispatch = "VK_7", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "8", role = 2, usingIme = 0, dispatch = "VK_8", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "9", role = 2, usingIme = 0, dispatch = "VK_9", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                        },
                        enumeration = true
                    },
                    new CircleInputPreset()
                    {
                        presetName = "+-",
                        usingIme = 2,
                        circleItem = new List<CircleItem> {
                            new CircleItem() { label = ".",  role = 3, usingIme = 2, dispatch = ".", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = ",",  role = 3, usingIme = 2, dispatch = ",", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "+",  role = 3, usingIme = 2, dispatch = "+", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "-",  role = 3, usingIme = 2, dispatch = "-", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "*",  role = 3, usingIme = 2, dispatch = "*", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "/",  role = 3, usingIme = 2, dispatch = "/", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "!",  role = 3, usingIme = 2, dispatch = "!", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "?",  role = 3, usingIme = 2, dispatch = "?", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "#",  role = 3, usingIme = 2, dispatch = "#", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "$",  role = 3, usingIme = 2, dispatch = "$", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "%",  role = 3, usingIme = 2, dispatch = "%", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "&&", role = 3, usingIme = 2, dispatch = "&", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} }
                        },
                        enumeration = true
                    },
                    new CircleInputPreset()
                    {
                        presetName = "♪",
                        usingIme = 2,
                        circleItem = new List<CircleItem> {
                            new CircleItem() { label = "⏮",  role = 2, usingIme = 2, dispatch = "MEDIA_PREV_TRACK",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏮",  role = 2, usingIme = 2, dispatch = "MEDIA_PREV_TRACK",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏯",  role = 2, usingIme = 2, dispatch = "MEDIA_PLAY_PAUSE",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏯",  role = 2, usingIme = 2, dispatch = "MEDIA_PLAY_PAUSE",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏯",  role = 2, usingIme = 2, dispatch = "MEDIA_PLAY_PAUSE",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏭",  role = 2, usingIme = 2, dispatch = "MEDIA_NEXT_TRACK",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏭",  role = 2, usingIme = 2, dispatch = "MEDIA_NEXT_TRACK",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏭",  role = 2, usingIme = 2, dispatch = "MEDIA_NEXT_TRACK",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "🔊",  role = 2, usingIme = 2, dispatch = "VOLUME_UP",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏹", role = 2, usingIme = 2, dispatch = "MEDIA_STOP", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "🔈", role = 2, usingIme = 2, dispatch = "VOLUME_DOWN", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "⏮", role = 2, usingIme = 2, dispatch = "MEDIA_PREV_TRACK", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} }
                        },
                        enumeration = true
                    },
                    new CircleInputPreset()
                    {
                        presetName = "🔧",
                        usingIme = 2,
                        circleItem = new List<CircleItem> {
                            new CircleItem() { label = "📋",  role = 2, usingIme = 2, dispatch = ";Paste\r\nSend, ^v\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "📄",  role = 2, usingIme = 2, dispatch = ";Copy\r\nSend, ^c\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "🔍",  role = 2, usingIme = 2, dispatch = ";Find\r\nSend, ^f\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "💾",  role = 2, usingIme = 2, dispatch = ";Save\r\nSend, ^s\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "💾✨",  role = 2, usingIme = 2, dispatch = ";SaveAs\r\nSend, +^s\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "🔚",  role = 2, usingIme = 2, dispatch = ";Close\r\nSend, ^w\r\n",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "♻",  role = 2, usingIme = 2, dispatch = ";Recovery\r\nSend, +^t",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "↩",  role = 2, usingIme = 2, dispatch = ";Undo\r\nSend, ^z",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "↪",  role = 2, usingIme = 2, dispatch = ";Redo\r\nSend, ^y",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "💠", role = 2, usingIme = 2, dispatch = ";Tasks\r\n Send, #x", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "📋↩", role = 2, usingIme = 2, dispatch = ";ClipBoard\r\n Send, #v", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "✂", role = 2, usingIme = 2, dispatch = ";Cut\r\nSend, ^x\r\n", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} }
                        },
                        enumeration = true
                    }
                };
            }
        }

        public static CircleInputPreset fnKey
        {
            get
            {
                return new CircleInputPreset()
                {
                    presetName = "Fn",
                    usingIme = 2,
                    circleItem = new List<CircleItem> {
                            new CircleItem() { label = "F1",  role = 2, usingIme = 2, dispatch = "F1",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F2",  role = 2, usingIme = 2, dispatch = "F2",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F3",  role = 2, usingIme = 2, dispatch = "F3",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F4",  role = 2, usingIme = 2, dispatch = "F4",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F5",  role = 2, usingIme = 2, dispatch = "F5",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F6",  role = 2, usingIme = 2, dispatch = "F6",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F7",  role = 2, usingIme = 2, dispatch = "F7",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F8",  role = 2, usingIme = 2, dispatch = "F8",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F9",  role = 2, usingIme = 2, dispatch = "F9",  innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F10", role = 2, usingIme = 2, dispatch = "F10", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F11", role = 2, usingIme = 2, dispatch = "F11", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F12", role = 2, usingIme = 2, dispatch = "F12", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F13", role = 2, usingIme = 2, dispatch = "F13", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F14", role = 2, usingIme = 2, dispatch = "F14", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F15", role = 2, usingIme = 2, dispatch = "F15", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F16", role = 2, usingIme = 2, dispatch = "F16", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F17", role = 2, usingIme = 2, dispatch = "F17", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F18", role = 2, usingIme = 2, dispatch = "F18", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F19", role = 2, usingIme = 2, dispatch = "F19", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F20", role = 2, usingIme = 2, dispatch = "F20", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F21", role = 2, usingIme = 2, dispatch = "F21", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F22", role = 2, usingIme = 2, dispatch = "F22", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F23", role = 2, usingIme = 2, dispatch = "F23", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                            new CircleItem() { label = "F24", role = 2, usingIme = 2, dispatch = "F24", innerItems = new List<CircleItem>{}, subInnerItems = new List<List<CircleItem>>{new List<CircleItem>{}} },
                        },
                    enumeration = false
                };
            }
        }
    }
}
