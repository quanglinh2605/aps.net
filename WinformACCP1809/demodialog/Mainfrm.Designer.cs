namespace demodialog
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
            this.tbTest = new System.Windows.Forms.TextBox();
            this.btnOpendialog = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // tbTest
            // 
            this.tbTest.Location = new System.Drawing.Point(196, 112);
            this.tbTest.Name = "tbTest";
            this.tbTest.Size = new System.Drawing.Size(298, 20);
            this.tbTest.TabIndex = 0;
            // 
            // btnOpendialog
            // 
            this.btnOpendialog.Location = new System.Drawing.Point(196, 166);
            this.btnOpendialog.Name = "btnOpendialog";
            this.btnOpendialog.Size = new System.Drawing.Size(75, 23);
            this.btnOpendialog.TabIndex = 1;
            this.btnOpendialog.Text = "Show Dialog";
            this.btnOpendialog.UseVisualStyleBackColor = true;
            this.btnOpendialog.Click += new System.EventHandler(this.btnOpendialog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpendialog);
            this.Controls.Add(this.tbTest);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTest;
        private System.Windows.Forms.Button btnOpendialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

