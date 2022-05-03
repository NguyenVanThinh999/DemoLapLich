namespace Calendar
{
    partial class DailyPaln
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyPaln));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNextDay = new System.Windows.Forms.Button();
            this.btnBeforeDay = new System.Windows.Forms.Button();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.pnlJob = new System.Windows.Forms.Panel();
            this.mnstMain = new System.Windows.Forms.MenuStrip();
            this.mnstAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstToday = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.mnstMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnlJob);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 401);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnNextDay);
            this.panel3.Controls.Add(this.btnBeforeDay);
            this.panel3.Controls.Add(this.dtpkDate);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(956, 54);
            this.panel3.TabIndex = 1;
            // 
            // btnNextDay
            // 
            this.btnNextDay.Font = new System.Drawing.Font("MingLiU-ExtB", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextDay.Location = new System.Drawing.Point(757, 11);
            this.btnNextDay.Name = "btnNextDay";
            this.btnNextDay.Size = new System.Drawing.Size(149, 32);
            this.btnNextDay.TabIndex = 3;
            this.btnNextDay.Text = "--> Ngày Mai";
            this.btnNextDay.UseVisualStyleBackColor = true;
            this.btnNextDay.Click += new System.EventHandler(this.btnNextDay_Click);
            // 
            // btnBeforeDay
            // 
            this.btnBeforeDay.Font = new System.Drawing.Font("MingLiU-ExtB", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeforeDay.Location = new System.Drawing.Point(42, 11);
            this.btnBeforeDay.Name = "btnBeforeDay";
            this.btnBeforeDay.Size = new System.Drawing.Size(149, 32);
            this.btnBeforeDay.TabIndex = 2;
            this.btnBeforeDay.Text = "Hôm Qua <--";
            this.btnBeforeDay.UseVisualStyleBackColor = true;
            this.btnBeforeDay.Click += new System.EventHandler(this.btnBeforeDay_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.Font = new System.Drawing.Font("Monotype Corsiva", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkDate.Location = new System.Drawing.Point(337, 12);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(290, 31);
            this.dtpkDate.TabIndex = 1;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // pnlJob
            // 
            this.pnlJob.Location = new System.Drawing.Point(3, 63);
            this.pnlJob.Name = "pnlJob";
            this.pnlJob.Size = new System.Drawing.Size(956, 328);
            this.pnlJob.TabIndex = 0;
            // 
            // mnstMain
            // 
            this.mnstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstAdd,
            this.mnstToday});
            this.mnstMain.Location = new System.Drawing.Point(0, 0);
            this.mnstMain.Name = "mnstMain";
            this.mnstMain.Size = new System.Drawing.Size(986, 24);
            this.mnstMain.TabIndex = 1;
            this.mnstMain.Text = "menuStrip1";
            // 
            // mnstAdd
            // 
            this.mnstAdd.Name = "mnstAdd";
            this.mnstAdd.Size = new System.Drawing.Size(109, 20);
            this.mnstAdd.Text = "Thêm Công Việc ";
            this.mnstAdd.Click += new System.EventHandler(this.mnstAdd_Click);
            // 
            // mnstToday
            // 
            this.mnstToday.Name = "mnstToday";
            this.mnstToday.Size = new System.Drawing.Size(73, 20);
            this.mnstToday.Text = "Hôm Nay ";
            this.mnstToday.Click += new System.EventHandler(this.mnstToday_Click);
            // 
            // DailyPaln
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnstMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DailyPaln";
            this.Text = "Lịch Trình";
            this.Load += new System.EventHandler(this.DailyPaln_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.mnstMain.ResumeLayout(false);
            this.mnstMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Panel pnlJob;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip mnstMain;
        private System.Windows.Forms.ToolStripMenuItem mnstAdd;
        private System.Windows.Forms.ToolStripMenuItem mnstToday;
        private System.Windows.Forms.Button btnNextDay;
        private System.Windows.Forms.Button btnBeforeDay;
    }
}