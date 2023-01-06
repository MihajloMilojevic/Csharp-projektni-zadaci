namespace User_App
{
    partial class BlockChainDetails
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
            this.previousBlock = new System.Windows.Forms.Button();
            this.nextBlock = new System.Windows.Forms.Button();
            this.genensisBlock = new System.Windows.Forms.Button();
            this.LastBlock = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentDifficulty = new System.Windows.Forms.Label();
            this.totalDifficulty = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.index = new System.Windows.Forms.Label();
            this.difficulty = new System.Windows.Forms.Label();
            this.timestamp = new System.Windows.Forms.Label();
            this.nonce = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.RichTextBox();
            this.hash = new System.Windows.Forms.RichTextBox();
            this.previousHash = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // previousBlock
            // 
            this.previousBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousBlock.Location = new System.Drawing.Point(86, 510);
            this.previousBlock.Name = "previousBlock";
            this.previousBlock.Size = new System.Drawing.Size(56, 55);
            this.previousBlock.TabIndex = 0;
            this.previousBlock.Text = "<";
            this.previousBlock.UseVisualStyleBackColor = true;
            this.previousBlock.Click += new System.EventHandler(this.previousBlock_Click);
            // 
            // nextBlock
            // 
            this.nextBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextBlock.Location = new System.Drawing.Point(148, 510);
            this.nextBlock.Name = "nextBlock";
            this.nextBlock.Size = new System.Drawing.Size(56, 55);
            this.nextBlock.TabIndex = 1;
            this.nextBlock.Text = ">";
            this.nextBlock.UseVisualStyleBackColor = true;
            this.nextBlock.Click += new System.EventHandler(this.nextBlock_Click);
            // 
            // genensisBlock
            // 
            this.genensisBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.genensisBlock.Location = new System.Drawing.Point(24, 510);
            this.genensisBlock.Name = "genensisBlock";
            this.genensisBlock.Size = new System.Drawing.Size(56, 55);
            this.genensisBlock.TabIndex = 2;
            this.genensisBlock.Text = "<<";
            this.genensisBlock.UseVisualStyleBackColor = true;
            this.genensisBlock.Click += new System.EventHandler(this.genensisBlock_Click);
            // 
            // LastBlock
            // 
            this.LastBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LastBlock.Location = new System.Drawing.Point(210, 510);
            this.LastBlock.Name = "LastBlock";
            this.LastBlock.Size = new System.Drawing.Size(56, 55);
            this.LastBlock.TabIndex = 3;
            this.LastBlock.Text = ">>";
            this.LastBlock.UseVisualStyleBackColor = true;
            this.LastBlock.Click += new System.EventHandler(this.LastBlock_Click);
            // 
            // refresh
            // 
            this.refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refresh.Location = new System.Drawing.Point(534, 510);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(122, 55);
            this.refresh.TabIndex = 4;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.count);
            this.groupBox1.Controls.Add(this.totalDifficulty);
            this.groupBox1.Controls.Add(this.currentDifficulty);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 125);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.previousHash);
            this.groupBox2.Controls.Add(this.hash);
            this.groupBox2.Controls.Add(this.data);
            this.groupBox2.Controls.Add(this.nonce);
            this.groupBox2.Controls.Add(this.timestamp);
            this.groupBox2.Controls.Add(this.difficulty);
            this.groupBox2.Controls.Add(this.index);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(24, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 349);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current block";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Difficulty: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Count: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Difficulty: ";
            // 
            // currentDifficulty
            // 
            this.currentDifficulty.AutoSize = true;
            this.currentDifficulty.Location = new System.Drawing.Point(239, 30);
            this.currentDifficulty.Name = "currentDifficulty";
            this.currentDifficulty.Size = new System.Drawing.Size(26, 29);
            this.currentDifficulty.TabIndex = 3;
            this.currentDifficulty.Text = "0";
            // 
            // totalDifficulty
            // 
            this.totalDifficulty.AutoSize = true;
            this.totalDifficulty.Location = new System.Drawing.Point(507, 30);
            this.totalDifficulty.Name = "totalDifficulty";
            this.totalDifficulty.Size = new System.Drawing.Size(26, 29);
            this.totalDifficulty.TabIndex = 4;
            this.totalDifficulty.Text = "0";
            // 
            // count
            // 
            this.count.AutoSize = true;
            this.count.Location = new System.Drawing.Point(239, 70);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(26, 29);
            this.count.TabIndex = 5;
            this.count.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 29);
            this.label7.TabIndex = 7;
            this.label7.Text = "Index:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 29);
            this.label8.TabIndex = 8;
            this.label8.Text = "Data: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(249, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 29);
            this.label9.TabIndex = 9;
            this.label9.Text = "Timestamp:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 29);
            this.label10.TabIndex = 10;
            this.label10.Text = "Difficulty:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 225);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 29);
            this.label12.TabIndex = 12;
            this.label12.Text = "Hash:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(18, 289);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 29);
            this.label13.TabIndex = 13;
            this.label13.Text = "Previous Hash:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(249, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 29);
            this.label14.TabIndex = 14;
            this.label14.Text = "Nonce:";
            // 
            // index
            // 
            this.index.AutoSize = true;
            this.index.Location = new System.Drawing.Point(154, 30);
            this.index.Name = "index";
            this.index.Size = new System.Drawing.Size(26, 29);
            this.index.TabIndex = 15;
            this.index.Text = "0";
            // 
            // difficulty
            // 
            this.difficulty.AutoSize = true;
            this.difficulty.Location = new System.Drawing.Point(154, 74);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(26, 29);
            this.difficulty.TabIndex = 16;
            this.difficulty.Text = "0";
            // 
            // timestamp
            // 
            this.timestamp.AutoSize = true;
            this.timestamp.Location = new System.Drawing.Point(395, 30);
            this.timestamp.Name = "timestamp";
            this.timestamp.Size = new System.Drawing.Size(26, 29);
            this.timestamp.TabIndex = 17;
            this.timestamp.Text = "0";
            // 
            // nonce
            // 
            this.nonce.AutoSize = true;
            this.nonce.Location = new System.Drawing.Point(395, 74);
            this.nonce.Name = "nonce";
            this.nonce.Size = new System.Drawing.Size(26, 29);
            this.nonce.TabIndex = 18;
            this.nonce.Text = "0";
            // 
            // data
            // 
            this.data.Location = new System.Drawing.Point(198, 118);
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.Size = new System.Drawing.Size(396, 69);
            this.data.TabIndex = 19;
            this.data.Text = "";
            // 
            // hash
            // 
            this.hash.Location = new System.Drawing.Point(198, 222);
            this.hash.Name = "hash";
            this.hash.ReadOnly = true;
            this.hash.Size = new System.Drawing.Size(396, 51);
            this.hash.TabIndex = 20;
            this.hash.Text = "";
            // 
            // previousHash
            // 
            this.previousHash.Location = new System.Drawing.Point(198, 279);
            this.previousHash.Name = "previousHash";
            this.previousHash.ReadOnly = true;
            this.previousHash.Size = new System.Drawing.Size(396, 51);
            this.previousHash.TabIndex = 21;
            this.previousHash.Text = "";
            // 
            // BlockChainDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 577);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.LastBlock);
            this.Controls.Add(this.genensisBlock);
            this.Controls.Add(this.nextBlock);
            this.Controls.Add(this.previousBlock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "BlockChainDetails";
            this.Text = "Blockchain Details";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button previousBlock;
        private System.Windows.Forms.Button nextBlock;
        private System.Windows.Forms.Button genensisBlock;
        private System.Windows.Forms.Button LastBlock;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label count;
        private System.Windows.Forms.Label totalDifficulty;
        private System.Windows.Forms.Label currentDifficulty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox previousHash;
        private System.Windows.Forms.RichTextBox hash;
        private System.Windows.Forms.RichTextBox data;
        private System.Windows.Forms.Label nonce;
        private System.Windows.Forms.Label timestamp;
        private System.Windows.Forms.Label difficulty;
        private System.Windows.Forms.Label index;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}