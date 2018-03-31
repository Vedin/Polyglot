namespace PolyglotMy
{
    partial class FormSettingsText
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
            this.gBText = new System.Windows.Forms.GroupBox();
            this.txtBox = new System.Windows.Forms.RichTextBox();
            this.gBTextFont = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gBTextColour = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.gBButtons = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonAplly = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.gBText.SuspendLayout();
            this.gBTextFont.SuspendLayout();
            this.gBTextColour.SuspendLayout();
            this.gBButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBText
            // 
            this.gBText.Controls.Add(this.txtBox);
            this.gBText.Location = new System.Drawing.Point(12, 12);
            this.gBText.Name = "gBText";
            this.gBText.Size = new System.Drawing.Size(548, 237);
            this.gBText.TabIndex = 7;
            this.gBText.TabStop = false;
            this.gBText.Text = "Текст";
            // 
            // txtBox
            // 
            this.txtBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBox.Location = new System.Drawing.Point(6, 19);
            this.txtBox.Name = "txtBox";
            this.txtBox.ReadOnly = true;
            this.txtBox.Size = new System.Drawing.Size(536, 212);
            this.txtBox.TabIndex = 3;
            this.txtBox.Text = "";
            this.txtBox.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // gBTextFont
            // 
            this.gBTextFont.Controls.Add(this.button2);
            this.gBTextFont.ForeColor = System.Drawing.Color.Black;
            this.gBTextFont.Location = new System.Drawing.Point(12, 255);
            this.gBTextFont.Name = "gBTextFont";
            this.gBTextFont.Size = new System.Drawing.Size(282, 98);
            this.gBTextFont.TabIndex = 10;
            this.gBTextFont.TabStop = false;
            this.gBTextFont.Text = "Шрифт";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(6, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Обрати шрифт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gBTextColour
            // 
            this.gBTextColour.Controls.Add(this.button1);
            this.gBTextColour.Controls.Add(this.rbtn2);
            this.gBTextColour.Controls.Add(this.rbtn1);
            this.gBTextColour.Location = new System.Drawing.Point(300, 255);
            this.gBTextColour.Name = "gBTextColour";
            this.gBTextColour.Size = new System.Drawing.Size(260, 98);
            this.gBTextColour.TabIndex = 11;
            this.gBTextColour.TabStop = false;
            this.gBTextColour.Text = "Колір";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Обрати колір";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(78, 19);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(48, 17);
            this.rbtn2.TabIndex = 1;
            this.rbtn2.Text = "Фон";
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Checked = true;
            this.rbtn1.Location = new System.Drawing.Point(6, 19);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(55, 17);
            this.rbtn1.TabIndex = 0;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "Текст";
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // gBButtons
            // 
            this.gBButtons.Controls.Add(this.buttonOK);
            this.gBButtons.Controls.Add(this.buttonAplly);
            this.gBButtons.Controls.Add(this.buttonCancel);
            this.gBButtons.Location = new System.Drawing.Point(12, 371);
            this.gBButtons.Name = "gBButtons";
            this.gBButtons.Size = new System.Drawing.Size(548, 40);
            this.gBButtons.TabIndex = 13;
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
            // 
            // FormSettingsText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 423);
            this.Controls.Add(this.gBButtons);
            this.Controls.Add(this.gBTextFont);
            this.Controls.Add(this.gBTextColour);
            this.Controls.Add(this.gBText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettingsText";
            this.Text = "SettingsText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettingsText_FormClosing);
            this.gBText.ResumeLayout(false);
            this.gBTextFont.ResumeLayout(false);
            this.gBTextColour.ResumeLayout(false);
            this.gBTextColour.PerformLayout();
            this.gBButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gBText;
        private System.Windows.Forms.RichTextBox txtBox;
        private System.Windows.Forms.GroupBox gBTextFont;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gBTextColour;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.GroupBox gBButtons;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonAplly;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}