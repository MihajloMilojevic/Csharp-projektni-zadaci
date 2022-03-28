
namespace Zmijice
{
    partial class forma
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabla = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla
            // 
            this.tabla.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabla.Enabled = false;
            this.tabla.Location = new System.Drawing.Point(16, 49);
            this.tabla.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabla.Name = "tabla";
            this.tabla.Size = new System.Drawing.Size(500, 500);
            this.tabla.TabIndex = 0;
            this.tabla.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(122, 232);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(281, 133);
            this.start.TabIndex = 1;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Score: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "High Score: ";
            // 
            // scoreLabel
            // 
            this.scoreLabel.Location = new System.Drawing.Point(94, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(94, 34);
            this.scoreLabel.TabIndex = 4;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.Location = new System.Drawing.Point(405, 9);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(111, 34);
            this.highScoreLabel.TabIndex = 5;
            this.highScoreLabel.Text = "0";
            // 
            // forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 561);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.tabla);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "forma";
            this.Text = "Zmijice";
            this.Load += new System.EventHandler(this.forma_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.forma_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox tabla;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highScoreLabel;
    }
}

