using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class MultiPurposeConfigure : Form
    {
        private Dictionary<string, bool> _isMultiPurpose;

        public Dictionary<string, bool> Value {
            get {
                return _isMultiPurpose;
            }
        }

        public MultiPurposeConfigure(Dictionary<string, bool> isMultiPurpose)
        {
            _isMultiPurpose = isMultiPurpose;
            InitializeComponent();
        }

        private void MultiPurposeConfigure_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Button";
            column1.ReadOnly = true;
            dataGridView1.Columns.Add(column1);
            column1.SortMode = DataGridViewColumnSortMode.NotSortable;
            column1.Width = 144;

            DataGridViewCheckBoxColumn column2 = new DataGridViewCheckBoxColumn();
            column2.HeaderText = "Enable";
            dataGridView1.Columns.Add(column2);
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.Width = 70;

            dataGridView1.Rows.Add("Pov-Up", _isMultiPurpose["arrow_top"]);
            dataGridView1.Rows.Add("Pov-Down", _isMultiPurpose["arrow_bottom"]);
            dataGridView1.Rows.Add("Pov-Left", _isMultiPurpose["arrow_left"]);
            dataGridView1.Rows.Add("Pov-Right", _isMultiPurpose["arrow_right"]);
            dataGridView1.Rows.Add("Z +", _isMultiPurpose["z_plus"]);
            dataGridView1.Rows.Add("Z -", _isMultiPurpose["z_minus"]);

            string[] buttonDict = new string[] { "A", "B", "X", "Y", "R", "L", "Back", "Start", "L-Axis", "R-Axis" };

            Dictionary<string, bool> buttons = _isMultiPurpose.Where(x => x.Key.StartsWith("buttons")).ToDictionary(x => x.Key, x => x.Value);
            int i = 0;
            foreach(KeyValuePair<string, bool> kvp in buttons)
            {
                string title = (i < buttonDict.Length ? buttonDict[i] : "Additional") + " Button@" + (i + 1).ToString();
                dataGridView1.Rows.Add(title, kvp.Value);
                i++;
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            foreach (var r in dataGridView1.Rows)
            {
                switch (((DataGridViewRow)r).Cells[0].Value)
                {
                    case "Pov-Up": _isMultiPurpose["arrow_top"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    case "Pov-Down": _isMultiPurpose["arrow_bottom"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    case "Pov-Left": _isMultiPurpose["arrow_left"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    case "Pov-Right": _isMultiPurpose["arrow_right"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    case "Z -": _isMultiPurpose["z_minus"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    case "Z +": _isMultiPurpose["z_plus"] = (bool)((DataGridViewRow)r).Cells[1].Value; break;
                    default:
                        var strs = ((string)((DataGridViewRow)r).Cells[0].Value).Split('@');
                        if (strs.Length == 2)
                        {
                            try
                            {
                                _isMultiPurpose["buttons" + (Int32.Parse(strs[1]) - 1).ToString()] = (bool)((DataGridViewRow)r).Cells[1].Value;
                            }
                            catch { }
                        }
                        break;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
