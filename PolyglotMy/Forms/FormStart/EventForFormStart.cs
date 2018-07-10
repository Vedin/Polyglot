using System;
using System.Windows.Forms;

namespace PolyglotMy
{
    partial class Form1 : Form
    {
        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            //  allTexts.Save();//Save all names and files of texts
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AllReadersLoadVoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                AllReadersLoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                LoaderSettiingsForAllTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (settings == SettingsChanged.Equlizer)
            {
                try
                {
                    AllReadersLoadVoice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Massage(ex), Globals.ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                AllReadersLoadSettings();
            }
            if (settings == SettingsChanged.Text)
            {
                LoaderSettiingsForAllTextBox();
            }
            settings = SettingsChanged.None;
        }
    }
}