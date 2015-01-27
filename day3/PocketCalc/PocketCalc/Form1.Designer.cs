namespace PocketCalc
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFor0 = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonFor1 = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(260, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "0";
            // 
            // buttonFor0
            // 
            this.buttonFor0.Location = new System.Drawing.Point(12, 48);
            this.buttonFor0.Name = "buttonFor0";
            this.buttonFor0.Size = new System.Drawing.Size(75, 23);
            this.buttonFor0.TabIndex = 1;
            this.buttonFor0.Text = "0";
            this.buttonFor0.UseVisualStyleBackColor = true;
            this.buttonFor0.Click += new System.EventHandler(this.buttonFor0_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonResult.Location = new System.Drawing.Point(197, 106);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(75, 23);
            this.buttonResult.TabIndex = 2;
            this.buttonResult.Text = "=";
            this.buttonResult.UseVisualStyleBackColor = false;
            this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinus.Location = new System.Drawing.Point(197, 77);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(75, 23);
            this.buttonMinus.TabIndex = 3;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonFor1
            // 
            this.buttonFor1.Location = new System.Drawing.Point(12, 77);
            this.buttonFor1.Name = "buttonFor1";
            this.buttonFor1.Size = new System.Drawing.Size(75, 23);
            this.buttonFor1.TabIndex = 4;
            this.buttonFor1.Text = "1";
            this.buttonFor1.UseVisualStyleBackColor = true;
            this.buttonFor1.Click += new System.EventHandler(this.buttonFor1Clicked);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlus.Location = new System.Drawing.Point(197, 48);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(75, 23);
            this.buttonPlus.TabIndex = 5;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.plusButtonClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 140);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.buttonFor1);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.buttonFor0);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Simple Pocket Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFor0;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonFor1;
        private System.Windows.Forms.Button buttonPlus;
    }
}

