
namespace NightFyre_SOCOM_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ScanButton = new System.Windows.Forms.Button();
            this.PerfectShotCheckBox = new System.Windows.Forms.CheckBox();
            debugLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessTimer = new System.Windows.Forms.Timer(this.components);
            this.MemoryTimer = new System.Windows.Forms.Timer(this.components);
            this.PatchButton = new System.Windows.Forms.Button();
            debugAddr1_label = new System.Windows.Forms.Label();
            debugAddr2_label = new System.Windows.Forms.Label();
            debugAddr3_label = new System.Windows.Forms.Label();
            debugAddr4_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MaximizeBox = false;
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScanButton
            // 
            this.ScanButton.Font = new System.Drawing.Font("Verdana", 10F);
            this.ScanButton.Location = new System.Drawing.Point(7, 12);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(60, 23);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "SCAN";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // PerfectShotCheckBox
            // 
            this.PerfectShotCheckBox.AutoSize = true;
            this.PerfectShotCheckBox.Font = new System.Drawing.Font("Verdana", 10F);
            this.PerfectShotCheckBox.Location = new System.Drawing.Point(73, 14);
            this.PerfectShotCheckBox.Name = "PerfectShotCheckBox";
            this.PerfectShotCheckBox.Size = new System.Drawing.Size(135, 21);
            this.PerfectShotCheckBox.TabIndex = 1;
            this.PerfectShotCheckBox.Text = "PERFECT SHOT";
            this.PerfectShotCheckBox.UseVisualStyleBackColor = true;
            // 
            // debugLabel
            // 
            debugLabel.AutoSize = true;
            debugLabel.Font = new System.Drawing.Font("Verdana", 10F);
            debugLabel.Location = new System.Drawing.Point(3, 3);
            debugLabel.Name = "debugLabel";
            debugLabel.Size = new System.Drawing.Size(41, 17);
            debugLabel.TabIndex = 2;
            debugLabel.Text = "stuff";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(debugLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 25);
            this.panel1.TabIndex = 3;
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
            // PatchButton
            // 
            this.PatchButton.Font = new System.Drawing.Font("Verdana", 10F);
            this.PatchButton.Location = new System.Drawing.Point(23, 95);
            this.PatchButton.Name = "PatchButton";
            this.PatchButton.Size = new System.Drawing.Size(71, 23);
            this.PatchButton.TabIndex = 5;
            this.PatchButton.Text = "PATCH";
            this.PatchButton.UseVisualStyleBackColor = true;
            this.PatchButton.Click += new System.EventHandler(this.PatchButton_Click);
            // 
            // debugAddr1_label
            // 
            debugAddr1_label.AutoSize = true;
            debugAddr1_label.Font = new System.Drawing.Font("Verdana", 10F);
            debugAddr1_label.Location = new System.Drawing.Point(3, 2);
            debugAddr1_label.Name = "debugAddr1_label";
            debugAddr1_label.Size = new System.Drawing.Size(48, 17);
            debugAddr1_label.TabIndex = 2;
            debugAddr1_label.Text = "label1";
            // 
            // debugAddr2_label
            // 
            debugAddr2_label.AutoSize = true;
            debugAddr2_label.Font = new System.Drawing.Font("Verdana", 10F);
            debugAddr2_label.Location = new System.Drawing.Point(3, 19);
            debugAddr2_label.Name = "debugAddr2_label";
            debugAddr2_label.Size = new System.Drawing.Size(48, 17);
            debugAddr2_label.TabIndex = 3;
            debugAddr2_label.Text = "label1";
            // 
            // debugAddr3_label
            // 
            debugAddr3_label.AutoSize = true;
            debugAddr3_label.Font = new System.Drawing.Font("Verdana", 10F);
            debugAddr3_label.Location = new System.Drawing.Point(3, 36);
            debugAddr3_label.Name = "debugAddr3_label";
            debugAddr3_label.Size = new System.Drawing.Size(48, 17);
            debugAddr3_label.TabIndex = 4;
            debugAddr3_label.Text = "label2";
            // 
            // debugAddr4_label
            // 
            debugAddr4_label.AutoSize = true;
            debugAddr4_label.Font = new System.Drawing.Font("Verdana", 10F);
            debugAddr4_label.Location = new System.Drawing.Point(3, 54);
            debugAddr4_label.Name = "debugAddr4_label";
            debugAddr4_label.Size = new System.Drawing.Size(48, 17);
            debugAddr4_label.TabIndex = 5;
            debugAddr4_label.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(debugAddr4_label);
            this.panel2.Controls.Add(debugAddr3_label);
            this.panel2.Controls.Add(debugAddr2_label);
            this.panel2.Controls.Add(debugAddr1_label);
            this.panel2.Location = new System.Drawing.Point(100, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(92, 77);
            this.panel2.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 65);
            this.Controls.Add(this.PatchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PerfectShotCheckBox);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "VIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.CheckBox PerfectShotCheckBox;
        public static System.Windows.Forms.Label debugLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.Button PatchButton;
        public static System.Windows.Forms.Label debugAddr1_label;
        public static System.Windows.Forms.Label debugAddr2_label;
        public static System.Windows.Forms.Label debugAddr3_label;
        public static System.Windows.Forms.Label debugAddr4_label;
        private System.Windows.Forms.Panel panel2;
    }
}

