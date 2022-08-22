using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class ButtonConfigInput : Form
    {
        public string Value;
        public ButtonConfigInput(string value)
        {
            InitializeComponent();

            Value = value;
            text_Value.Text = value;

            if (stringIsSingleKey(value))
            {
                radio_Single.Checked = true;
            }
            else
            {
                radio_Multiple.Checked = true;
            }
        }

        private void text_GetKey_KeyDown(object sender, KeyEventArgs e)
        {
            var pair = KeyCode.dict.FirstOrDefault(c => c.Value == (int)e.KeyCode);
            string key = pair.Key;
            text_Value.Text = key;
        }

        private void radio_Single_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_Single.Checked)
            {
                text_GetKey.Visible = true;
            }
            else
            {
                text_GetKey.Visible = false;
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            if (radio_Single.Checked)
            {
                var pair = KeyCode.dict.FirstOrDefault(c => c.Key == text_Value.Text.Replace("\r", "").Replace("\n", "").Trim(new char[] { ' ', '\n', '\t' }));
                if (pair.Key != text_Value.Text.Replace("\r", "").Replace("\n", "").Trim(new char[] { ' ', '\n', '\t' }))
                {
                    if (MessageBox.Show("非対応のキーです。無効キーに割り当てますがよろしいでしょうか？", "確認", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                    text_Value.Text = "V_KEY_NOTHING";
                }
                text_Value.Text = text_Value.Text.Replace("\r", "").Replace("\n", "").Trim(new char[] { ' ', '\n', '\t' });
            }
            Value = text_Value.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private bool stringIsSingleKey(string str)
        {
            string[] arr = str.Split('\n');
            if (arr.Length != 1) return false;

            Match matche = Regex.Match(str, "^[a-zA-Z0-9_]+$");

            return matche.Value.Length == 0 ? false : true;
        }
    }
}
