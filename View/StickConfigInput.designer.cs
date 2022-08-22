
namespace CircleInput2
{
    partial class StickConfigInput
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_X = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Y = new System.Windows.Forms.ComboBox();
            this.check_X = new System.Windows.Forms.CheckBox();
            this.check_Y = new System.Windows.Forms.CheckBox();
            this.num_Cursor = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.num_Wheel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_StickThreshold = new System.Windows.Forms.NumericUpDown();
            this.button_Circle = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cursor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Wheel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StickThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.num_StickThreshold);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.num_Wheel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.num_Cursor);
            this.groupBox1.Controls.Add(this.check_Y);
            this.groupBox1.Controls.Add(this.check_X);
            this.groupBox1.Location = new System.Drawing.Point(14, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "共通設定";
            // 
            // combo_X
            // 
            this.combo_X.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_X.FormattingEnabled = true;
            this.combo_X.Items.AddRange(new object[] {
            "何もしない@V_KEY_NOTHING",
            "マウスポインタX座標@V_KEY_MOUSE_X",
            "マウスポインタY座標@V_KEY_MOUSE_Y",
            "サークルUI制御@V_KEY_CIRCLE",
            "マウスホイールX軸@V_KEY_WHEEL_X",
            "マウスホイールY軸@V_KEY_WHEEL_Y",
            "マウスホイールX軸 + SHIFT@V_KEY_SHIFT_WHEEL_X",
            "マウスホイールY軸 + SHIFT@V_KEY_SHIFT_WHEEL_Y",
            "マウスホイールX軸 + CTRL@V_KEY_CTRL_WHEEL_X",
            "マウスホイールY軸 + CTRL@V_KEY_CTRL_WHEEL_Y",
            "マウスホイールX軸 + SHIFT + CTRL@V_KEY_SC_WHEEL_X",
            "マウスホイールY軸 + SHIFT + CTRL@V_KEY_SC_WHEEL_Y",
            "マウスホイールX軸 + ALT@V_KEY_ALT_WHEEL_X",
            "マウスホイールY軸 + ALT@V_KEY_ALT_WHEEL_Y"});
            this.combo_X.Location = new System.Drawing.Point(44, 12);
            this.combo_X.Name = "combo_X";
            this.combo_X.Size = new System.Drawing.Size(328, 20);
            this.combo_X.TabIndex = 1;
            this.combo_X.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "X軸:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y軸:";
            // 
            // combo_Y
            // 
            this.combo_Y.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Y.FormattingEnabled = true;
            this.combo_Y.Items.AddRange(new object[] {
            "何もしない@V_KEY_NOTHING",
            "マウスポインタX座標@V_KEY_MOUSE_X",
            "マウスポインタY座標@V_KEY_MOUSE_Y",
            "マウスホイールX軸@V_KEY_WHEEL_X",
            "マウスホイールY軸@V_KEY_WHEEL_Y",
            "マウスホイールX軸 + SHIFT@V_KEY_SHIFT_WHEEL_X",
            "マウスホイールY軸 + SHIFT@V_KEY_SHIFT_WHEEL_Y",
            "マウスホイールX軸 + CTRL@V_KEY_CTRL_WHEEL_X",
            "マウスホイールY軸 + CTRL@V_KEY_CTRL_WHEEL_Y",
            "マウスホイールX軸 + SHIFT + CTRL@V_KEY_SC_WHEEL_X",
            "マウスホイールY軸 + SHIFT + CTRL@V_KEY_SC_WHEEL_Y",
            "マウスホイールX軸 + ALT@V_KEY_ALT_WHEEL_X",
            "マウスホイールY軸 + ALT@V_KEY_ALT_WHEEL_Y"});
            this.combo_Y.Location = new System.Drawing.Point(44, 38);
            this.combo_Y.Name = "combo_Y";
            this.combo_Y.Size = new System.Drawing.Size(328, 20);
            this.combo_Y.TabIndex = 3;
            // 
            // check_X
            // 
            this.check_X.AutoSize = true;
            this.check_X.Location = new System.Drawing.Point(140, 19);
            this.check_X.Name = "check_X";
            this.check_X.Size = new System.Drawing.Size(103, 16);
            this.check_X.TabIndex = 0;
            this.check_X.Text = "Xホイールを反転";
            this.check_X.UseVisualStyleBackColor = true;
            // 
            // check_Y
            // 
            this.check_Y.AutoSize = true;
            this.check_Y.Location = new System.Drawing.Point(249, 19);
            this.check_Y.Name = "check_Y";
            this.check_Y.Size = new System.Drawing.Size(103, 16);
            this.check_Y.TabIndex = 1;
            this.check_Y.Text = "Yホイールを反転";
            this.check_Y.UseVisualStyleBackColor = true;
            // 
            // num_Cursor
            // 
            this.num_Cursor.Location = new System.Drawing.Point(237, 42);
            this.num_Cursor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Cursor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Cursor.Name = "num_Cursor";
            this.num_Cursor.Size = new System.Drawing.Size(120, 19);
            this.num_Cursor.TabIndex = 5;
            this.num_Cursor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "マウスカーソル速度:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "ホイール速度:";
            // 
            // num_Wheel
            // 
            this.num_Wheel.Location = new System.Drawing.Point(237, 67);
            this.num_Wheel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_Wheel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Wheel.Name = "num_Wheel";
            this.num_Wheel.Size = new System.Drawing.Size(120, 19);
            this.num_Wheel.TabIndex = 7;
            this.num_Wheel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "スティック閾値:";
            // 
            // num_StickThreshold
            // 
            this.num_StickThreshold.Location = new System.Drawing.Point(237, 92);
            this.num_StickThreshold.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_StickThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_StickThreshold.Name = "num_StickThreshold";
            this.num_StickThreshold.Size = new System.Drawing.Size(120, 19);
            this.num_StickThreshold.TabIndex = 9;
            this.num_StickThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button_Circle
            // 
            this.button_Circle.Location = new System.Drawing.Point(12, 191);
            this.button_Circle.Name = "button_Circle";
            this.button_Circle.Size = new System.Drawing.Size(92, 23);
            this.button_Circle.TabIndex = 5;
            this.button_Circle.Text = "CirclePreset";
            this.button_Circle.UseVisualStyleBackColor = true;
            this.button_Circle.Click += new System.EventHandler(this.button_Circle_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(280, 191);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(92, 23);
            this.button_Apply.TabIndex = 6;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // StickConfigInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 227);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.button_Circle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combo_Y);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combo_X);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 266);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 266);
            this.Name = "StickConfigInput";
            this.Text = "StickConfigInput";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StickConfigInput_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Cursor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Wheel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_StickThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_X;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_StickThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Wheel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_Cursor;
        private System.Windows.Forms.CheckBox check_Y;
        private System.Windows.Forms.CheckBox check_X;
        private System.Windows.Forms.Button button_Circle;
        private System.Windows.Forms.Button button_Apply;
    }
}