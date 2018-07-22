namespace IP_Scan1._4
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
            this.components = new System.ComponentModel.Container();
            this.lstLocal = new System.Windows.Forms.ListView();
            this.StartIP = new System.Windows.Forms.TextBox();
            this.EndIP = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MaxPortValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLocal
            // 
            this.lstLocal.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.lstLocal.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lstLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstLocal.Location = new System.Drawing.Point(127, 12);
            this.lstLocal.Name = "lstLocal";
            this.lstLocal.Size = new System.Drawing.Size(710, 285);
            this.lstLocal.TabIndex = 0;
            this.lstLocal.UseCompatibleStateImageBehavior = false;
            // 
            // StartIP
            // 
            this.StartIP.Location = new System.Drawing.Point(12, 33);
            this.StartIP.Name = "StartIP";
            this.StartIP.Size = new System.Drawing.Size(100, 20);
            this.StartIP.TabIndex = 1;
            this.StartIP.Text = "10.8.0.1";
            // 
            // EndIP
            // 
            this.EndIP.Location = new System.Drawing.Point(12, 74);
            this.EndIP.Name = "EndIP";
            this.EndIP.Size = new System.Drawing.Size(100, 20);
            this.EndIP.TabIndex = 2;
            this.EndIP.Text = "10.8.1.0";
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(12, 274);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 5;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End IP";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(127, 303);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(710, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MaxPortValue
            // 
            this.MaxPortValue.Location = new System.Drawing.Point(12, 214);
            this.MaxPortValue.Name = "MaxPortValue";
            this.MaxPortValue.Size = new System.Drawing.Size(100, 20);
            this.MaxPortValue.TabIndex = 10;
            this.MaxPortValue.Text = "65535";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Max Port Value";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 345);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MaxPortValue);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.EndIP);
            this.Controls.Add(this.StartIP);
            this.Controls.Add(this.lstLocal);
            this.Name = "Form1";
            this.Text = "IPSCAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstLocal;
        private System.Windows.Forms.TextBox StartIP;
        private System.Windows.Forms.TextBox EndIP;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox MaxPortValue;
        private System.Windows.Forms.Label label4;
    }
}

