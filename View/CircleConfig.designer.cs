
namespace CircleInput2
{
    partial class CircleConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listPreset = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio_IME_Any = new System.Windows.Forms.RadioButton();
            this.radio_IME_Disable = new System.Windows.Forms.RadioButton();
            this.radio_IME_Enable = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Close = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_AddItem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.combo_IME = new System.Windows.Forms.ComboBox();
            this.combo_Role = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_ItemLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_RemoveItem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPreset
            // 
            this.listPreset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listPreset.FormattingEnabled = true;
            this.listPreset.ItemHeight = 12;
            this.listPreset.Location = new System.Drawing.Point(12, 12);
            this.listPreset.Name = "listPreset";
            this.listPreset.Size = new System.Drawing.Size(130, 376);
            this.listPreset.TabIndex = 0;
            this.listPreset.SelectedIndexChanged += new System.EventHandler(this.listPreset_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(12, 418);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 20);
            this.addButton.TabIndex = 19;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(50, 418);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(32, 20);
            this.removeButton.TabIndex = 18;
            this.removeButton.Text = "-";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio_IME_Any);
            this.panel1.Controls.Add(this.radio_IME_Disable);
            this.panel1.Controls.Add(this.radio_IME_Enable);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(148, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 22);
            this.panel1.TabIndex = 20;
            // 
            // radio_IME_Any
            // 
            this.radio_IME_Any.AutoSize = true;
            this.radio_IME_Any.Checked = true;
            this.radio_IME_Any.Location = new System.Drawing.Point(206, 3);
            this.radio_IME_Any.Name = "radio_IME_Any";
            this.radio_IME_Any.Size = new System.Drawing.Size(43, 16);
            this.radio_IME_Any.TabIndex = 24;
            this.radio_IME_Any.TabStop = true;
            this.radio_IME_Any.Text = "Any";
            this.radio_IME_Any.UseVisualStyleBackColor = true;
            // 
            // radio_IME_Disable
            // 
            this.radio_IME_Disable.AutoSize = true;
            this.radio_IME_Disable.Location = new System.Drawing.Point(76, 3);
            this.radio_IME_Disable.Name = "radio_IME_Disable";
            this.radio_IME_Disable.Size = new System.Drawing.Size(61, 16);
            this.radio_IME_Disable.TabIndex = 23;
            this.radio_IME_Disable.Text = "Disable";
            this.radio_IME_Disable.UseVisualStyleBackColor = true;
            // 
            // radio_IME_Enable
            // 
            this.radio_IME_Enable.AutoSize = true;
            this.radio_IME_Enable.Location = new System.Drawing.Point(143, 3);
            this.radio_IME_Enable.Name = "radio_IME_Enable";
            this.radio_IME_Enable.Size = new System.Drawing.Size(57, 16);
            this.radio_IME_Enable.TabIndex = 22;
            this.radio_IME_Enable.Text = "Enable";
            this.radio_IME_Enable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 21;
            this.label1.Text = "IME Control:";
            // 
            // button_Close
            // 
            this.button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Close.Location = new System.Drawing.Point(582, 415);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(75, 23);
            this.button_Close.TabIndex = 21;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(148, 40);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(260, 372);
            this.treeView1.TabIndex = 22;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 392);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 19);
            this.textBox1.TabIndex = 24;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // button_AddItem
            // 
            this.button_AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_AddItem.Location = new System.Drawing.Point(148, 418);
            this.button_AddItem.Name = "button_AddItem";
            this.button_AddItem.Size = new System.Drawing.Size(32, 20);
            this.button_AddItem.TabIndex = 25;
            this.button_AddItem.Text = "+";
            this.button_AddItem.UseVisualStyleBackColor = true;
            this.button_AddItem.Click += new System.EventHandler(this.button_AddItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.combo_IME);
            this.groupBox1.Controls.Add(this.combo_Role);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.text_ItemLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(414, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 397);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "Key-Mapping";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "IME Control:";
            // 
            // combo_IME
            // 
            this.combo_IME.FormattingEnabled = true;
            this.combo_IME.Items.AddRange(new object[] {
            "Disable",
            "Enable",
            "Any"});
            this.combo_IME.Location = new System.Drawing.Point(78, 67);
            this.combo_IME.Name = "combo_IME";
            this.combo_IME.Size = new System.Drawing.Size(159, 20);
            this.combo_IME.TabIndex = 4;
            // 
            // combo_Role
            // 
            this.combo_Role.AutoCompleteCustomSource.AddRange(new string[] {
            "無効",
            "グループ",
            "マクロキー",
            "文字転送"});
            this.combo_Role.FormattingEnabled = true;
            this.combo_Role.Items.AddRange(new object[] {
            "無効",
            "グループ",
            "マクロキー",
            "文字転送"});
            this.combo_Role.Location = new System.Drawing.Point(78, 41);
            this.combo_Role.Name = "combo_Role";
            this.combo_Role.Size = new System.Drawing.Size(159, 20);
            this.combo_Role.TabIndex = 3;
            this.combo_Role.SelectedIndexChanged += new System.EventHandler(this.combo_Role_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Role: ";
            // 
            // text_ItemLabel
            // 
            this.text_ItemLabel.Location = new System.Drawing.Point(78, 16);
            this.text_ItemLabel.Name = "text_ItemLabel";
            this.text_ItemLabel.Size = new System.Drawing.Size(159, 19);
            this.text_ItemLabel.TabIndex = 1;
            this.text_ItemLabel.TextChanged += new System.EventHandler(this.text_ItemLabel_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Item Label: ";
            // 
            // button_RemoveItem
            // 
            this.button_RemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_RemoveItem.Enabled = false;
            this.button_RemoveItem.Location = new System.Drawing.Point(186, 418);
            this.button_RemoveItem.Name = "button_RemoveItem";
            this.button_RemoveItem.Size = new System.Drawing.Size(32, 20);
            this.button_RemoveItem.TabIndex = 27;
            this.button_RemoveItem.Text = "-";
            this.button_RemoveItem.UseVisualStyleBackColor = true;
            this.button_RemoveItem.Click += new System.EventHandler(this.button_RemoveItem_Click);
            // 
            // CircleConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 450);
            this.Controls.Add(this.button_RemoveItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_AddItem);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.listPreset);
            this.MinimizeBox = false;
            this.Name = "CircleConfig";
            this.Text = "CircleConfig";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CircleConfig_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listPreset;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radio_IME_Any;
        private System.Windows.Forms.RadioButton radio_IME_Disable;
        private System.Windows.Forms.RadioButton radio_IME_Enable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_AddItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_Role;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_ItemLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox combo_IME;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_RemoveItem;
    }
}