namespace User_App
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.blockchainTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addBlock = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.newBlockDataTB = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.blockchainPreview = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.networkTab = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.myPeersLB = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.numbelOfPeersLabel = new System.Windows.Forms.Label();
            this.networkStatusLabel = new System.Windows.Forms.Label();
            this.myPortLabel = new System.Windows.Forms.Label();
            this.myIpLabel = new System.Windows.Forms.Label();
            this.changeNameButton = new System.Windows.Forms.Button();
            this.networkNameTB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.logTab = new System.Windows.Forms.TabPage();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.blockchainTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.networkTab.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.logTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.blockchainTab);
            this.tabControl1.Controls.Add(this.networkTab);
            this.tabControl1.Controls.Add(this.logTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(664, 351);
            this.tabControl1.TabIndex = 0;
            // 
            // blockchainTab
            // 
            this.blockchainTab.Controls.Add(this.panel1);
            this.blockchainTab.Controls.Add(this.panel2);
            this.blockchainTab.Location = new System.Drawing.Point(4, 38);
            this.blockchainTab.Name = "blockchainTab";
            this.blockchainTab.Size = new System.Drawing.Size(656, 309);
            this.blockchainTab.TabIndex = 0;
            this.blockchainTab.Text = "Blockchain";
            this.blockchainTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addBlock);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.newBlockDataTB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(244, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 309);
            this.panel1.TabIndex = 0;
            // 
            // addBlock
            // 
            this.addBlock.Location = new System.Drawing.Point(22, 180);
            this.addBlock.Name = "addBlock";
            this.addBlock.Size = new System.Drawing.Size(182, 77);
            this.addBlock.TabIndex = 2;
            this.addBlock.Text = "Add block to blockchain";
            this.addBlock.UseVisualStyleBackColor = true;
            this.addBlock.Click += new System.EventHandler(this.addBlock_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data for new block:";
            // 
            // newBlockDataTB
            // 
            this.newBlockDataTB.Location = new System.Drawing.Point(22, 61);
            this.newBlockDataTB.Multiline = true;
            this.newBlockDataTB.Name = "newBlockDataTB";
            this.newBlockDataTB.Size = new System.Drawing.Size(336, 99);
            this.newBlockDataTB.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 309);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.blockchainPreview);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 238);
            this.panel4.TabIndex = 1;
            // 
            // blockchainPreview
            // 
            this.blockchainPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blockchainPreview.FormattingEnabled = true;
            this.blockchainPreview.ItemHeight = 29;
            this.blockchainPreview.Location = new System.Drawing.Point(0, 0);
            this.blockchainPreview.Name = "blockchainPreview";
            this.blockchainPreview.Size = new System.Drawing.Size(244, 238);
            this.blockchainPreview.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 71);
            this.panel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "(double click for more info)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Blockchain blocks:";
            // 
            // networkTab
            // 
            this.networkTab.Controls.Add(this.panel5);
            this.networkTab.Controls.Add(this.numbelOfPeersLabel);
            this.networkTab.Controls.Add(this.networkStatusLabel);
            this.networkTab.Controls.Add(this.myPortLabel);
            this.networkTab.Controls.Add(this.myIpLabel);
            this.networkTab.Controls.Add(this.changeNameButton);
            this.networkTab.Controls.Add(this.networkNameTB);
            this.networkTab.Controls.Add(this.label7);
            this.networkTab.Controls.Add(this.label8);
            this.networkTab.Controls.Add(this.label6);
            this.networkTab.Controls.Add(this.label5);
            this.networkTab.Controls.Add(this.label4);
            this.networkTab.Location = new System.Drawing.Point(4, 38);
            this.networkTab.Name = "networkTab";
            this.networkTab.Size = new System.Drawing.Size(656, 309);
            this.networkTab.TabIndex = 1;
            this.networkTab.Text = "Network";
            this.networkTab.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.myPeersLB);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(456, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 309);
            this.panel5.TabIndex = 12;
            // 
            // myPeersLB
            // 
            this.myPeersLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPeersLB.FormattingEnabled = true;
            this.myPeersLB.ItemHeight = 29;
            this.myPeersLB.Location = new System.Drawing.Point(0, 51);
            this.myPeersLB.Name = "myPeersLB";
            this.myPeersLB.Size = new System.Drawing.Size(200, 258);
            this.myPeersLB.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label13);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 51);
            this.panel6.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(118, 29);
            this.label13.TabIndex = 0;
            this.label13.Text = "My peers:";
            // 
            // numbelOfPeersLabel
            // 
            this.numbelOfPeersLabel.AutoSize = true;
            this.numbelOfPeersLabel.Location = new System.Drawing.Point(245, 133);
            this.numbelOfPeersLabel.Name = "numbelOfPeersLabel";
            this.numbelOfPeersLabel.Size = new System.Drawing.Size(26, 29);
            this.numbelOfPeersLabel.TabIndex = 11;
            this.numbelOfPeersLabel.Text = "0";
            // 
            // networkStatusLabel
            // 
            this.networkStatusLabel.AutoSize = true;
            this.networkStatusLabel.Location = new System.Drawing.Point(245, 94);
            this.networkStatusLabel.Name = "networkStatusLabel";
            this.networkStatusLabel.Size = new System.Drawing.Size(157, 29);
            this.networkStatusLabel.TabIndex = 10;
            this.networkStatusLabel.Text = "disconnected";
            // 
            // myPortLabel
            // 
            this.myPortLabel.AutoSize = true;
            this.myPortLabel.Location = new System.Drawing.Point(245, 52);
            this.myPortLabel.Name = "myPortLabel";
            this.myPortLabel.Size = new System.Drawing.Size(109, 29);
            this.myPortLabel.TabIndex = 9;
            this.myPortLabel.Text = "unknown";
            // 
            // myIpLabel
            // 
            this.myIpLabel.AutoSize = true;
            this.myIpLabel.Location = new System.Drawing.Point(245, 12);
            this.myIpLabel.Name = "myIpLabel";
            this.myIpLabel.Size = new System.Drawing.Size(109, 29);
            this.myIpLabel.TabIndex = 8;
            this.myIpLabel.Text = "unknown";
            // 
            // changeNameButton
            // 
            this.changeNameButton.Location = new System.Drawing.Point(193, 255);
            this.changeNameButton.Name = "changeNameButton";
            this.changeNameButton.Size = new System.Drawing.Size(194, 46);
            this.changeNameButton.TabIndex = 7;
            this.changeNameButton.Text = "Change Name";
            this.changeNameButton.UseVisualStyleBackColor = true;
            this.changeNameButton.Click += new System.EventHandler(this.changeNameButton_Click);
            // 
            // networkNameTB
            // 
            this.networkNameTB.Location = new System.Drawing.Point(33, 215);
            this.networkNameTB.Name = "networkNameTB";
            this.networkNameTB.Size = new System.Drawing.Size(354, 34);
            this.networkNameTB.TabIndex = 6;
            this.networkNameTB.Text = "unknown";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 29);
            this.label7.TabIndex = 5;
            this.label7.Text = "My name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Number of peers:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Network status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "My Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "My IP:";
            // 
            // logTab
            // 
            this.logTab.Controls.Add(this.logBox);
            this.logTab.Location = new System.Drawing.Point(4, 38);
            this.logTab.Name = "logTab";
            this.logTab.Size = new System.Drawing.Size(656, 309);
            this.logTab.TabIndex = 2;
            this.logTab.Text = "Log";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(656, 309);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 351);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Blockchain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.blockchainTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.networkTab.ResumeLayout(false);
            this.networkTab.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.logTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage blockchainTab;
        private System.Windows.Forms.TabPage networkTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addBlock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newBlockDataTB;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox blockchainPreview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox myPeersLB;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label numbelOfPeersLabel;
        private System.Windows.Forms.Label networkStatusLabel;
        private System.Windows.Forms.Label myPortLabel;
        private System.Windows.Forms.Label myIpLabel;
        private System.Windows.Forms.Button changeNameButton;
        private System.Windows.Forms.TextBox networkNameTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox logBox;
    }
}

