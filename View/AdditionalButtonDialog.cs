using System;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class AdditionalButtonDialog : Form
    {
        string[] _keymap;

        public string[] Value;
        public AdditionalButtonDialog(string[] keymap)
        {
            _keymap = new string[keymap.Length];
            Value = new string[keymap.Length];
            Array.Copy(keymap, _keymap, keymap.Length);
            Array.Copy(keymap, Value, keymap.Length);
            InitializeComponent();
        }

        private void AdditionalButtonDialog_Load(object sender, EventArgs e)
        {
            displayGrid();
        }

        private void displayGrid()
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

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Dispatch";
            column2.ReadOnly = true;
            dataGridView1.Columns.Add(column2);
            column2.SortMode = DataGridViewColumnSortMode.NotSortable;
            column2.Width = 144;

            DataGridViewButtonColumn column3 = new DataGridViewButtonColumn();
            column3.HeaderText = "Edit";
            column3.Name = "Edit";
            dataGridView1.Columns.Add(column3);
            column3.SortMode = DataGridViewColumnSortMode.NotSortable;
            column3.Width = 38;

            string[] buttonDict = new string[] { "A", "B", "X", "Y", "R", "L", "Back", "Start", "L-Axis", "R-Axis" };

            for (int i = 0; i < _keymap.Length; i++)
            {
                string title = (i < buttonDict.Length ? buttonDict[i] : "Additional") + " Button@" + (i + 1).ToString();
                dataGridView1.Rows.Add(title, _keymap[i]);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            //"Button"列ならば、ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "Edit")
            {
                ButtonConfigInput form = new ButtonConfigInput(_keymap[e.RowIndex]);
                form.ShowDialog();

                _keymap[e.RowIndex] = form.Value;
                displayGrid();
            }
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Value = _keymap;
            Close();
        }
    }
}
