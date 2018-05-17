using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
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
                AllReadersLoadSettings();
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
                AllReadersLoadVoice();
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