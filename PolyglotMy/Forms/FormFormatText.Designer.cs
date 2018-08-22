namespace PolyglotMy
{
    partial class FormFormatText
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
            this.label2 = new System.Windows.Forms.Label();
            this.labelTranslate = new System.Windows.Forms.Label();
            this.labelOriginal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxOriginal = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLiteralTranslate = new System.Windows.Forms.RichTextBox();
            this.richTextBoxTranslate = new System.Windows.Forms.RichTextBox();
            this.richTextBoxNameText = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gBButtons = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.cmbTextes = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.gBButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 21;
            // 
            // labelTranslate
            // 
            this.labelTranslate.AutoSize = true;
            this.labelTranslate.Location = new System.Drawing.Point(377, 113);
            this.labelTranslate.Name = "labelTranslate";
            this.labelTranslate.Size = new System.Drawing.Size(51, 13);
            this.labelTranslate.TabIndex = 19;
            this.labelTranslate.Text = "Translate";
            // 
            // labelOriginal
            // 
            this.labelOriginal.AutoSize = true;
            this.labelOriginal.Location = new System.Drawing.Point(386, 405);
            this.labelOriginal.Name = "labelOriginal";
            this.labelOriginal.Size = new System.Drawing.Size(42, 13);
            this.labelOriginal.TabIndex = 18;
            this.labelOriginal.Text = "Original";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(377, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "LiteralTranslate";
            // 
            // richTextBoxOriginal
            // 
            this.richTextBoxOriginal.Location = new System.Drawing.Point(3, 421);
            this.richTextBoxOriginal.Name = "richTextBoxOriginal";
            this.richTextBoxOriginal.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxOriginal.TabIndex = 15;
            this.richTextBoxOriginal.Text = "";
            // 
            // richTextBoxLiteralTranslate
            // 
            this.richTextBoxLiteralTranslate.Location = new System.Drawing.Point(3, 274);
            this.richTextBoxLiteralTranslate.Name = "richTextBoxLiteralTranslate";
            this.richTextBoxLiteralTranslate.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxLiteralTranslate.TabIndex = 14;
            this.richTextBoxLiteralTranslate.Text = "";
            // 
            // richTextBoxTranslate
            // 
            this.richTextBoxTranslate.Location = new System.Drawing.Point(3, 131);
            this.richTextBoxTranslate.Name = "richTextBoxTranslate";
            this.richTextBoxTranslate.Size = new System.Drawing.Size(753, 126);
            this.richTextBoxTranslate.TabIndex = 11;
            this.richTextBoxTranslate.Text = "";
            // 
            // richTextBoxNameText
            // 
            this.richTextBoxNameText.Location = new System.Drawing.Point(3, 66);
            this.richTextBoxNameText.Name = "richTextBoxNameText";
            this.richTextBoxNameText.Size = new System.Drawing.Size(753, 44);
            this.richTextBoxNameText.TabIndex = 22;
            this.richTextBoxNameText.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Name of Text";
            // 
            // gBButtons
            // 
            this.gBButtons.Controls.Add(this.buttonDelete);
            this.gBButtons.Controls.Add(this.button1);
            this.gBButtons.Controls.Add(this.buttonAdd);
            this.gBButtons.Controls.Add(this.buttonCancel);
            this.gBButtons.Location = new System.Drawing.Point(3, 512);
            this.gBButtons.Name = "gBButtons";
            this.gBButtons.Size = new System.Drawing.Size(753, 38);
            this.gBButtons.TabIndex = 24;
            this.gBButtons.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 12);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(530, 12);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Clean";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // cmbTextes
            // 
            this.cmbTextes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTextes.FormattingEnabled = true;
            this.cmbTextes.Location = new System.Drawing.Point(12, 12);
            this.cmbTextes.Name = "cmbTextes";
            this.cmbTextes.Size = new System.Drawing.Size(734, 21);
            this.cmbTextes.TabIndex = 25;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(97, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormFormatText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 562);
            this.Controls.Add(this.cmbTextes);
            this.Controls.Add(this.gBButtons);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBoxNameText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTranslate);
            this.Controls.Add(this.labelOriginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxOriginal);
            this.Controls.Add(this.richTextBoxLiteralTranslate);
            this.Controls.Add(this.richTextBoxTranslate);
            this.Name = "FormFormatText";
            this.Text = "FormFormatText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddText_FormClosing);
            this.gBButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTranslate;
        private System.Windows.Forms.Label labelOriginal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxOriginal;
        private System.Windows.Forms.RichTextBox richTextBoxLiteralTranslate;
        private System.Windows.Forms.RichTextBox richTextBoxTranslate;
        private System.Windows.Forms.RichTextBox richTextBoxNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gBButtons;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox cmbTextes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDelete;
    }
}