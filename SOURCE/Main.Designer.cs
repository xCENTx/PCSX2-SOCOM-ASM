
namespace PCSX2_ASM
{
    partial class Main
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
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.The_CheckBox = new System.Windows.Forms.CheckBox();
            this.SCAN_BUTTON = new System.Windows.Forms.Button();
            this.scan_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PerfectShotPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DEBUG3 = new System.Windows.Forms.Label();
            this.DEBUG2 = new System.Windows.Forms.Label();
            this.DEBUG1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessTimer
            // 
            this.ProcessTimer.Enabled = true;
            this.ProcessTimer.Tick += new System.EventHandler(this.ProcessTimer_Tick);
            // 
            // MemoryTimer
            // 
            this.MemoryTimer.Enabled = true;
            this.MemoryTimer.Tick += new System.EventHandler(this.MemoryTimer_Tick);
            // 
            // The_CheckBox
            // 
            this.The_CheckBox.AutoSize = true;
            this.The_CheckBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.The_CheckBox.ForeColor = System.Drawing.SystemColors.Control;
            this.The_CheckBox.Location = new System.Drawing.Point(77, 9);
            this.The_CheckBox.Name = "The_CheckBox";
            this.The_CheckBox.Size = new System.Drawing.Size(154, 23);
            this.The_CheckBox.TabIndex = 0;
            this.The_CheckBox.Text = "PERFECT SHOT";
            this.The_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SCAN_BUTTON
            // 
            this.SCAN_BUTTON.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCAN_BUTTON.ForeColor = System.Drawing.Color.Green;
            this.SCAN_BUTTON.Location = new System.Drawing.Point(12, 9);
            this.SCAN_BUTTON.Name = "SCAN_BUTTON";
            this.SCAN_BUTTON.Size = new System.Drawing.Size(59, 22);
            this.SCAN_BUTTON.TabIndex = 1;
            this.SCAN_BUTTON.Text = "SCAN";
            this.SCAN_BUTTON.UseVisualStyleBackColor = true;
            this.SCAN_BUTTON.Click += new System.EventHandler(this.SCAN_BUTTON_Click);
            // 
            // scan_label
            // 
            this.scan_label.AutoSize = true;
            this.scan_label.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_label.ForeColor = System.Drawing.SystemColors.Control;
            this.scan_label.Location = new System.Drawing.Point(3, 0);
            this.scan_label.Name = "scan_label";
            this.scan_label.Size = new System.Drawing.Size(51, 22);
            this.scan_label.TabIndex = 2;
            this.scan_label.Text = "stuff";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.scan_label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 108);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 22);
            this.panel1.TabIndex = 3;
            // 
            // PerfectShotPanel
            // 
            this.PerfectShotPanel.Location = new System.Drawing.Point(75, 12);
            this.PerfectShotPanel.Name = "PerfectShotPanel";
            this.PerfectShotPanel.Size = new System.Drawing.Size(17, 17);
            this.PerfectShotPanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.DEBUG3);
            this.panel2.Controls.Add(this.DEBUG2);
            this.panel2.Controls.Add(this.DEBUG1);
            this.panel2.Location = new System.Drawing.Point(121, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(101, 65);
            this.panel2.TabIndex = 3;
            // 
            // DEBUG3
            // 
            this.DEBUG3.AutoSize = true;
            this.DEBUG3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEBUG3.ForeColor = System.Drawing.SystemColors.Control;
            this.DEBUG3.Location = new System.Drawing.Point(6, 41);
            this.DEBUG3.Name = "DEBUG3";
            this.DEBUG3.Size = new System.Drawing.Size(54, 19);
            this.DEBUG3.TabIndex = 2;
            this.DEBUG3.Text = "label2";
            // 
            // DEBUG2
            // 
            this.DEBUG2.AutoSize = true;
            this.DEBUG2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEBUG2.ForeColor = System.Drawing.SystemColors.Control;
            this.DEBUG2.Location = new System.Drawing.Point(6, 22);
            this.DEBUG2.Name = "DEBUG2";
            this.DEBUG2.Size = new System.Drawing.Size(54, 19);
            this.DEBUG2.TabIndex = 1;
            this.DEBUG2.Text = "label1";
            // 
            // DEBUG1
            // 
            this.DEBUG1.AutoSize = true;
            this.DEBUG1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEBUG1.ForeColor = System.Drawing.SystemColors.Control;
            this.DEBUG1.Location = new System.Drawing.Point(6, 3);
            this.DEBUG1.Name = "DEBUG1";
            this.DEBUG1.Size = new System.Drawing.Size(54, 19);
            this.DEBUG1.TabIndex = 0;
            this.DEBUG1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "PATCH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(234, 130);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SCAN_BUTTON);
            this.Controls.Add(this.The_CheckBox);
            this.Controls.Add(this.PerfectShotPanel);
            this.Name = "Main";
            this.Text = "NightFyreTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.CheckBox The_CheckBox;
        private System.Windows.Forms.Button SCAN_BUTTON;
        private System.Windows.Forms.Label scan_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PerfectShotPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label DEBUG3;
        private System.Windows.Forms.Label DEBUG2;
        private System.Windows.Forms.Label DEBUG1;
        private System.Windows.Forms.Button button1;
    }
}

