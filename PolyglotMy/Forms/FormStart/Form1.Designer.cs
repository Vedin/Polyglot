namespace PolyglotMy
{
    partial class Form1
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
            this.richTextBoxOriginal = new System.Windows.Forms.RichTextBox();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.richTextBoxLiteralTranslate = new System.Windows.Forms.RichTextBox();
            this.richTextBoxTranslate = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиТекстДоБібліотекиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.еквалайзерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTranslate = new System.Windows.Forms.Label();
            this.labelT = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTextes = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxOriginal
            // 
            this.richTextBoxOriginal.Location = new System.Drawing.Point(32, 74);
            this.richTextBoxOriginal.Name = "richTextBoxOriginal";
            this.richTextBoxOriginal.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxOriginal.TabIndex = 0;
            this.richTextBoxOriginal.Text = "";
            this.richTextBoxOriginal.TextChanged += new System.EventHandler(this.RichTextBoxTranslate_TextChanged);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(32, 19);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(86, 50);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(124, 19);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(82, 49);
            this.buttonPause.TabIndex = 2;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // richTextBoxLiteralTranslate
            // 
            this.richTextBoxLiteralTranslate.Location = new System.Drawing.Point(32, 217);
            this.richTextBoxLiteralTranslate.Name = "richTextBoxLiteralTranslate";
            this.richTextBoxLiteralTranslate.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxLiteralTranslate.TabIndex = 3;
            this.richTextBoxLiteralTranslate.Text = "";
            // 
            // richTextBoxTranslate
            // 
            this.richTextBoxTranslate.Location = new System.Drawing.Point(32, 364);
            this.richTextBoxTranslate.Name = "richTextBoxTranslate";
            this.richTextBoxTranslate.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxTranslate.TabIndex = 4;
            this.richTextBoxTranslate.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиТекстДоБібліотекиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // додатиТекстДоБібліотекиToolStripMenuItem
            // 
            this.додатиТекстДоБібліотекиToolStripMenuItem.Name = "додатиТекстДоБібліотекиToolStripMenuItem";
            this.додатиТекстДоБібліотекиToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.додатиТекстДоБібліотекиToolStripMenuItem.Text = "Додати текст до бібліотеки";
            this.додатиТекстДоБібліотекиToolStripMenuItem.Click += new System.EventHandler(this.AddTextToLibraryToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.еквалайзерToolStripMenuItem,
            this.тектToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // еквалайзерToolStripMenuItem
            // 
            this.еквалайзерToolStripMenuItem.Name = "еквалайзерToolStripMenuItem";
            this.еквалайзерToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.еквалайзерToolStripMenuItem.Text = "Еквалайзер";
            this.еквалайзерToolStripMenuItem.Click += new System.EventHandler(this.OpenFormSettingsEquilezer);
            // 
            // тектToolStripMenuItem
            // 
            this.тектToolStripMenuItem.Name = "тектToolStripMenuItem";
            this.тектToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.тектToolStripMenuItem.Text = "Тект";
            this.тектToolStripMenuItem.Click += new System.EventHandler(this.OpenFormSettingsText);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(212, 19);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(86, 50);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTranslate
            // 
            this.labelTranslate.AutoSize = true;
            this.labelTranslate.Location = new System.Drawing.Point(415, 348);
            this.labelTranslate.Name = "labelTranslate";
            this.labelTranslate.Size = new System.Drawing.Size(51, 13);
            this.labelTranslate.TabIndex = 7;
            this.labelTranslate.Text = "Translate";
            // 
            // labelT
            // 
            this.labelT.AutoSize = true;
            this.labelT.Location = new System.Drawing.Point(406, 56);
            this.labelT.Name = "labelT";
            this.labelT.Size = new System.Drawing.Size(42, 13);
            this.labelT.TabIndex = 8;
            this.labelT.Text = "Original";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "LiteralTranslate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(719, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 10;
            // 
            // cmbTextes
            // 
            this.cmbTextes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextes.FormattingEnabled = true;
            this.cmbTextes.Location = new System.Drawing.Point(304, 19);
            this.cmbTextes.Name = "cmbTextes";
            this.cmbTextes.Size = new System.Drawing.Size(481, 21);
            this.cmbTextes.TabIndex = 11;
            this.cmbTextes.SelectedIndexChanged += new System.EventHandler(this.cmbTextes_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 512);
            this.Controls.Add(this.cmbTextes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelT);
            this.Controls.Add(this.labelTranslate);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.richTextBoxTranslate);
            this.Controls.Add(this.richTextBoxLiteralTranslate);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.richTextBoxOriginal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TextToSpeech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxOriginal;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.RichTextBox richTextBoxLiteralTranslate;
        private System.Windows.Forms.RichTextBox richTextBoxTranslate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem еквалайзерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тектToolStripMenuItem;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTranslate;
        private System.Windows.Forms.Label labelT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem додатиТекстДоБібліотекиToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbTextes;
    }
}

