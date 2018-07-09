namespace PolyglotMy
{
    partial class FormSettingsEqualizer
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
            this.gBTextFont = new System.Windows.Forms.GroupBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.gBTextColour = new System.Windows.Forms.GroupBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.gBButtons = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAplly = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveSettTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SliderLeft = new System.Windows.Forms.TrackBar();
            this.SliderMid = new System.Windows.Forms.TrackBar();
            this.SliderRight = new System.Windows.Forms.TrackBar();
            this.gBEqulizer = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDWords = new System.Windows.Forms.NumericUpDown();
            this.numericUpDSentence = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.gBTextFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.gBTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.gBButtons.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).BeginInit();
            this.gBEqulizer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDSentence)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBTextFont
            // 
            this.gBTextFont.Controls.Add(this.trackBarSpeed);
            this.gBTextFont.ForeColor = System.Drawing.Color.Black;
            this.gBTextFont.Location = new System.Drawing.Point(12, 266);
            this.gBTextFont.Name = "gBTextFont";
            this.gBTextFont.Size = new System.Drawing.Size(282, 98);
            this.gBTextFont.TabIndex = 10;
            this.gBTextFont.TabStop = false;
            this.gBTextFont.Text = "Швидкість програвання";
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(61, 32);
            this.trackBarSpeed.Minimum = -10;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(165, 45);
            this.trackBarSpeed.TabIndex = 7;
            // 
            // gBTextColour
            // 
            this.gBTextColour.Controls.Add(this.trackBarVolume);
            this.gBTextColour.Location = new System.Drawing.Point(300, 266);
            this.gBTextColour.Name = "gBTextColour";
            this.gBTextColour.Size = new System.Drawing.Size(260, 98);
            this.gBTextColour.TabIndex = 11;
            this.gBTextColour.TabStop = false;
            this.gBTextColour.Text = "Гучність";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(37, 32);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(187, 45);
            this.trackBarVolume.TabIndex = 8;
            this.trackBarVolume.Value = 100;
            // 
            // gBButtons
            // 
            this.gBButtons.Controls.Add(this.buttonOK);
            this.gBButtons.Controls.Add(this.buttonAplly);
            this.gBButtons.Controls.Add(this.buttonCancel);
            this.gBButtons.Location = new System.Drawing.Point(12, 359);
            this.gBButtons.Name = "gBButtons";
            this.gBButtons.Size = new System.Drawing.Size(548, 40);
            this.gBButtons.TabIndex = 12;
            this.gBButtons.TabStop = false;
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
            this.buttonAplly.Text = "Підвердити";
            this.buttonAplly.UseVisualStyleBackColor = true;
            this.buttonAplly.Click += new System.EventHandler(this.buttonAplly_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(451, 11);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Відмінити";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveSettTextToolStripMenuItem,
            this.тектToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.настройкиToolStripMenuItem.Text = "Файл";
            // 
            // SaveSettTextToolStripMenuItem
            // 
            this.SaveSettTextToolStripMenuItem.Name = "SaveSettTextToolStripMenuItem";
            this.SaveSettTextToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.SaveSettTextToolStripMenuItem.Text = "Сохранить настройки как...";
            this.SaveSettTextToolStripMenuItem.Click += new System.EventHandler(this.SaveSettTextToolStripMenuItem_Click);
            // 
            // тектToolStripMenuItem
            // 
            this.тектToolStripMenuItem.Name = "тектToolStripMenuItem";
            this.тектToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.тектToolStripMenuItem.Text = "Загрузить настройки из файла...";
            this.тектToolStripMenuItem.Click += new System.EventHandler(this.тектToolStripMenuItem_Click);
            // 
            // SliderLeft
            // 
            this.SliderLeft.Location = new System.Drawing.Point(119, 18);
            this.SliderLeft.Name = "SliderLeft";
            this.SliderLeft.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderLeft.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderLeft.Size = new System.Drawing.Size(45, 135);
            this.SliderLeft.TabIndex = 0;
            this.SliderLeft.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SliderMid
            // 
            this.SliderMid.Location = new System.Drawing.Point(234, 18);
            this.SliderMid.Name = "SliderMid";
            this.SliderMid.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderMid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderMid.Size = new System.Drawing.Size(45, 135);
            this.SliderMid.TabIndex = 1;
            this.SliderMid.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // SliderRight
            // 
            this.SliderRight.Location = new System.Drawing.Point(342, 18);
            this.SliderRight.Name = "SliderRight";
            this.SliderRight.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SliderRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SliderRight.Size = new System.Drawing.Size(45, 135);
            this.SliderRight.TabIndex = 2;
            this.SliderRight.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // gBEqulizer
            // 
            this.gBEqulizer.Controls.Add(this.SliderRight);
            this.gBEqulizer.Controls.Add(this.SliderMid);
            this.gBEqulizer.Controls.Add(this.SliderLeft);
            this.gBEqulizer.Location = new System.Drawing.Point(12, 27);
            this.gBEqulizer.Name = "gBEqulizer";
            this.gBEqulizer.Size = new System.Drawing.Size(548, 159);
            this.gBEqulizer.TabIndex = 3;
            this.gBEqulizer.TabStop = false;
            this.gBEqulizer.Text = "Еквалайзер";
            this.gBEqulizer.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericUpDWords);
            this.groupBox1.Controls.Add(this.numericUpDSentence);
            this.groupBox1.Location = new System.Drawing.Point(12, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 73);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Паузи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Між словами";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(419, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Між реченями";
            // 
            // numericUpDWords
            // 
            this.numericUpDWords.Location = new System.Drawing.Point(129, 47);
            this.numericUpDWords.Name = "numericUpDWords";
            this.numericUpDWords.Size = new System.Drawing.Size(120, 20);
            this.numericUpDWords.TabIndex = 1;
            // 
            // numericUpDSentence
            // 
            this.numericUpDSentence.Location = new System.Drawing.Point(422, 47);
            this.numericUpDSentence.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDSentence.Name = "numericUpDSentence";
            this.numericUpDSentence.Size = new System.Drawing.Size(120, 20);
            this.numericUpDSentence.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.cmbVoices);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 54);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voices...";
            // 
            // cmbVoices
            // 
            this.cmbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(18, 22);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(508, 21);
            this.cmbVoices.TabIndex = 0;
            // 
            // FormSettingsEqualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 401);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gBButtons);
            this.Controls.Add(this.gBTextFont);
            this.Controls.Add(this.gBTextColour);
            this.Controls.Add(this.gBEqulizer);
            this.Name = "FormSettingsEqualizer";
            this.Text = "SettingsEqulizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingsEqualizer_FormClosing);
            this.gBTextFont.ResumeLayout(false);
            this.gBTextFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.gBTextColour.ResumeLayout(false);
            this.gBTextColour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.gBButtons.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).EndInit();
            this.gBEqulizer.ResumeLayout(false);
            this.gBEqulizer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDSentence)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gBTextFont;
        private System.Windows.Forms.GroupBox gBTextColour;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.GroupBox gBButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAplly;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveSettTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тектToolStripMenuItem;
        private System.Windows.Forms.TrackBar SliderLeft;
        private System.Windows.Forms.TrackBar SliderMid;
        private System.Windows.Forms.TrackBar SliderRight;
        private System.Windows.Forms.GroupBox gBEqulizer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDWords;
        private System.Windows.Forms.NumericUpDown numericUpDSentence;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbVoices;
    }
}