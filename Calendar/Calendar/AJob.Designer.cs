using System;
using System.Diagnostics;

namespace Calendar
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    partial class AJob
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nmToMinutes = new System.Windows.Forms.NumericUpDown();
            this.nmToHours = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nmFromMinutes = new System.Windows.Forms.NumericUpDown();
            this.nmFormHours = new System.Windows.Forms.NumericUpDown();
            this.txbJob = new System.Windows.Forms.TextBox();
            this.ckbDone = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFormHours)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txbJob);
            this.panel1.Controls.Add(this.ckbDone);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(834, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(753, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Lưu";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(626, 12);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(121, 21);
            this.cbStatus.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.nmToMinutes);
            this.panel2.Controls.Add(this.nmToHours);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nmFromMinutes);
            this.panel2.Controls.Add(this.nmFormHours);
            this.panel2.Location = new System.Drawing.Point(359, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 43);
            this.panel2.TabIndex = 2;
            // 
            // nmToMinutes
            // 
            this.nmToMinutes.Location = new System.Drawing.Point(207, 10);
            this.nmToMinutes.Name = "nmToMinutes";
            this.nmToMinutes.Size = new System.Drawing.Size(48, 20);
            this.nmToMinutes.TabIndex = 5;
            // 
            // nmToHours
            // 
            this.nmToHours.Location = new System.Drawing.Point(167, 10);
            this.nmToHours.Name = "nmToHours";
            this.nmToHours.Size = new System.Drawing.Size(34, 20);
            this.nmToHours.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nmFromMinutes
            // 
            this.nmFromMinutes.Location = new System.Drawing.Point(82, 11);
            this.nmFromMinutes.Name = "nmFromMinutes";
            this.nmFromMinutes.Size = new System.Drawing.Size(50, 20);
            this.nmFromMinutes.TabIndex = 1;
            // 
            // nmFormHours
            // 
            this.nmFormHours.Location = new System.Drawing.Point(42, 10);
            this.nmFormHours.Name = "nmFormHours";
            this.nmFormHours.Size = new System.Drawing.Size(34, 20);
            this.nmFormHours.TabIndex = 0;
            // 
            // txbJob
            // 
            this.txbJob.ForeColor = System.Drawing.SystemColors.Desktop;
            this.txbJob.Location = new System.Drawing.Point(62, 13);
            this.txbJob.Name = "txbJob";
            this.txbJob.Size = new System.Drawing.Size(291, 20);
            this.txbJob.TabIndex = 1;
            this.txbJob.Text = "Tên Công Việc ";
            // 
            // ckbDone
            // 
            this.ckbDone.AutoSize = true;
            this.ckbDone.Location = new System.Drawing.Point(4, 16);
            this.ckbDone.Name = "ckbDone";
            this.ckbDone.Size = new System.Drawing.Size(52, 17);
            this.ckbDone.TabIndex = 0;
            this.ckbDone.Text = "Done";
            this.ckbDone.UseVisualStyleBackColor = true;
            this.ckbDone.CheckedChanged += new System.EventHandler(this.ckbDone_CheckedChanged);
            // 
            // AJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AJob";
            this.Size = new System.Drawing.Size(929, 57);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmToMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmToHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFromMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmFormHours)).EndInit();
            this.ResumeLayout(false);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmFromMinutes;
        private System.Windows.Forms.NumericUpDown nmFormHours;
        private System.Windows.Forms.TextBox txbJob;
        private System.Windows.Forms.CheckBox ckbDone;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.NumericUpDown nmToMinutes;
        private System.Windows.Forms.NumericUpDown nmToHours;
        private System.Windows.Forms.Label label2;

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
