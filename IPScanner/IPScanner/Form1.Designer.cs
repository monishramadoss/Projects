namespace IPScanner
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.StartIP = new System.Windows.Forms.TextBox();
            this.EndIP = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MaxPortValue = new System.Windows.Forms.TextBox();
            this.Console = new System.Windows.Forms.TextBox();
            this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CPUStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.MemoryStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.NetworkStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.CPUperformance = new System.Diagnostics.PerformanceCounter();
            this.MEMperformance = new System.Diagnostics.PerformanceCounter();
            this.NETperformance = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPUperformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MEMperformance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NETperformance)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(12, 207);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 60);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(9, 8);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // StartIP
            // 
            this.StartIP.Location = new System.Drawing.Point(12, 30);
            this.StartIP.Name = "StartIP";
            this.StartIP.Size = new System.Drawing.Size(100, 20);
            this.StartIP.TabIndex = 2;
            // 
            // EndIP
            // 
            this.EndIP.Location = new System.Drawing.Point(12, 65);
            this.EndIP.Name = "EndIP";
            this.EndIP.Size = new System.Drawing.Size(100, 20);
            this.EndIP.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.listView1.Location = new System.Drawing.Point(197, 30);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(510, 324);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 115);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Everything on LAN";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(197, 368);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(510, 27);
            this.progressBar1.TabIndex = 6;
            // 
            // MaxPortValue
            // 
            this.MaxPortValue.Location = new System.Drawing.Point(12, 162);
            this.MaxPortValue.Name = "MaxPortValue";
            this.MaxPortValue.Size = new System.Drawing.Size(100, 20);
            this.MaxPortValue.TabIndex = 7;
            this.MaxPortValue.Text = " 20";
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(13, 284);
            this.Console.Multiline = true;
            this.Console.Name = "Console";
            this.Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console.Size = new System.Drawing.Size(100, 101);
            this.Console.TabIndex = 9;
            // 
            // performanceCounter1
            // 
            this.performanceCounter1.CategoryName = "Thread";
            this.performanceCounter1.CounterName = "ID Thread";
            this.performanceCounter1.InstanceName = "_Total";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CPUStatus,
            this.MemoryStatus,
            this.NetworkStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 401);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CPUStatus
            // 
            this.CPUStatus.Name = "CPUStatus";
            this.CPUStatus.Size = new System.Drawing.Size(100, 16);
            this.CPUStatus.Step = 1;
            // 
            // MemoryStatus
            // 
            this.MemoryStatus.Name = "MemoryStatus";
            this.MemoryStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // NetworkStatus
            // 
            this.NetworkStatus.Name = "NetworkStatus";
            this.NetworkStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // CPUperformance
            // 
            this.CPUperformance.CategoryName = "Processor";
            this.CPUperformance.CounterName = "% Processor Time";
            this.CPUperformance.InstanceName = "_Total";
            // 
            // MEMperformance
            // 
            this.MEMperformance.CategoryName = "Memory";
            this.MEMperformance.CounterName = "% Committed Bytes In Use";
            // 
            // NETperformance
            // 
            this.NETperformance.CategoryName = "Network Adapter";
            this.NETperformance.CounterName = "Bytes Total/sec";
            this.NETperformance.InstanceName = "Intel[R] Dual Band Wireless-AC 7265";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(719, 423);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.MaxPortValue);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.EndIP);
            this.Controls.Add(this.StartIP);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.StartBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "IP Scanner";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPUperformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MEMperformance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NETperformance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox StartIP;
        private System.Windows.Forms.TextBox EndIP;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox MaxPortValue;
        private System.Diagnostics.PerformanceCounter performanceCounter1;
        private System.Windows.Forms.TextBox Console;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar CPUStatus;
        private System.Windows.Forms.ToolStripProgressBar MemoryStatus;
        private System.Windows.Forms.ToolStripProgressBar NetworkStatus;
        private System.Diagnostics.PerformanceCounter CPUperformance;
        private System.Diagnostics.PerformanceCounter MEMperformance;
        private System.Diagnostics.PerformanceCounter NETperformance;
    }
}

