namespace demodialog
{
    partial class dgTest
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
            this.tbDialogTest = new System.Windows.Forms.TextBox();
            this.btnCloseDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbDialogTest
            // 
            this.tbDialogTest.Location = new System.Drawing.Point(273, 145);
            this.tbDialogTest.Name = "tbDialogTest";
            this.tbDialogTest.Size = new System.Drawing.Size(276, 20);
            this.tbDialogTest.TabIndex = 0;
            // 
            // btnCloseDialog
            // 
            this.btnCloseDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloseDialog.Location = new System.Drawing.Point(273, 201);
            this.btnCloseDialog.Name = "btnCloseDialog";
            this.btnCloseDialog.Size = new System.Drawing.Size(75, 23);
            this.btnCloseDialog.TabIndex = 1;
            this.btnCloseDialog.Text = "close dialog";
            this.btnCloseDialog.UseVisualStyleBackColor = true;
            this.btnCloseDialog.Click += new System.EventHandler(this.btnCloseDialog_Click);
            // 
            // dgTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCloseDialog;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCloseDialog);
            this.Controls.Add(this.tbDialogTest);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dgTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dgTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDialogTest;
        private System.Windows.Forms.Button btnCloseDialog;
    }
}