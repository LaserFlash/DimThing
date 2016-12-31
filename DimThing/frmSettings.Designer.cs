namespace DimThing
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.hotkeys = new System.Windows.Forms.GroupBox();
            this.hotkeyTextBoxMonitorMode = new System.Windows.Forms.TextBox();
            this.hotkeyLableMonitorMode = new System.Windows.Forms.Label();
            this.hotkeyTextBoxDecrease = new System.Windows.Forms.TextBox();
            this.hotkeyTextBoxIncrease = new System.Windows.Forms.TextBox();
            this.hotkeyLabledecreaseDim = new System.Windows.Forms.Label();
            this.hotkeyLableincreaseDim = new System.Windows.Forms.Label();
            this.monitorMode = new System.Windows.Forms.GroupBox();
            this.monitorModeCheckBox = new System.Windows.Forms.CheckBox();
            this.hotkeys.SuspendLayout();
            this.monitorMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotkeys
            // 
            this.hotkeys.AutoSize = true;
            this.hotkeys.BackColor = System.Drawing.SystemColors.Control;
            this.hotkeys.Controls.Add(this.hotkeyTextBoxMonitorMode);
            this.hotkeys.Controls.Add(this.hotkeyLableMonitorMode);
            this.hotkeys.Controls.Add(this.hotkeyTextBoxDecrease);
            this.hotkeys.Controls.Add(this.hotkeyTextBoxIncrease);
            this.hotkeys.Controls.Add(this.hotkeyLabledecreaseDim);
            this.hotkeys.Controls.Add(this.hotkeyLableincreaseDim);
            this.hotkeys.Location = new System.Drawing.Point(12, 12);
            this.hotkeys.Name = "hotkeys";
            this.hotkeys.Size = new System.Drawing.Size(313, 109);
            this.hotkeys.TabIndex = 0;
            this.hotkeys.TabStop = false;
            this.hotkeys.Text = "HotKeys";
            // 
            // hotkeyTextBoxMonitorMode
            // 
            this.hotkeyTextBoxMonitorMode.Location = new System.Drawing.Point(109, 69);
            this.hotkeyTextBoxMonitorMode.Name = "hotkeyTextBoxMonitorMode";
            this.hotkeyTextBoxMonitorMode.Size = new System.Drawing.Size(198, 20);
            this.hotkeyTextBoxMonitorMode.TabIndex = 5;
            this.hotkeyTextBoxMonitorMode.TextChanged += new System.EventHandler(this.hotkeyTextBoxMonitorMode_TextChanged);
            // 
            // hotkeyLableMonitorMode
            // 
            this.hotkeyLableMonitorMode.AutoSize = true;
            this.hotkeyLableMonitorMode.Location = new System.Drawing.Point(7, 76);
            this.hotkeyLableMonitorMode.Name = "hotkeyLableMonitorMode";
            this.hotkeyLableMonitorMode.Size = new System.Drawing.Size(72, 13);
            this.hotkeyLableMonitorMode.TabIndex = 4;
            this.hotkeyLableMonitorMode.Text = "Monitor Mode";
            // 
            // hotkeyTextBoxDecrease
            // 
            this.hotkeyTextBoxDecrease.Location = new System.Drawing.Point(109, 43);
            this.hotkeyTextBoxDecrease.Name = "hotkeyTextBoxDecrease";
            this.hotkeyTextBoxDecrease.Size = new System.Drawing.Size(198, 20);
            this.hotkeyTextBoxDecrease.TabIndex = 3;
            this.hotkeyTextBoxDecrease.TextChanged += new System.EventHandler(this.hotkeyTextBoxDecrease_TextChanged);
            // 
            // hotkeyTextBoxIncrease
            // 
            this.hotkeyTextBoxIncrease.Location = new System.Drawing.Point(109, 19);
            this.hotkeyTextBoxIncrease.Name = "hotkeyTextBoxIncrease";
            this.hotkeyTextBoxIncrease.Size = new System.Drawing.Size(198, 20);
            this.hotkeyTextBoxIncrease.TabIndex = 2;
            this.hotkeyTextBoxIncrease.TextChanged += new System.EventHandler(this.hotkeyTextBoxIncrease_TextChanged);
            // 
            // hotkeyLabledecreaseDim
            // 
            this.hotkeyLabledecreaseDim.AutoSize = true;
            this.hotkeyLabledecreaseDim.Location = new System.Drawing.Point(7, 50);
            this.hotkeyLabledecreaseDim.Name = "hotkeyLabledecreaseDim";
            this.hotkeyLabledecreaseDim.Size = new System.Drawing.Size(96, 13);
            this.hotkeyLabledecreaseDim.TabIndex = 1;
            this.hotkeyLabledecreaseDim.Text = "Decrease Dimness";
            // 
            // hotkeyLableincreaseDim
            // 
            this.hotkeyLableincreaseDim.AutoSize = true;
            this.hotkeyLableincreaseDim.Location = new System.Drawing.Point(7, 23);
            this.hotkeyLableincreaseDim.Name = "hotkeyLableincreaseDim";
            this.hotkeyLableincreaseDim.Size = new System.Drawing.Size(91, 13);
            this.hotkeyLableincreaseDim.TabIndex = 0;
            this.hotkeyLableincreaseDim.Text = "Increase Dimness";
            // 
            // monitorMode
            // 
            this.monitorMode.Controls.Add(this.monitorModeCheckBox);
            this.monitorMode.Location = new System.Drawing.Point(331, 12);
            this.monitorMode.Name = "monitorMode";
            this.monitorMode.Size = new System.Drawing.Size(138, 109);
            this.monitorMode.TabIndex = 1;
            this.monitorMode.TabStop = false;
            this.monitorMode.Text = "Monitor Mode";
            // 
            // monitorModeCheckBox
            // 
            this.monitorModeCheckBox.AutoSize = true;
            this.monitorModeCheckBox.Location = new System.Drawing.Point(7, 23);
            this.monitorModeCheckBox.Name = "monitorModeCheckBox";
            this.monitorModeCheckBox.Size = new System.Drawing.Size(119, 17);
            this.monitorModeCheckBox.TabIndex = 0;
            this.monitorModeCheckBox.Text = "Allow Monitor Mode";
            this.monitorModeCheckBox.UseVisualStyleBackColor = true;
            this.monitorModeCheckBox.CheckedChanged += new System.EventHandler(this.monitorModeCheckBox_CheckedChanged);
            // 
            // frmSettings
            // 
            this.ClientSize = new System.Drawing.Size(481, 138);
            this.Controls.Add(this.monitorMode);
            this.Controls.Add(this.hotkeys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.hotkeys.ResumeLayout(false);
            this.hotkeys.PerformLayout();
            this.monitorMode.ResumeLayout(false);
            this.monitorMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox hotkeys;
        private System.Windows.Forms.GroupBox monitorMode;
        private System.Windows.Forms.Label hotkeyLableincreaseDim;
        private System.Windows.Forms.TextBox hotkeyTextBoxMonitorMode;
        private System.Windows.Forms.Label hotkeyLableMonitorMode;
        private System.Windows.Forms.TextBox hotkeyTextBoxDecrease;
        private System.Windows.Forms.TextBox hotkeyTextBoxIncrease;
        private System.Windows.Forms.Label hotkeyLabledecreaseDim;
        private System.Windows.Forms.CheckBox monitorModeCheckBox;
    }
}