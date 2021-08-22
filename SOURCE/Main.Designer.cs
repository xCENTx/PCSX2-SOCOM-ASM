
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
            this.The_CheckBox.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.The_CheckBox.ForeColor = System.Drawing.SystemColors.Control;
            this.The_CheckBox.Location = new System.Drawing.Point(76, 37);
            this.The_CheckBox.Name = "The_CheckBox";
            this.The_CheckBox.Size = new System.Drawing.Size(117, 33);
            this.The_CheckBox.TabIndex = 0;
            this.The_CheckBox.Text = "INJECT";
            this.The_CheckBox.UseVisualStyleBackColor = true;
            // 
            // SCAN_BUTTON
            // 
            this.SCAN_BUTTON.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCAN_BUTTON.ForeColor = System.Drawing.Color.Green;
            this.SCAN_BUTTON.Location = new System.Drawing.Point(69, 2);
            this.SCAN_BUTTON.Name = "SCAN_BUTTON";
            this.SCAN_BUTTON.Size = new System.Drawing.Size(132, 37);
            this.SCAN_BUTTON.TabIndex = 1;
            this.SCAN_BUTTON.Text = "SCAN";
            this.SCAN_BUTTON.UseVisualStyleBackColor = true;
            this.SCAN_BUTTON.Click += new System.EventHandler(this.SCAN_BUTTON_Click);
            // 
            // scan_label
            // 
            this.scan_label.AutoSize = true;
            this.scan_label.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan_label.Location = new System.Drawing.Point(12, 74);
            this.scan_label.Name = "scan_label";
            this.scan_label.Size = new System.Drawing.Size(15, 22);
            this.scan_label.TabIndex = 2;
            this.scan_label.Text = ".";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(273, 105);
            this.Controls.Add(this.scan_label);
            this.Controls.Add(this.SCAN_BUTTON);
            this.Controls.Add(this.The_CheckBox);
            this.Name = "Main";
            this.Text = "NightFyreTV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer ProcessTimer;
        private System.Windows.Forms.Timer MemoryTimer;
        private System.Windows.Forms.CheckBox The_CheckBox;
        private System.Windows.Forms.Button SCAN_BUTTON;
        private System.Windows.Forms.Label scan_label;
    }
}

