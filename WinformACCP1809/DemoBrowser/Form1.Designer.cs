namespace DemoBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnleftHistory = new System.Windows.Forms.Button();
            this.btnrightHistory = new System.Windows.Forms.Button();
            this.btnreload = new System.Windows.Forms.Button();
            this.wbChrome = new System.Windows.Forms.WebBrowser();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wbChrome, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.33334F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.23077F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.76923F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 543F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel2.Controls.Add(this.btnleftHistory, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnrightHistory, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnreload, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbUrl, 3, 0);
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(794, 32);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btnleftHistory
            // 
            this.btnleftHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnleftHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnleftHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnleftHistory.BackgroundImage")));
            this.btnleftHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnleftHistory.ForeColor = System.Drawing.Color.Transparent;
            this.btnleftHistory.Location = new System.Drawing.Point(4, 4);
            this.btnleftHistory.Name = "btnleftHistory";
            this.btnleftHistory.Size = new System.Drawing.Size(22, 23);
            this.btnleftHistory.TabIndex = 0;
            this.btnleftHistory.UseVisualStyleBackColor = false;
            // 
            // btnrightHistory
            // 
            this.btnrightHistory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnrightHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnrightHistory.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrightHistory.BackgroundImage")));
            this.btnrightHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrightHistory.ForeColor = System.Drawing.Color.Transparent;
            this.btnrightHistory.Location = new System.Drawing.Point(35, 4);
            this.btnrightHistory.Name = "btnrightHistory";
            this.btnrightHistory.Size = new System.Drawing.Size(24, 23);
            this.btnrightHistory.TabIndex = 1;
            this.btnrightHistory.UseVisualStyleBackColor = false;
            // 
            // btnreload
            // 
            this.btnreload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnreload.BackColor = System.Drawing.Color.Transparent;
            this.btnreload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnreload.BackgroundImage")));
            this.btnreload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnreload.ForeColor = System.Drawing.Color.Transparent;
            this.btnreload.Location = new System.Drawing.Point(68, 4);
            this.btnreload.Name = "btnreload";
            this.btnreload.Size = new System.Drawing.Size(24, 23);
            this.btnreload.TabIndex = 2;
            this.btnreload.UseVisualStyleBackColor = false;
            // 
            // wbChrome
            // 
            this.wbChrome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbChrome.Location = new System.Drawing.Point(3, 41);
            this.wbChrome.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbChrome.Name = "wbChrome";
            this.wbChrome.Size = new System.Drawing.Size(794, 406);
            this.wbChrome.TabIndex = 1;
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbUrl.Location = new System.Drawing.Point(100, 6);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(537, 20);
            this.tbUrl.TabIndex = 3;
            this.tbUrl.TextChanged += new System.EventHandler(this.TbUrl_Enter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Chrome";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnleftHistory;
        private System.Windows.Forms.Button btnrightHistory;
        private System.Windows.Forms.Button btnreload;
        private System.Windows.Forms.WebBrowser wbChrome;
        private System.Windows.Forms.TextBox tbUrl;
    }
}

