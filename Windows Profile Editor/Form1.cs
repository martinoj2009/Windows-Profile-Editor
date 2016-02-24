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
using System.Security.Principal;

namespace Windows_Profile_Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            //userList.Click += new EventHandler(userList_Click);
            detailList.DoubleClick += new EventHandler(editDetailButton_Click);
            usernameLabel.Text = null;
            warningIfNotAdmin.Text = "";
            adminButton.Visible = false;
            adminButton.Enabled = false;

            //Warn the user if they're not running as admin
            if (IsUserAdmin() == false)
            {
                //This will warn the user if they are not running as admin
                warningIfNotAdmin.Text = "Warning: You're not running this program as Admin!";
                warningIfNotAdmin.ForeColor = Color.Red;
                adminButton.Visible = true;
                adminButton.Enabled = true;
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
            ProfileList.Close();



        }

        /*
        private void userList_Click(object sender, EventArgs e)
        {
            if(userList.SelectedItem == null)
            {
                return;
            }

            //Convert SID to username
            try
            {
                string account = new System.Security.Principal.SecurityIdentifier(userList.SelectedItem.ToString()).Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                usernameLabel.Text = account;
            }
            catch(Exception)
            {
                usernameLabel.Text = "Error getting username!";
            }
            

            //Clear out the list and the text boxes
            detailList.Items.Clear();
            guidBox.Text = null;
            profilePathBox.Text = null;
            GC.Collect();

            string a = userList.SelectedItem.ToString();

            

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
            DetailList.Close();



        }
<<<<<<< HEAD
        */
=======

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
>>>>>>> origin/master

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
            input = null;
            GC.Collect();


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
                        ChangeValue.SetValue(detailList.SelectedItem.ToString(), System.Text.Encoding.ASCII.GetBytes(sharedvar.details), RegistryValueKind.Binary);
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
<<<<<<< HEAD
                           
=======
                    ChangeValue.Close();
                           //ChangeValue.SetValue(detailList.SelectedItem.ToString(), sharedvar.details);
>>>>>>> origin/master
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
            catch (UnauthorizedAccessException)
            {
                isAdmin = false;
            }
            catch (Exception)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey ChangeValue = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\" + userList.SelectedItem, true);
                ChangeValue.SetValue("ProfileImagePath", profilePathBox.Text, RegistryValueKind.ExpandString);
                ChangeValue.SetValue("Guid", guidBox.Text, RegistryValueKind.String);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

<<<<<<< HEAD
        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (userList.SelectedItem == null)
            {
                return;
            }
            try
            {
                string account = new System.Security.Principal.SecurityIdentifier(userList.SelectedItem.ToString()).Translate(typeof(System.Security.Principal.NTAccount)).ToString();
                usernameLabel.Text = account;
            }
            catch (Exception)
            {
                usernameLabel.Text = "Error getting username!";
            }


            //Clear out the list and the text boxes
            detailList.Items.Clear();
            guidBox.Text = null;
            profilePathBox.Text = null;

            string a = userList.SelectedItem.ToString();



            //make sure a isn't null, can cause crash, this happens if user clicks in blank space of list
            if (a == null)
            {
                return;
            }
            //string[] a = userList.Items.Cast<string>().ToArray();
            string ProfileImagePath;
            string GUID;

            try
            {
                ProfileImagePath = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a, "ProfileImagePath", null);
                profilePathBox.Text = ProfileImagePath;
                //detailList.Items.Add(ProfileImagePath);
            }

            catch (Exception error)
            {
                toolStripStatusLabel1.Text = error.Message.ToString();


            }

            try
            {

                GUID = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a, "Guid", null);
                guidBox.Text = GUID;
                //detailList.Items.Add(GUID);
            }

            catch (Exception error)
            {
                toolStripStatusLabel1.Text = error.Message.ToString();

            }

            RegistryKey DetailList = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\\Microsoft\Windows NT\\CurrentVersion\\ProfileList\\" + userList.SelectedItem);
            foreach (string ProfileKey in DetailList.GetValueNames())
            {
                detailList.Items.Add(ProfileKey);
            }
=======
        private void adminButton_Click(object sender, EventArgs e)
        {
            //This will restart the program as admin
            var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
            startInfo.Verb = "runas";
            System.Diagnostics.Process.Start(startInfo);
            this.Close();
            return;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.ShowDialog();
        }

        private void backupRegKey_Click(object sender, EventArgs e)
        {
            if(userList.SelectedItem == null)
            {
                MessageBox.Show("You need to select a SID to backup.", "No SID selected!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string a = userList.SelectedItem.ToString();
            // Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a, "ProfileImagePath", null);
            int backupReturnCode = Exportkey(a + ".reg",(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + a));
            if(backupReturnCode != 0)
            {
                MessageBox.Show("There was an error backing up the registry key!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //This is the function for exporting the registry key. This requires regedit for now
        private static int Exportkey(string exportPath, string registryPath)
        {
            string path = "\"" + exportPath + "\"";
            string key = "\"" + registryPath + "\"";
            Process proc = new Process();

            try
            {
                proc.StartInfo.FileName = "regedit.exe";
                proc.StartInfo.UseShellExecute = false;

                proc = Process.Start("regedit.exe", "/e " + path + " " + key);
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                proc.Dispose();
                return -1;
            }
            return 0;
>>>>>>> origin/master
        }
    }
}
