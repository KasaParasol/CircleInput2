using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CircleInput2
{
    public partial class CircleConfig : Form
    {
        Mode _imc;
        CircleInputPreset _cip;

        public CircleConfig(Mode imc)
        {
            _imc = imc;
            InitializeComponent();
        }

        private void listPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listPreset.SelectedItem.ToString();
            _cip = _imc.circlePresets[listPreset.SelectedIndex];
            displayIme();
            displayTree();
        }

        private void CircleConfig_Load(object sender, EventArgs e)
        {
            displayPresetList();
            if (listPreset.Items.Count != 0) listPreset.SelectedIndex = 0;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            _imc.circlePresets[listPreset.SelectedIndex].presetName = textBox1.Text;
            displayPresetList();
        }

        private void displayPresetList()
        {
            int idx = listPreset.SelectedIndex;

            groupBox1.Enabled = false;
            button_RemoveItem.Enabled = false;
            treeView1.Nodes.Clear();
            listPreset.Items.Clear();

            foreach (var preset in _imc.circlePresets)
            {
                listPreset.Items.Add(preset.presetName);
            }
            if (idx != -1 && listPreset.Items.Count != 0) listPreset.SelectedIndex = idx;
        }

        private void displayIme()
        {
            switch (_cip.usingIme) {
                case 0: radio_IME_Disable.Checked = true; break;
                case 1: radio_IME_Enable.Checked = true; break;
                case 2: radio_IME_Any.Checked = true; break;
            }
        }

        private void displayTree()
        {
            groupBox1.Enabled = false;
            button_RemoveItem.Enabled = false;
            treeView1.Nodes.Clear();
            for (int i = 0; i < _cip.circleItem.Count; i++)
            {
                TreeNode item = new TreeNode(_cip.circleItem[i].label);
                item.Name ="item:" + i.ToString();
                treeView1.Nodes.Add(item);
                circleItemDisplay(_cip.circleItem[i], item);
            }
        }

        private void circleItemDisplay(CircleItem ci, TreeNode itemRoot)
        {
            itemRoot.Nodes.Clear();
            if (ci.role == 1)
            {
                TreeNode childItemRoot = new TreeNode("アイテム一覧");
                childItemRoot.Name = itemRoot.Name + ":childItemRoot";
                itemRoot.Nodes.Add(childItemRoot);
                for (int i = 0; i < ci.innerItems.Count; i++)
                {
                    TreeNode item = new TreeNode(ci.innerItems[i].label);
                    item.Name = itemRoot.Name + ":innerItems:" + i.ToString();
                    childItemRoot.Nodes.Add(item);
                    circleItemDisplay(ci.innerItems[i], item);
                }

                TreeNode fnItemGroupRoot = new TreeNode("Fnキー切替アイテム一覧");
                fnItemGroupRoot.Name = itemRoot.Name + ":fnItemGroupRoot";
                itemRoot.Nodes.Add(fnItemGroupRoot);
                for (int i = 0; i < ci.subInnerItems.Count; i++)
                {
                    TreeNode fnItemRoot = new TreeNode("アイテム一覧 " + i.ToString());
                    fnItemRoot.Name = fnItemGroupRoot.Name + ":" + i.ToString();
                    fnItemGroupRoot.Nodes.Add(fnItemRoot);
                    for (int j = 0; j < ci.subInnerItems[i].Count; j++)
                    {
                        TreeNode item = new TreeNode(ci.subInnerItems[i][j].label);
                        item.Name = itemRoot.Name + ":subInnerItems:" + i.ToString() + ":" + j.ToString();
                        fnItemRoot.Nodes.Add(item);
                        circleItemDisplay(ci.subInnerItems[i][j], item);
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            displaySubcontrol();
        }

        private void displaySubcontrol()
        {
            string[] nodes = treeView1.SelectedNode.Name.Split(':');
            if (Regex.IsMatch(nodes.Last(), "^[0-9]+$") && nodes[nodes.Length - 2] != "fnItemGroupRoot")
            {
                groupBox1.Enabled = true;
                CircleItem ci = getNodeItem(nodes);
                text_ItemLabel.Text = ci.label;
                combo_Role.SelectedIndex = ci.role;
                combo_IME.SelectedIndex = ci.usingIme;
                if (ci.role >= 2)
                {
                    button2.Enabled = true;
                }
                else {
                    button2.Enabled = false;
                }
            }
            else
            {
                groupBox1.Enabled = false;
            }
            if (Regex.IsMatch(nodes.Last(), "^[0-9]+$"))
            {
                button_RemoveItem.Enabled = true;
            }
            else
            {
                button_RemoveItem.Enabled = false;
            }
        }

        private void button_AddItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null) {
                _cip.circleItem.Add(new CircleItem()
                {
                    label = "(New)",
                    role = 0,
                    innerItems = new List<CircleItem>() { },
                    subInnerItems = new List<List<CircleItem>>() { },
                    dispatch = "",
                    usingIme = 2
                });
                displayTree();
            }
        }

        private void button_RemoveItem_Click(object sender, EventArgs e)
        {
            string[] nodes = treeView1.SelectedNode.Name.Split(':');
            string[] idxes = Array.FindAll(nodes, IsNumber);

            if (MessageBox.Show("すべての子要素が削除されます。よろしいですか？", "確認", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            if (idxes.Length == 1)
            {
                _cip.circleItem.RemoveAt(Int32.Parse(idxes[0]));
                displayTree();
                return;
            }
            if (idxes.Length == 2 && nodes[nodes.Length - 2] != "fnItemGroupRoot")
            {
                _cip.circleItem[Int32.Parse(idxes[0])].innerItems.RemoveAt(Int32.Parse(idxes[1]));
                circleItemDisplay(_cip.circleItem[Int32.Parse(idxes[0])], treeView1.SelectedNode.Parent.Parent);
                return;
            }
            if (idxes.Length == 2 && nodes[nodes.Length - 2] == "fnItemGroupRoot")
            {
                _cip.circleItem[Int32.Parse(idxes[0])].subInnerItems.RemoveAt(Int32.Parse(idxes[1]));
                circleItemDisplay(_cip.circleItem[Int32.Parse(idxes[0])], treeView1.SelectedNode.Parent.Parent);
                return;
            }
            else {
                _cip.circleItem[Int32.Parse(idxes[0])].subInnerItems[Int32.Parse(idxes[1])].RemoveAt(Int32.Parse(idxes[2]));
                circleItemDisplay(_cip.circleItem[Int32.Parse(idxes[0])], treeView1.SelectedNode.Parent.Parent.Parent);
            }
        }

        private CircleItem getNodeItem(string[] nodes)
        {
            string[] idxes= Array.FindAll(nodes, IsNumber);
            if (idxes.Length == 1) {
                return _cip.circleItem[Int32.Parse(idxes[0])];
            }
            if (idxes.Length == 2)
            {
                return _cip.circleItem[Int32.Parse(idxes[0])].innerItems[Int32.Parse(idxes[1])];
            }
            else
            {
                return _cip.circleItem[Int32.Parse(idxes[0])].subInnerItems[Int32.Parse(idxes[1])][Int32.Parse(idxes[2])];
            }
        }
        private static bool IsNumber(string s)
        {
            try
            {
                Int32.Parse(s);
                return true;
            }
            catch {
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] nodes = treeView1.SelectedNode.Name.Split(':');
            CircleItem ci = getNodeItem(nodes);
            ButtonConfigInput form = new ButtonConfigInput(ci.dispatch);
            form.ShowDialog();
            ci.dispatch = form.Value;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _imc.circlePresets.Add(new CircleInputPreset()
            {
                presetName = "(New)",
                usingIme = 2,
                enumeration = true,
                circleItem = new List<CircleItem>()
            });
            displayPresetList();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("すべての子要素が削除されます。よろしいですか？", "確認", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            _imc.circlePresets.RemoveAt(listPreset.SelectedIndex);
            displayPresetList();
        }

        private void combo_Role_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] nodes = treeView1.SelectedNode.Name.Split(':');
            CircleItem ci = getNodeItem(nodes);
            if (nodes.Length != 1 && combo_Role.SelectedIndex == 1) 
            {
                MessageBox.Show("子要素にグループを指定することはできません。", "情報", MessageBoxButtons.OK);
                combo_Role.SelectedIndex = ci.role;
            }
            if (Regex.IsMatch(nodes.Last(), "^[0-9]+$") && nodes[nodes.Length - 2] != "fnItemGroupRoot") {
                ci.role = combo_Role.SelectedIndex;
                if (ci.role >= 2)
                {
                    button2.Enabled = true;
                }
                else
                {
                    button2.Enabled = false;
                }
            }
                
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void text_ItemLabel_TextChanged(object sender, EventArgs e)
        {
            string[] nodes = treeView1.SelectedNode.Name.Split(':');
            CircleItem ci = getNodeItem(nodes);
            ci.label = text_ItemLabel.Text;
        }
    }
}
