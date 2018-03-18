namespace PolyglotMy
{
    partial class FormSettings
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAplly = new System.Windows.Forms.Button();
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.gBMenuSettings = new System.Windows.Forms.GroupBox();
            this.MenuButtonEqulizer = new System.Windows.Forms.Button();
            this.MenuButtonText = new System.Windows.Forms.Button();
            this.gBText = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gBButtons = new System.Windows.Forms.GroupBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gBTextColour = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.gBTextFont = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.gBEqulizer = new System.Windows.Forms.GroupBox();
            this.SliderRight = new System.Windows.Forms.TrackBar();
            this.SliderMid = new System.Windows.Forms.TrackBar();
            this.SliderLeft = new System.Windows.Forms.TrackBar();
            this.gBMenuSettings.SuspendLayout();
            this.gBText.SuspendLayout();
            this.gBButtons.SuspendLayout();
            this.gBTextColour.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gBTextFont.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gBEqulizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(451, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(234, 11);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonAplly
            // 
            this.buttonAplly.Location = new System.Drawing.Point(342, 11);
            this.buttonAplly.Name = "buttonAplly";
            this.buttonAplly.Size = new System.Drawing.Size(75, 23);
            this.buttonAplly.TabIndex = 1;
            this.buttonAplly.Text = "Aplly";
            this.buttonAplly.UseVisualStyleBackColor = true;
            this.buttonAplly.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(6, 19);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(536, 212);
            this.txtBox.TabIndex = 3;
            this.txtBox.Text = "";
            // 
            // gBMenuSettings
            // 
            this.gBMenuSettings.Controls.Add(this.MenuButtonEqulizer);
            this.gBMenuSettings.Controls.Add(this.MenuButtonText);
            this.gBMenuSettings.Location = new System.Drawing.Point(1, 35);
            this.gBMenuSettings.Name = "gBMenuSettings";
            this.gBMenuSettings.Size = new System.Drawing.Size(139, 425);
            this.gBMenuSettings.TabIndex = 5;
            this.gBMenuSettings.TabStop = false;
            // 
            // MenuButtonEqulizer
            // 
            this.MenuButtonEqulizer.Location = new System.Drawing.Point(6, 70);
            this.MenuButtonEqulizer.Name = "MenuButtonEqulizer";
            this.MenuButtonEqulizer.Size = new System.Drawing.Size(127, 45);
            this.MenuButtonEqulizer.TabIndex = 1;
            this.MenuButtonEqulizer.Text = "Equalizer";
            this.MenuButtonEqulizer.UseVisualStyleBackColor = true;
            this.MenuButtonEqulizer.Visible = false;
            this.MenuButtonEqulizer.Click += new System.EventHandler(this.button4_Click);
            // 
            // MenuButtonText
            // 
            this.MenuButtonText.Location = new System.Drawing.Point(6, 19);
            this.MenuButtonText.Name = "MenuButtonText";
            this.MenuButtonText.Size = new System.Drawing.Size(127, 45);
            this.MenuButtonText.TabIndex = 0;
            this.MenuButtonText.Text = "Text";
            this.MenuButtonText.UseVisualStyleBackColor = true;
            this.MenuButtonText.Click += new System.EventHandler(this.button3_Click);
            // 
            // gBText
            // 
            this.gBText.Controls.Add(this.txtBox);
            this.gBText.Location = new System.Drawing.Point(146, 73);
            this.gBText.Name = "gBText";
            this.gBText.Size = new System.Drawing.Size(548, 237);
            this.gBText.TabIndex = 6;
            this.gBText.TabStop = false;
            this.gBText.Text = "Text";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(146, 35);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(548, 32);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // gBButtons
            // 
            this.gBButtons.Controls.Add(this.buttonOK);
            this.gBButtons.Controls.Add(this.buttonAplly);
            this.gBButtons.Controls.Add(this.buttonCancel);
            this.gBButtons.Location = new System.Drawing.Point(148, 420);
            this.gBButtons.Name = "gBButtons";
            this.gBButtons.Size = new System.Drawing.Size(548, 40);
            this.gBButtons.TabIndex = 10;
            this.gBButtons.TabStop = false;
            // 
            // gBTextColour
            // 
            this.gBTextColour.Controls.Add(this.button1);
            this.gBTextColour.Controls.Add(this.rbtn2);
            this.gBTextColour.Controls.Add(this.rbtn1);
            this.gBTextColour.Location = new System.Drawing.Point(288, 0);
            this.gBTextColour.Name = "gBTextColour";
            this.gBTextColour.Size = new System.Drawing.Size(260, 98);
            this.gBTextColour.TabIndex = 9;
            this.gBTextColour.TabStop = false;
            this.gBTextColour.Text = "Colour";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "More colours";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(78, 19);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(85, 17);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.Text = "BackGround";
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Checked = true;
            this.rbtn1.Location = new System.Drawing.Point(6, 19);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(46, 17);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "Text";
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.gBTextFont);
            this.groupBox8.Controls.Add(this.gBTextColour);
            this.groupBox8.Location = new System.Drawing.Point(146, 316);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(548, 98);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // gBTextFont
            // 
            this.gBTextFont.Controls.Add(this.button2);
            this.gBTextFont.ForeColor = System.Drawing.Color.Black;
            this.gBTextFont.Location = new System.Drawing.Point(0, 0);
            this.gBTextFont.Name = "gBTextFont";
            this.gBTextFont.Size = new System.Drawing.Size(282, 98);
            this.gBTextFont.TabIndex = 8;
            this.gBTextFont.TabStop = false;
            this.gBTextFont.Text = "Font";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(6, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Change Font";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSettingsToolStripMenuItem,
            this.downloadSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.saveSettingsToolStripMenuItem.Text = "Save settings";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // downloadSettingsToolStripMenuItem
            // 
            this.downloadSettingsToolStripMenuItem.Name = "downloadSettingsToolStripMenuItem";
            this.downloadSettingsToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.downloadSettingsToolStripMenuItem.Text = "Download settings";
            this.downloadSettingsToolStripMenuItem.Click += new System.EventHandler(this.downloadSettingsToolStripMenuItem_Click);
            // 
            // gBEqulizer
            // 
            this.gBEqulizer.Controls.Add(this.SliderRight);
            this.gBEqulizer.Controls.Add(this.SliderMid);
            this.gBEqulizer.Controls.Add(this.SliderLeft);
            this.gBEqulizer.Location = new System.Drawing.Point(146, 73);
            this.gBEqulizer.Name = "gBEqulizer";
            this.gBEqulizer.Size = new System.Drawing.Size(548, 237);
            this.gBEqulizer.TabIndex = 2;
            this.gBEqulizer.TabStop = false;
            this.gBEqulizer.Text = "Equalizer";
            this.gBEqulizer.Visible = false;
            // 
            // SliderRight
            // 
            this.SliderRight.Location = new System.Drawing.Point(338, 55);
            this.SliderRight.Name = "SliderRight";
            this.SliderRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderRight.Size = new System.Drawing.Size(45, 135);
            this.SliderRight.TabIndex = 2;
            this.SliderRight.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SliderMid
            // 
            this.SliderMid.Location = new System.Drawing.Point(228, 55);
            this.SliderMid.Name = "SliderMid";
            this.SliderMid.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderMid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderMid.Size = new System.Drawing.Size(45, 135);
            this.SliderMid.TabIndex = 1;
            this.SliderMid.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SliderLeft
            // 
            this.SliderLeft.Location = new System.Drawing.Point(118, 55);
            this.SliderLeft.Name = "SliderLeft";
            this.SliderLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderLeft.Size = new System.Drawing.Size(45, 135);
            this.SliderLeft.TabIndex = 0;
            this.SliderLeft.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 466);
            this.Controls.Add(this.gBEqulizer);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.gBButtons);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gBText);
            this.Controls.Add(this.gBMenuSettings);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gBMenuSettings.ResumeLayout(false);
            this.gBText.ResumeLayout(false);
            this.gBButtons.ResumeLayout(false);
            this.gBTextColour.ResumeLayout(false);
            this.gBTextColour.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.gBTextFont.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBEqulizer.ResumeLayout(false);
            this.gBEqulizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAplly;
        private System.Windows.Forms.RichTextBox txtBox;
        private System.Windows.Forms.GroupBox gBMenuSettings;
        private System.Windows.Forms.GroupBox gBText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gBButtons;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox gBTextColour;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox gBTextFont;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button MenuButtonEqulizer;
        private System.Windows.Forms.Button MenuButtonText;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadSettingsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox gBEqulizer;
        private System.Windows.Forms.TrackBar SliderRight;
        private System.Windows.Forms.TrackBar SliderMid;
        private System.Windows.Forms.TrackBar SliderLeft;
    }
}

