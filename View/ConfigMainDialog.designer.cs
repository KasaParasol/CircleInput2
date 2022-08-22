
namespace CircleInput2
{
    partial class ConfigMainDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigMainDialog));
            this.button_RemoveApplication = new System.Windows.Forms.Button();
            this.button_AddApplication = new System.Windows.Forms.Button();
            this.combo_Application = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Combination = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ZPlus = new System.Windows.Forms.Button();
            this.button_R = new System.Windows.Forms.Button();
            this.button_Y = new System.Windows.Forms.Button();
            this.button_X = new System.Windows.Forms.Button();
            this.button_B = new System.Windows.Forms.Button();
            this.button_A = new System.Windows.Forms.Button();
            this.button_RAxis = new System.Windows.Forms.Button();
            this.button_RP = new System.Windows.Forms.Button();
            this.button_ZMinus = new System.Windows.Forms.Button();
            this.button_L = new System.Windows.Forms.Button();
            this.button_LAxis = new System.Windows.Forms.Button();
            this.button_LP = new System.Windows.Forms.Button();
            this.button_BK = new System.Windows.Forms.Button();
            this.button_ST = new System.Windows.Forms.Button();
            this.button_PovUp = new System.Windows.Forms.Button();
            this.button_PovLeft = new System.Windows.Forms.Button();
            this.button_PovDown = new System.Windows.Forms.Button();
            this.button_PovRight = new System.Windows.Forms.Button();
            this.button_Other = new System.Windows.Forms.Button();
            this.button_Apply = new System.Windows.Forms.Button();
            this.check_View = new System.Windows.Forms.CheckBox();
            this.button_Combi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_RemoveApplication
            // 
            this.button_RemoveApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_RemoveApplication.Location = new System.Drawing.Point(554, 12);
            this.button_RemoveApplication.Name = "button_RemoveApplication";
            this.button_RemoveApplication.Size = new System.Drawing.Size(32, 20);
            this.button_RemoveApplication.TabIndex = 17;
            this.button_RemoveApplication.Text = "-";
            this.button_RemoveApplication.UseVisualStyleBackColor = true;
            this.button_RemoveApplication.Click += new System.EventHandler(this.button_RemoveApplication_Click);
            // 
            // button_AddApplication
            // 
            this.button_AddApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddApplication.Location = new System.Drawing.Point(516, 12);
            this.button_AddApplication.Name = "button_AddApplication";
            this.button_AddApplication.Size = new System.Drawing.Size(32, 20);
            this.button_AddApplication.TabIndex = 16;
            this.button_AddApplication.Text = "+";
            this.button_AddApplication.UseVisualStyleBackColor = true;
            this.button_AddApplication.Click += new System.EventHandler(this.button_AddApplication_Click);
            // 
            // combo_Application
            // 
            this.combo_Application.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Application.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Application.FormattingEnabled = true;
            this.combo_Application.Location = new System.Drawing.Point(292, 12);
            this.combo_Application.Name = "combo_Application";
            this.combo_Application.Size = new System.Drawing.Size(218, 20);
            this.combo_Application.TabIndex = 15;
            this.combo_Application.SelectedIndexChanged += new System.EventHandler(this.combo_Application_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(218, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Application: ";
            // 
            // combo_Combination
            // 
            this.combo_Combination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Combination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_Combination.FormattingEnabled = true;
            this.combo_Combination.Location = new System.Drawing.Point(292, 38);
            this.combo_Combination.Name = "combo_Combination";
            this.combo_Combination.Size = new System.Drawing.Size(218, 20);
            this.combo_Combination.TabIndex = 19;
            this.combo_Combination.SelectedIndexChanged += new System.EventHandler(this.combo_Combination_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(218, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Combination:";
            // 
            // button_ZPlus
            // 
            this.button_ZPlus.Location = new System.Drawing.Point(73, 41);
            this.button_ZPlus.Name = "button_ZPlus";
            this.button_ZPlus.Size = new System.Drawing.Size(109, 23);
            this.button_ZPlus.TabIndex = 21;
            this.button_ZPlus.Text = "Z +";
            this.button_ZPlus.UseVisualStyleBackColor = true;
            this.button_ZPlus.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_R
            // 
            this.button_R.Location = new System.Drawing.Point(623, 90);
            this.button_R.Name = "button_R";
            this.button_R.Size = new System.Drawing.Size(109, 23);
            this.button_R.TabIndex = 22;
            this.button_R.Text = "R (5)";
            this.button_R.UseVisualStyleBackColor = true;
            this.button_R.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_Y
            // 
            this.button_Y.Location = new System.Drawing.Point(623, 150);
            this.button_Y.Name = "button_Y";
            this.button_Y.Size = new System.Drawing.Size(109, 23);
            this.button_Y.TabIndex = 23;
            this.button_Y.Text = "Y (4)";
            this.button_Y.UseVisualStyleBackColor = true;
            this.button_Y.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_X
            // 
            this.button_X.Location = new System.Drawing.Point(623, 206);
            this.button_X.Name = "button_X";
            this.button_X.Size = new System.Drawing.Size(109, 23);
            this.button_X.TabIndex = 24;
            this.button_X.Text = "X (3)";
            this.button_X.UseVisualStyleBackColor = true;
            this.button_X.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_B
            // 
            this.button_B.Location = new System.Drawing.Point(623, 263);
            this.button_B.Name = "button_B";
            this.button_B.Size = new System.Drawing.Size(109, 23);
            this.button_B.TabIndex = 25;
            this.button_B.Text = "B (2)";
            this.button_B.UseVisualStyleBackColor = true;
            this.button_B.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_A
            // 
            this.button_A.Location = new System.Drawing.Point(623, 314);
            this.button_A.Name = "button_A";
            this.button_A.Size = new System.Drawing.Size(109, 23);
            this.button_A.TabIndex = 26;
            this.button_A.Text = "A (1)";
            this.button_A.UseVisualStyleBackColor = true;
            this.button_A.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_RAxis
            // 
            this.button_RAxis.Location = new System.Drawing.Point(623, 357);
            this.button_RAxis.Name = "button_RAxis";
            this.button_RAxis.Size = new System.Drawing.Size(109, 23);
            this.button_RAxis.TabIndex = 27;
            this.button_RAxis.Text = "RAxis";
            this.button_RAxis.UseVisualStyleBackColor = true;
            this.button_RAxis.Click += new System.EventHandler(this.button_Axis_Click);
            // 
            // button_RP
            // 
            this.button_RP.Location = new System.Drawing.Point(623, 386);
            this.button_RP.Name = "button_RP";
            this.button_RP.Size = new System.Drawing.Size(109, 23);
            this.button_RP.TabIndex = 28;
            this.button_RP.Text = "RAxis-Press (10)";
            this.button_RP.UseVisualStyleBackColor = true;
            this.button_RP.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_ZMinus
            // 
            this.button_ZMinus.Location = new System.Drawing.Point(623, 41);
            this.button_ZMinus.Name = "button_ZMinus";
            this.button_ZMinus.Size = new System.Drawing.Size(109, 23);
            this.button_ZMinus.TabIndex = 29;
            this.button_ZMinus.Text = "Z -";
            this.button_ZMinus.UseVisualStyleBackColor = true;
            this.button_ZMinus.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_L
            // 
            this.button_L.Location = new System.Drawing.Point(73, 90);
            this.button_L.Name = "button_L";
            this.button_L.Size = new System.Drawing.Size(109, 23);
            this.button_L.TabIndex = 30;
            this.button_L.Text = "L (6)";
            this.button_L.UseVisualStyleBackColor = true;
            this.button_L.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_LAxis
            // 
            this.button_LAxis.Location = new System.Drawing.Point(73, 190);
            this.button_LAxis.Name = "button_LAxis";
            this.button_LAxis.Size = new System.Drawing.Size(109, 23);
            this.button_LAxis.TabIndex = 31;
            this.button_LAxis.Text = "LAxis";
            this.button_LAxis.UseVisualStyleBackColor = true;
            this.button_LAxis.Click += new System.EventHandler(this.button_Axis_Click);
            // 
            // button_LP
            // 
            this.button_LP.Location = new System.Drawing.Point(73, 219);
            this.button_LP.Name = "button_LP";
            this.button_LP.Size = new System.Drawing.Size(109, 23);
            this.button_LP.TabIndex = 32;
            this.button_LP.Text = "LAxis-Press (9)";
            this.button_LP.UseVisualStyleBackColor = true;
            this.button_LP.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_BK
            // 
            this.button_BK.Location = new System.Drawing.Point(73, 263);
            this.button_BK.Name = "button_BK";
            this.button_BK.Size = new System.Drawing.Size(109, 23);
            this.button_BK.TabIndex = 33;
            this.button_BK.Text = "Back (7)";
            this.button_BK.UseVisualStyleBackColor = true;
            this.button_BK.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_ST
            // 
            this.button_ST.Location = new System.Drawing.Point(73, 319);
            this.button_ST.Name = "button_ST";
            this.button_ST.Size = new System.Drawing.Size(109, 23);
            this.button_ST.TabIndex = 34;
            this.button_ST.Text = "Start (8)";
            this.button_ST.UseVisualStyleBackColor = true;
            this.button_ST.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_PovUp
            // 
            this.button_PovUp.Location = new System.Drawing.Point(34, 377);
            this.button_PovUp.Name = "button_PovUp";
            this.button_PovUp.Size = new System.Drawing.Size(109, 23);
            this.button_PovUp.TabIndex = 35;
            this.button_PovUp.Text = "↑";
            this.button_PovUp.UseVisualStyleBackColor = true;
            this.button_PovUp.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_PovLeft
            // 
            this.button_PovLeft.Location = new System.Drawing.Point(12, 406);
            this.button_PovLeft.Name = "button_PovLeft";
            this.button_PovLeft.Size = new System.Drawing.Size(109, 23);
            this.button_PovLeft.TabIndex = 36;
            this.button_PovLeft.Text = "←";
            this.button_PovLeft.UseVisualStyleBackColor = true;
            this.button_PovLeft.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_PovDown
            // 
            this.button_PovDown.Location = new System.Drawing.Point(127, 406);
            this.button_PovDown.Name = "button_PovDown";
            this.button_PovDown.Size = new System.Drawing.Size(109, 23);
            this.button_PovDown.TabIndex = 37;
            this.button_PovDown.Text = "↓";
            this.button_PovDown.UseVisualStyleBackColor = true;
            this.button_PovDown.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_PovRight
            // 
            this.button_PovRight.Location = new System.Drawing.Point(149, 377);
            this.button_PovRight.Name = "button_PovRight";
            this.button_PovRight.Size = new System.Drawing.Size(109, 23);
            this.button_PovRight.TabIndex = 38;
            this.button_PovRight.Text = "→";
            this.button_PovRight.UseVisualStyleBackColor = true;
            this.button_PovRight.Click += new System.EventHandler(this.button_Button_Click);
            // 
            // button_Other
            // 
            this.button_Other.Location = new System.Drawing.Point(686, 9);
            this.button_Other.Name = "button_Other";
            this.button_Other.Size = new System.Drawing.Size(102, 23);
            this.button_Other.TabIndex = 39;
            this.button_Other.Text = "Additonal Key";
            this.button_Other.UseVisualStyleBackColor = true;
            this.button_Other.Click += new System.EventHandler(this.button_Other_Click);
            // 
            // button_Apply
            // 
            this.button_Apply.Location = new System.Drawing.Point(686, 415);
            this.button_Apply.Name = "button_Apply";
            this.button_Apply.Size = new System.Drawing.Size(102, 23);
            this.button_Apply.TabIndex = 40;
            this.button_Apply.Text = "Apply";
            this.button_Apply.UseVisualStyleBackColor = true;
            this.button_Apply.Click += new System.EventHandler(this.button_Apply_Click);
            // 
            // check_View
            // 
            this.check_View.AutoSize = true;
            this.check_View.BackColor = System.Drawing.Color.Transparent;
            this.check_View.Location = new System.Drawing.Point(12, 12);
            this.check_View.Name = "check_View";
            this.check_View.Size = new System.Drawing.Size(135, 16);
            this.check_View.TabIndex = 41;
            this.check_View.Text = "Show Current-Setting";
            this.check_View.UseVisualStyleBackColor = false;
            this.check_View.CheckedChanged += new System.EventHandler(this.check_View_CheckedChanged);
            // 
            // button_Combi
            // 
            this.button_Combi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Combi.Location = new System.Drawing.Point(516, 37);
            this.button_Combi.Name = "button_Combi";
            this.button_Combi.Size = new System.Drawing.Size(32, 20);
            this.button_Combi.TabIndex = 42;
            this.button_Combi.Text = "...";
            this.button_Combi.UseVisualStyleBackColor = true;
            this.button_Combi.Click += new System.EventHandler(this.button_Combi_Click);
            // 
            // ConfigMainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Combi);
            this.Controls.Add(this.check_View);
            this.Controls.Add(this.button_Apply);
            this.Controls.Add(this.button_Other);
            this.Controls.Add(this.button_PovRight);
            this.Controls.Add(this.button_PovDown);
            this.Controls.Add(this.button_PovLeft);
            this.Controls.Add(this.button_PovUp);
            this.Controls.Add(this.button_ST);
            this.Controls.Add(this.button_BK);
            this.Controls.Add(this.button_LP);
            this.Controls.Add(this.button_LAxis);
            this.Controls.Add(this.button_L);
            this.Controls.Add(this.button_ZMinus);
            this.Controls.Add(this.button_RP);
            this.Controls.Add(this.button_RAxis);
            this.Controls.Add(this.button_A);
            this.Controls.Add(this.button_B);
            this.Controls.Add(this.button_X);
            this.Controls.Add(this.button_Y);
            this.Controls.Add(this.button_R);
            this.Controls.Add(this.button_ZPlus);
            this.Controls.Add(this.combo_Combination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_RemoveApplication);
            this.Controls.Add(this.button_AddApplication);
            this.Controls.Add(this.combo_Application);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "ConfigMainDialog";
            this.Text = "ConfigMainDialog";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ConfigMainDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_RemoveApplication;
        private System.Windows.Forms.Button button_AddApplication;
        private System.Windows.Forms.ComboBox combo_Application;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Combination;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ZPlus;
        private System.Windows.Forms.Button button_R;
        private System.Windows.Forms.Button button_Y;
        private System.Windows.Forms.Button button_X;
        private System.Windows.Forms.Button button_B;
        private System.Windows.Forms.Button button_A;
        private System.Windows.Forms.Button button_RAxis;
        private System.Windows.Forms.Button button_RP;
        private System.Windows.Forms.Button button_ZMinus;
        private System.Windows.Forms.Button button_L;
        private System.Windows.Forms.Button button_LAxis;
        private System.Windows.Forms.Button button_LP;
        private System.Windows.Forms.Button button_BK;
        private System.Windows.Forms.Button button_ST;
        private System.Windows.Forms.Button button_PovUp;
        private System.Windows.Forms.Button button_PovLeft;
        private System.Windows.Forms.Button button_PovDown;
        private System.Windows.Forms.Button button_PovRight;
        private System.Windows.Forms.Button button_Other;
        private System.Windows.Forms.Button button_Apply;
        private System.Windows.Forms.CheckBox check_View;
        private System.Windows.Forms.Button button_Combi;
    }
}