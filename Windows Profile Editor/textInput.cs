﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Profile_Editor
{
    public partial class textInput : Form
    {
        public textInput()
        {
            InitializeComponent();


        }

        private void textInput_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey ChangeValue = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\" + sharedvar.sid);
            //MessageBox.Show(ChangeValue.GetValueKind(sharedvar.details).ToString());
            sharedvar.vlueType = ChangeValue.GetValueKind(sharedvar.details).ToString();
            try
            {
                string GUID = (string)(Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + sharedvar.sid, sharedvar.details, null)).ToString();
                detailsBox.Text = GUID;
            }
            catch(Exception)
            {

            }
            
            //detailsBox.Text = sharedvar.details;

            

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            sharedvar.details = detailsBox.Text;
            sharedvar.closed = 0;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            sharedvar.closed = -1;
        }
    }
}