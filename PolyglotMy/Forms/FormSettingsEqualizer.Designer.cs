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
            this.gBEqulizer = new System.Windows.Forms.GroupBox();
            this.SliderRight = new System.Windows.Forms.TrackBar();
            this.SliderMid = new System.Windows.Forms.TrackBar();
            this.SliderLeft = new System.Windows.Forms.TrackBar();
            this.gBTextFont = new System.Windows.Forms.GroupBox();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.gBTextColour = new System.Windows.Forms.GroupBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.gBButtons = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAplly = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.gBEqulizer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).BeginInit();
            this.gBTextFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.gBTextColour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.gBButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBEqulizer
            // 
            this.gBEqulizer.Controls.Add(this.SliderRight);
            this.gBEqulizer.Controls.Add(this.SliderMid);
            this.gBEqulizer.Controls.Add(this.SliderLeft);
            this.gBEqulizer.Location = new System.Drawing.Point(12, 12);
            this.gBEqulizer.Name = "gBEqulizer";
            this.gBEqulizer.Size = new System.Drawing.Size(548, 237);
            this.gBEqulizer.TabIndex = 3;
            this.gBEqulizer.TabStop = false;
            this.gBEqulizer.Text = "Еквалайзер";
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
            // gBTextFont
            // 
            this.gBTextFont.Controls.Add(this.trackBarSpeed);
            this.gBTextFont.ForeColor = System.Drawing.Color.Black;
            this.gBTextFont.Location = new System.Drawing.Point(12, 255);
            this.gBTextFont.Name = "gBTextFont";
            this.gBTextFont.Size = new System.Drawing.Size(282, 98);
            this.gBTextFont.TabIndex = 10;
            this.gBTextFont.TabStop = false;
            this.gBTextFont.Text = "Гучність";
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
            this.gBTextColour.Location = new System.Drawing.Point(300, 255);
            this.gBTextColour.Name = "gBTextColour";
            this.gBTextColour.Size = new System.Drawing.Size(260, 98);
            this.gBTextColour.TabIndex = 11;
            this.gBTextColour.TabStop = false;
            this.gBTextColour.Text = "Швидкість програвання";
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
            // FormSettingsEqualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 401);
            this.Controls.Add(this.gBButtons);
            this.Controls.Add(this.gBTextFont);
            this.Controls.Add(this.gBTextColour);
            this.Controls.Add(this.gBEqulizer);
            this.Name = "FormSettingsEqualizer";
            this.Text = "SettingsEqulizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingsEqualizer_FormClosing);
            this.gBEqulizer.ResumeLayout(false);
            this.gBEqulizer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SliderRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderMid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SliderLeft)).EndInit();
            this.gBTextFont.ResumeLayout(false);
            this.gBTextFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.gBTextColour.ResumeLayout(false);
            this.gBTextColour.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.gBButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBEqulizer;
        private System.Windows.Forms.TrackBar SliderRight;
        private System.Windows.Forms.TrackBar SliderMid;
        private System.Windows.Forms.TrackBar SliderLeft;
        private System.Windows.Forms.GroupBox gBTextFont;
        private System.Windows.Forms.GroupBox gBTextColour;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.GroupBox gBButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAplly;
        private System.Windows.Forms.Button buttonCancel;
    }
}