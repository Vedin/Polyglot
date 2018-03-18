using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PolyglotMy
{
    public partial class FormSettings : Form
    {
        Settings _settings = null;
        SettingsEqualizer _settingsequalizer = null;

        private string typesettings { get; set; }
        private Form formbefore;
        public FormSettings()
        {            
        }
        
        public FormSettings(Form data = null)
        {
            InitializeComponent();
            _settings = Settings.GetSettings();
            _settingsequalizer =new SettingsEqualizer();
            _initControlls();
            formbefore = data;          
        }
        private void _initControlls()
        {
           //Text
            try
            {
                txtBox.BackColor = Color.FromArgb(_settings.backcolor);
            }
            catch { }
            try
            {
                txtBox.ForeColor = Color.FromArgb(_settings.forecolor);

            }
            catch { }
           // txtBox.Text = " Текст для проверки настроек!";
            //Equlizer
            SliderLeft.Maximum = Globals.EqulizerSliderMaxValue;
            SliderRight.Maximum = Globals.EqulizerSliderMaxValue;
            SliderMid.Maximum = Globals.EqulizerSliderMaxValue;
            SliderLeft.Minimum = Globals.EqulizerSliderMinValue;
            SliderRight.Minimum = Globals.EqulizerSliderMinValue;
            SliderMid.Minimum = Globals.EqulizerSliderMinValue;

            try
            {
                SliderLeft.Value = _settingsequalizer.SliderLeft;
            }
            catch { }
            try
            {
                SliderRight.Value = _settingsequalizer.SliderRight;
            }
            catch { }
            try
            {
                SliderMid.Value = _settingsequalizer.SliderMid;
            }
            catch { }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            downl_inf();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saved_inf();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
           
            formbefore.Show();
            saved_inf();
            this.Close();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            _initControlls();
        }
        private void saved_inf()
        {
            // _settings.backcolor = ColorTranslator.ToHtml(txtBox.BackColor);
            Color c = new Color();
            c = txtBox.BackColor;
            _settings.backcolor = c.ToArgb();
            c = txtBox.ForeColor;
            _settings.forecolor = c.ToArgb();
           // _settings.textfont.Font = txtBox.Font;
            _settings.Save();
            _settingsequalizer.SliderLeft = SliderLeft.Value;
            _settingsequalizer.SliderMid = SliderMid.Value;
            _settingsequalizer.SliderRight = SliderRight.Value;
            _settingsequalizer.Save();      
        }
        private void downl_inf()
        {
            txtBox.Text = "Текст для проверки настроек!";
        }
        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                txtBox.Font = fontDialog1.Font;
            }
         //   Font a = new

        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            // SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "All files (*.*)|*.*|txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter writer = new StreamWriter(myStream); //создаем «потоковый писатель» и связываем его с файловым потоком 
                    writer.Write(txtBox.Text); //записываем в файл
                    writer.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется 

                    myStream.Close();

                }
            }

        }

        private void downloadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormSettings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            formbefore.Show();
        }

        private void button3_Click(object sender, EventArgs e)//MenuButtonText
        {
            gBText.Show();
            gBEqulizer.Hide();
            typesettings = "Text";
        }

        private void button4_Click(object sender, EventArgs e)//MenuBuutonEqulizer
        {
            gBEqulizer.Show();
            gBText.Hide();
            typesettings = "Equlixer";     
        }
    }
}
