using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;

namespace PolyglotMy
{
    

    public partial class FormSettingsText : Form
    {
        Form formbefore = new Form();
        SettingsText _settingstext = null;//обект для хранение данных для сериализации и возрата 

        public FormSettingsText()
        {
            InitializeComponent();
            _initControlls();
        }

        public FormSettingsText(Form formbefore)
        {
            this.formbefore = formbefore;
            InitializeComponent();
            _initControlls();
        }
        private void FormSettingsText_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            formbefore.Show();
        }
        private void buttonOK_Click(object sender, EventArgs e)//Кнопка окей. Сериализует и закрывает после форму.
        {
            saved_inf();
            formbefore.Show();
            this.Close();
        }

        private void saved_inf()//Изменение данных и сериализация
        {
            Color c = new Color();
            c = txtBox.BackColor;
            _settingstext.BackColor = c.ToArgb();
            c = txtBox.ForeColor;
            _settingstext.TextColor = c.ToArgb();
            _settingstext.TextFont = new BoxFont(txtBox.Font);
            _settingstext.Save();  //Сериализация     

            
        }

        private void buttonAplly_Click(object sender, EventArgs e)//Кнопка подтвердить
        {
            saved_inf();
        }

        private void buttonCancel_Click(object sender, EventArgs e)//Кнопка отмены возращает прошлые настройки
        {
            _initControlls();
        }

        private void _initControlls()//Загрузка елементов или десирреализация
        {
            _settingstext = SettingsText.GetSettings(); //Десериализация
            
            try
            {
                txtBox.BackColor = Color.FromArgb(_settingstext.BackColor);
            }
            catch { }
            try
            {
                txtBox.ForeColor = Color.FromArgb(_settingstext.TextColor);
            }
            catch { }          
            try
            {
                txtBox.Font = _settingstext.TextFont.GetFont();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)//Изменение шрифтов
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBox.Font = fontDialog1.Font;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)//Изменение цвета для текста и фона
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (rbtn1.Checked == true)
                {
                    txtBox.ForeColor = colorDialog1.Color;
                }
                else
                {
                    txtBox.BackColor = colorDialog1.Color;
                }
            }
        }

        private void FormSettingsText_FormClosing(object sender, FormClosingEventArgs e)
        {
            formbefore.Show();
        }
    }
}
