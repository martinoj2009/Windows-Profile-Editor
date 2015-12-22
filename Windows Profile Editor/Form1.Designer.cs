namespace Windows_Profile_Editor
{
    partial class Form1
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
            this.sidlabel = new System.Windows.Forms.Label();
            this.userList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editDetailButton = new System.Windows.Forms.Button();
            this.detailList = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.deleteSIDButton = new System.Windows.Forms.Button();
            this.profilePathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guidBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidlabel
            // 
            this.sidlabel.AutoSize = true;
            this.sidlabel.Location = new System.Drawing.Point(13, 26);
            this.sidlabel.Name = "sidlabel";
            this.sidlabel.Size = new System.Drawing.Size(25, 13);
            this.sidlabel.TabIndex = 1;
            this.sidlabel.Text = "SID";
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(12, 43);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(265, 472);
            this.userList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Other Details";
            // 
            // editDetailButton
            // 
            this.editDetailButton.Location = new System.Drawing.Point(562, 248);
            this.editDetailButton.Name = "editDetailButton";
            this.editDetailButton.Size = new System.Drawing.Size(75, 23);
            this.editDetailButton.TabIndex = 6;
            this.editDetailButton.Text = "Edit Detail";
            this.editDetailButton.UseVisualStyleBackColor = true;
            this.editDetailButton.Click += new System.EventHandler(this.editDetailButton_Click);
            // 
            // detailList
            // 
            this.detailList.FormattingEnabled = true;
            this.detailList.Location = new System.Drawing.Point(283, 277);
            this.detailList.Name = "detailList";
            this.detailList.Size = new System.Drawing.Size(342, 238);
            this.detailList.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(637, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Status";
            // 
            // deleteSIDButton
            // 
            this.deleteSIDButton.Location = new System.Drawing.Point(199, 16);
            this.deleteSIDButton.Name = "deleteSIDButton";
            this.deleteSIDButton.Size = new System.Drawing.Size(75, 23);
            this.deleteSIDButton.TabIndex = 9;
            this.deleteSIDButton.Text = "Delete SID";
            this.deleteSIDButton.UseVisualStyleBackColor = true;
            this.deleteSIDButton.Click += new System.EventHandler(this.deleteSIDButton_Click);
            // 
            // profilePathBox
            // 
            this.profilePathBox.Location = new System.Drawing.Point(6, 49);
            this.profilePathBox.Name = "profilePathBox";
            this.profilePathBox.Size = new System.Drawing.Size(226, 20);
            this.profilePathBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Profile Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "GUID:";
            // 
            // guidBox
            // 
            this.guidBox.Location = new System.Drawing.Point(6, 101);
            this.guidBox.Name = "guidBox";
            this.guidBox.Size = new System.Drawing.Size(223, 20);
            this.guidBox.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usernameLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.profilePathBox);
            this.groupBox1.Controls.Add(this.guidBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(283, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 185);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(78, 16);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(68, 13);
            this.usernameLabel.TabIndex = 15;
            this.usernameLabel.Text = "USERNAME";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 555);
            this.Controls.Add(this.deleteSIDButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.detailList);
            this.Controls.Add(this.editDetailButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.sidlabel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Windows Profile Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sidlabel;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editDetailButton;
        private System.Windows.Forms.ListBox detailList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button deleteSIDButton;
        private System.Windows.Forms.TextBox profilePathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox guidBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label usernameLabel;
    }
}

