using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.DirectoryServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace Windows_Profile_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userList.Click += new EventHandler(userList_Click);
            detailList.DoubleClick += new EventHandler(editDetailButton_Click);


            //Warn the user if they're not running as admin
            if(IsUserAdmin() == false)
            {
                string adminError = (MessageBox.Show("You're not running as admin, you will have very limited functionality.", "No Admin Rights!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)).ToString();
                if(adminError == "Cancel")
                {
                    System.Environment.Exit(1);
                }
            }
            
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            this.userList.FormattingEnabled = true;
            this.userList.HorizontalScrollbar = true;
            //Get the SID's
            RegistryKey ProfileList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\");
            foreach (string ProfileKey in ProfileList.GetSubKeyNames())
            {
                userList.Items.Add(ProfileKey);
            }


        }

        private void userList_Click(object sender, EventArgs e)
        {
            //Clear out the list and the text boxes
            detailList.Items.Clear();
            guidBox.Text = null;
            profilePathBox.Text = null;
            string a = null;

            try
            {
                a = userList.SelectedItem.ToString();
            }
            catch(Exception)
            {
                return;
            }
            

            //make sure a isn't null, can cause crash, this happens if user clicks in blank space of list
            if(a == null)
            {
                return;
            }
            //string[] a = userList.Items.Cast<string>().ToArray();
            string ProfileImagePath;
            string GUID;

            try {
                ProfileImagePath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a, "ProfileImagePath", null);
                profilePathBox.Text = ProfileImagePath;
                //detailList.Items.Add(ProfileImagePath);
            }
             
            catch(Exception error)
            {
                toolStripStatusLabel1.Text = error.Message.ToString();
                
                
            }

            try
            {

                GUID = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a, "Guid", null);
                guidBox.Text = GUID;
                //detailList.Items.Add(GUID);
            }
            
            catch(Exception error)
            {
                toolStripStatusLabel1.Text = error.Message.ToString();
                
            }

            RegistryKey DetailList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\" + userList.SelectedItem);
            foreach (string ProfileKey in DetailList.GetValueNames())
            {
                detailList.Items.Add(ProfileKey);
            }




        }


        private void editDetailButton_Click(object sender, EventArgs e)
        {
            if(detailList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Nothing is selected.");
                return;

            }

            textInput input = new textInput();
            sharedvar variables = new sharedvar();

            sharedvar.details = detailList.SelectedItem.ToString();
            sharedvar.sid = userList.SelectedItem.ToString();

            sharedvar.closed = -1;
            input.ShowDialog();

            if(sharedvar.closed == 0)
            {
                try
                {
                    //detailList.Items[detailList.Items.IndexOf(detailList.SelectedItem)] = sharedvar.details;
                    //MessageBox.Show(sharedvar.details);
                    RegistryKey ChangeValue = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\" + userList.SelectedItem, true);

                    if(sharedvar.vlueType == "DWord")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.DWord);
                    }
                    else if (sharedvar.vlueType == "Binary")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.Binary);
                    }

                    else if (sharedvar.vlueType == "ExpandString")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.ExpandString);
                    }
                    else if (sharedvar.vlueType == "MultiString")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.MultiString);
                    }
                    else if (sharedvar.vlueType == "None")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.None);
                    }
                    else if (sharedvar.vlueType == "QWord")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.QWord);
                    }
                    else if (sharedvar.vlueType == "String")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.String);
                    }
                    else if (sharedvar.vlueType == "Unknown")
                    {
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details, RegistryValueKind.Unknown);
                    }
                    else
                    {
                        MessageBox.Show("Value not found!");
                    }
                           //ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }

        private void deleteSIDButton_Click(object sender, EventArgs e)
        {
            //Test if a SID is selected. 
            if (userList.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Nothing is selected.");
                return;

            }
            try {
                //Delete the SID selected in the list of SIDs
                string a = userList.SelectedItem.ToString();
                Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a);
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            finally
            {
                userList.Items.RemoveAt(userList.SelectedIndex);
            }
        }

        public bool IsUserAdmin()
        {
            bool isAdmin;
            System.Security.Principal.WindowsIdentity user = null;
            try
            {
                user = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(user);
                isAdmin = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                isAdmin = false;
            }
            catch (Exception ex)
            {
                isAdmin = false;
            }
            finally
            {
                if (user != null)
                    user.Dispose();
            }
            return isAdmin;
        }
    }
}
