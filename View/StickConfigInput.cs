using System;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class StickConfigInput : Form
    {
        Mode _imc;
        string _target;
        int _anarogStickThreshold;

        public int AnarogStickThreshold
        {
            get {
                return _anarogStickThreshold;
            }
        }

        public StickConfigInput(Mode imc, string target, int anarogStickThreshold)
        {
            _target = target;
            _imc = imc;
            _anarogStickThreshold = anarogStickThreshold;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)combo_X.SelectedItem == "サークルUI制御@V_KEY_CIRCLE")
            {
                combo_Y.Visible = false;
                return;
            }
            else
            {
                combo_Y.Visible = true;
                return;
            }
        }

        private void StickConfigInput_Load(object sender, EventArgs e)
        {
            combo_X.SelectedIndex = 0;
            combo_Y.SelectedIndex = 0;

            check_X.Checked = _imc.reverseX;
            check_Y.Checked = _imc.reverseY;

            num_Cursor.Value = _imc.mouseSpeed;
            num_Wheel.Value = _imc.wheelSpeed;
            num_StickThreshold.Value = _anarogStickThreshold;

            if (_target == "button_LAxis")
            {
                foreach (string s in combo_X.Items)
                {
                    if (s.Contains(_imc.keymap["x_slider"]))
                    {
                        combo_X.SelectedItem = s;
                    }
                }
                foreach (string s in combo_Y.Items)
                {
                    if (s.Contains(_imc.keymap["y_slider"]))
                    {
                        combo_Y.SelectedItem = s;
                    }
                }
            }
            if (_target == "button_RAxis")
            {
                foreach (string s in combo_X.Items)
                {
                    if (s.Contains(_imc.keymap["x_rotate"]))
                    {
                        combo_X.SelectedItem = s;
                    }
                }
                foreach (string s in combo_Y.Items)
                {
                    if (s.Contains(_imc.keymap["y_rotate"]))
                    {
                        combo_Y.SelectedItem = s;
                    }
                }
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            _imc.reverseX = check_X.Checked;
            _imc.reverseY = check_Y.Checked;

            _imc.mouseSpeed = (int)num_Cursor.Value;
            _imc.wheelSpeed = (int)num_Wheel.Value;
            _anarogStickThreshold = (int)num_StickThreshold.Value;

            if (_target == "button_LAxis")
            {
                _imc.keymap["x_slider"] = combo_X.SelectedItem.ToString().Split('@')[1];
                if (combo_Y.Visible)
                {
                    _imc.keymap["y_slider"] = combo_Y.SelectedItem.ToString().Split('@')[1];
                }
                else
                {
                    _imc.keymap["y_slider"]  = _imc.keymap["x_slider"];
                }
            }
            if (_target == "button_RAxis")
            {
                _imc.keymap["x_rotate"] = combo_X.SelectedItem.ToString().Split('@')[1];
                if (combo_Y.Visible)
                {
                    _imc.keymap["y_rotate"] = combo_Y.SelectedItem.ToString().Split('@')[1];
                }
                else
                {
                    _imc.keymap["y_rotate"] = _imc.keymap["x_rotate"];
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void button_Circle_Click(object sender, EventArgs e)
        {
            CircleConfig form = new CircleConfig(_imc);
            form.ShowDialog();
        }
    }
}
