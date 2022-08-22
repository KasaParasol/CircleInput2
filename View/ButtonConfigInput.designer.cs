
namespace CircleInput2
{
    partial class ButtonConfigInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonConfigInput));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radio_Multiple = new System.Windows.Forms.RadioButton();
            this.radio_Single = new System.Windows.Forms.RadioButton();
            this.text_GetKey = new System.Windows.Forms.TextBox();
            this.text_Value = new System.Windows.Forms.TextBox();
            this.button_Apply = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radio_Multiple);
            this.panel1.Controls.Add(this.radio_Single);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 22);
            this.panel1.TabIndex = 0;
            // 
            // radio_Multiple
            // 
            this.radio_Multiple.AutoSize = true;
            this.radio_Multiple.Location = new System.Drawing.Point(88, 3);
            this.radio_Multiple.Name = "radio_Multiple";
            this.radio_Multiple.Size = new System.Drawing.Size(88, 16);
            this.radio_Multiple.TabIndex = 1;
            this.radio_Multiple.Text = "Multiple-Key";
            this.radio_Multiple.UseVisualStyleBackColor = true;
            // 
            // radio_Single
            // 
            this.radio_Single.AutoSize = true;
            this.radio_Single.Checked = true;
            this.radio_Single.Location = new System.Drawing.Point(3, 3);
            this.radio_Single.Name = "radio_Single";
            this.radio_Single.Size = new System.Drawing.Size(79, 16);
            this.radio_Single.TabIndex = 0;
            this.radio_Single.TabStop = true;
            this.radio_Single.Text = "Single-Key";
            this.radio_Single.UseVisualStyleBackColor = true;
            this.radio_Single.CheckedChanged += new System.EventHandler(this.radio_Single_CheckedChanged);
            // 
            // text_GetKey
            // 
            this.text_GetKey.Location = new System.Drawing.Point(206, 15);
            this.text_GetKey.Name = "text_GetKey";
            this.text_GetKey.ReadOnly = true;
            this.text_GetKey.Size = new System.Drawing.Size(99, 19);
            this.text_GetKey.TabIndex = 1;
            this.text_GetKey.TabStop = false;
            this.text_GetKey.Text = "KeyPress Here";
            this.text_GetKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_GetKey_KeyDown);
            // 
            // text_Value
            // 
            this.text_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_Value.Location = new System.Drawing.Point(12, 41);
            this.text_Value.Multiline = true;
            this.text_Value.Name = "text_Value";
            this.text_Value.Size = new System.Drawing.Size(293, 368);
            this.text_Value.TabIndex = 2;
            // 
            // button_Apply
            // 
            this.button_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Apply.Location = new System.Drawing.Point(230, 415);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(75, 23);
            this.button_Apply.TabIndex = 3;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(312, 14);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(246, 424);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // ButtonConfigInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.text_Value);
            this.Controls.Add(this.text_GetKey);
            this.Controls.Add(this.panel1);
            this.Name = "ButtonConfigInput";
            this.Text = "ButtonConfigInput";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radio_Multiple;
        private System.Windows.Forms.RadioButton radio_Single;
        private System.Windows.Forms.TextBox text_GetKey;
        private System.Windows.Forms.TextBox text_Value;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.TextBox textBox1;
    }
}