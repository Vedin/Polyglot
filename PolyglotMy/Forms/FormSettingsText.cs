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
            //_initControlls();
        }

        private void buttonOK_Click(object sender, EventArgs e)//Кнопка окей. Сериализует и закрывает после форму.
        {
            saved_inf();
            this.Close();
        }

        private void saved_inf()//Изменение данных и сериализация
        {
            Color c = new Color();
            c = txtBox.SelectionBackColor;
            _settingstext.BackColor = c.ToArgb();
            c = txtBox.SelectionColor;
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
            try
            {
                _settingstext = SettingsText.GetSettings(); //Десериализация
                txtBox.Text = "Ві можете змінювати колір та шрифт тексту в данному вікні. Ці налаштування будуть перенесенні до головного вікна.";
                txtBox.SelectAll();
                try
                {
                    txtBox.SelectionBackColor = Color.FromArgb(_settingstext.BackColor);
                    txtBox.SelectionColor = Color.FromArgb(_settingstext.TextColor);
                    txtBox.Font = _settingstext.TextFont.GetFont();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Form1.Massage(ex), Globals.ERR + ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtBox.Select(0,0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(Form1.Massage(ex), Globals.ERR + ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
                txtBox.SelectAll();

                if (rbtn1.Checked == true)
                {
                    txtBox.SelectionColor = colorDialog1.Color;
                }
                else
                {
                    txtBox.SelectionBackColor = colorDialog1.Color;
                }
            }
        }

        private void FormSettingsText_FormClosing(object sender, FormClosingEventArgs e)
        {
            formbefore.Show();
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoadSettingsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Polyglot (*.xml)|*.xml|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string defaultFileName = Globals.SettingsFileText;
                Globals.SettingsFileText = openFileDialog.FileName;
                _initControlls();
                Globals.SettingsFileText = defaultFileName;
            }
        }

        private void SaveSettTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Polyglot (*.xml)|*.xml|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string defaultFileName = Globals.SettingsFileText;
                Globals.SettingsFileText = saveFileDialog.FileName;
                saved_inf();
                Globals.SettingsFileText = defaultFileName;
            }

        }
    }
}
