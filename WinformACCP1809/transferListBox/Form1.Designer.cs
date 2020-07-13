namespace transferListBox
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
            this.lbSV1 = new System.Windows.Forms.ListBox();
            this.tbMaSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cboSV = new System.Windows.Forms.ComboBox();
            this.tbTenSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lbSV2 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbSV1
            // 
            this.lbSV1.FormattingEnabled = true;
            this.lbSV1.Location = new System.Drawing.Point(404, 45);
            this.lbSV1.Name = "lbSV1";
            this.lbSV1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSV1.Size = new System.Drawing.Size(120, 95);
            this.lbSV1.TabIndex = 0;
            // 
            // tbMaSV
            // 
            this.tbMaSV.Location = new System.Drawing.Point(188, 45);
            this.tbMaSV.Name = "tbMaSV";
            this.tbMaSV.Size = new System.Drawing.Size(100, 20);
            this.tbMaSV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ma sinh vien";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboSV
            // 
            this.cboSV.FormattingEnabled = true;
            this.cboSV.Location = new System.Drawing.Point(188, 192);
            this.cboSV.Name = "cboSV";
            this.cboSV.Size = new System.Drawing.Size(121, 21);
            this.cboSV.TabIndex = 4;
            this.cboSV.SelectedIndexChanged += new System.EventHandler(this.cboSV_SelectedIndexChanged);
            // 
            // tbTenSV
            // 
            this.tbTenSV.Location = new System.Drawing.Point(188, 84);
            this.tbTenSV.Name = "tbTenSV";
            this.tbTenSV.Size = new System.Drawing.Size(100, 20);
            this.tbTenSV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ten sinh vien";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Chon sinh vien";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ma sinh vien duoc chon";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(185, 233);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(25, 13);
            this.lblMaSV.TabIndex = 2;
            this.lblMaSV.Text = "___";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(550, 45);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(550, 77);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(33, 23);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lbSV2
            // 
            this.lbSV2.FormattingEnabled = true;
            this.lbSV2.Location = new System.Drawing.Point(614, 45);
            this.lbSV2.Name = "lbSV2";
            this.lbSV2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSV2.Size = new System.Drawing.Size(120, 95);
            this.lbSV2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboSV);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMaSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTenSV);
            this.Controls.Add(this.tbMaSV);
            this.Controls.Add(this.lbSV2);
            this.Controls.Add(this.lbSV1);
            this.Name = "Form1";
            this.Text = "ListBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbSV1;
        private System.Windows.Forms.TextBox tbMaSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cboSV;
        private System.Windows.Forms.TextBox tbTenSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.ListBox lbSV2;
    }
}

