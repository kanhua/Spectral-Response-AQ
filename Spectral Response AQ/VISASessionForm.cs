using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.VisaNS;


namespace Spectral_Response_AQ
{
    public partial class VISASessionForm : Form
    {
        private MessageBasedSession mbSession;
        
        public VISASessionForm()
        {
            InitializeComponent();
        }

        private void refreshListButton_Click(object sender, EventArgs e)
        {
            string[] resources = ResourceManager.GetLocalManager().FindResources("?*");
            foreach (string s in resources)
            {
                sessionListBox.Items.Add(s);
            }
            sessionListBox.Items.Add("TCPIP[board]::host address[::LAN device name][::INSTR]");
            sessionListBox.Items.Add("TCPIP[board]::host address::port::SOCKET");
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            try
            {
                mbSession = (MessageBasedSession)ResourceManager.GetLocalManager().Open(sessionListBox.Text);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Resource selected must be a message-based session");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                string textToWrite = ReplaceCommonEscapeSequences(writeBox.Text);
                mbSession.Write(textToWrite);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\r", "\r");
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return s.Replace("\n", "\\n").Replace("\r", "\\r");
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string responseString = mbSession.ReadString();
                readBox.Text = InsertCommonEscapeSequences(responseString);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {                  
            mbSession.Dispose();
        }

        


    }
}
