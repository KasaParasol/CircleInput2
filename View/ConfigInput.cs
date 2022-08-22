using System;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class ConfigInput : Form
    {
        public string ConfigId = "";
        public string Value    = "";
        string Constraints = "";
        public ConfigInput(string configId, string value, string constraints)
        {
            InitializeComponent();

            ConfigId = configId;
            Value = value;
            Constraints = constraints;

            textBox1.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Constraints.IndexOf("-") >= 0) {
                string[] ranges = Constraints.Split('-');
                try
                {
                    if (Int32.Parse(ranges[0]) <= Int32.Parse(textBox1.Text) && Int32.Parse(ranges[1]) >= Int32.Parse(textBox1.Text))
                    {
                        Value = textBox1.Text;
                        Close();
                        return;
                    }
                    MessageBox.Show("値は" + ranges[0] + "から" + ranges[1] + "の間である必要があります。", "エラー", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("値は" + ranges[0] + "から" + ranges[1] + "の間の数値である必要があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            if (Constraints.IndexOf("|") >= 0) { 
                string[] patterns = Constraints.Split('|');
                foreach (string pattern in patterns)
                {
                    if (textBox1.Text == pattern) {
                        Value = textBox1.Text;
                        Close();
                        return;
                    }
                }
                MessageBox.Show("値は" + string.Join("・", patterns) + "のいずれかである必要があります。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Value = textBox1.Text;
            Close();
            return;
        }
    }
}
