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
            this.hotkeyTextBoxImmersiveMode = new System.Windows.Forms.TextBox();
            this.hotkeyLableImmersiveMode = new System.Windows.Forms.Label();
            this.hotkeyTextBoxDecrease = new System.Windows.Forms.TextBox();
            this.hotkeyTextBoxIncrease = new System.Windows.Forms.TextBox();
            this.hotkeyLabledecreaseDim = new System.Windows.Forms.Label();
            this.hotkeyLableincreaseDim = new System.Windows.Forms.Label();
            this.immersiveMode = new System.Windows.Forms.GroupBox();
            this.immersiveModeCheckBox = new System.Windows.Forms.CheckBox();
            this.startup = new System.Windows.Forms.GroupBox();
            this.runStartup = new System.Windows.Forms.CheckBox();
            this.loadPrevious = new System.Windows.Forms.CheckBox();
            this.hotkeys.SuspendLayout();
            this.immersiveMode.SuspendLayout();
            this.startup.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotkeys
            // 
            this.hotkeys.AutoSize = true;
            this.hotkeys.BackColor = System.Drawing.SystemColors.Control;
            this.hotkeys.Controls.Add(this.hotkeyTextBoxImmersiveMode);
            this.hotkeys.Controls.Add(this.hotkeyLableImmersiveMode);
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
            // hotkeyTextBoxImmersiveMode
            // 
            this.hotkeyTextBoxImmersiveMode.Location = new System.Drawing.Point(109, 69);
            this.hotkeyTextBoxImmersiveMode.Name = "hotkeyTextBoxImmersiveMode";
            this.hotkeyTextBoxImmersiveMode.Size = new System.Drawing.Size(198, 20);
            this.hotkeyTextBoxImmersiveMode.TabIndex = 5;
            this.hotkeyTextBoxImmersiveMode.TextChanged += new System.EventHandler(this.hotkeyTextBoxImmersiveMode_TextChanged);
            // 
            // hotkeyLableImmersiveMode
            // 
            this.hotkeyLableImmersiveMode.AutoSize = true;
            this.hotkeyLableImmersiveMode.Location = new System.Drawing.Point(7, 76);
            this.hotkeyLableImmersiveMode.Name = "hotkeyLableImmersiveMode";
            this.hotkeyLableImmersiveMode.Size = new System.Drawing.Size(72, 13);
            this.hotkeyLableImmersiveMode.TabIndex = 4;
            this.hotkeyLableImmersiveMode.Text = "Monitor Mode";
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
            // immersiveMode
            // 
            this.immersiveMode.Controls.Add(this.immersiveModeCheckBox);
            this.immersiveMode.Location = new System.Drawing.Point(331, 12);
            this.immersiveMode.Name = "immersiveMode";
            this.immersiveMode.Size = new System.Drawing.Size(138, 109);
            this.immersiveMode.TabIndex = 1;
            this.immersiveMode.TabStop = false;
            this.immersiveMode.Text = "Monitor Mode";
            // 
            // immersiveModeCheckBox
            // 
            this.immersiveModeCheckBox.AutoSize = true;
            this.immersiveModeCheckBox.Location = new System.Drawing.Point(7, 23);
            this.immersiveModeCheckBox.Name = "immersiveModeCheckBox";
            this.immersiveModeCheckBox.Size = new System.Drawing.Size(119, 17);
            this.immersiveModeCheckBox.TabIndex = 0;
            this.immersiveModeCheckBox.Text = "Allow Monitor Mode";
            this.immersiveModeCheckBox.UseVisualStyleBackColor = true;
            this.immersiveModeCheckBox.CheckedChanged += new System.EventHandler(this.immersiveModeCheckBox_CheckedChanged);
            // 
            // startup
            // 
            this.startup.Controls.Add(this.loadPrevious);
            this.startup.Controls.Add(this.runStartup);
            this.startup.Location = new System.Drawing.Point(13, 128);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(312, 65);
            this.startup.TabIndex = 2;
            this.startup.TabStop = false;
            this.startup.Text = "Start Up";
            // 
            // runStartup
            // 
            this.runStartup.AutoSize = true;
            this.runStartup.Location = new System.Drawing.Point(9, 20);
            this.runStartup.Name = "runStartup";
            this.runStartup.Size = new System.Drawing.Size(100, 17);
            this.runStartup.TabIndex = 0;
            this.runStartup.Text = "Run at Start Up";
            this.runStartup.UseVisualStyleBackColor = true;
            this.runStartup.CheckedChanged += new System.EventHandler(this.runStartup_CheckedChanged);
            // 
            // loadPrevious
            // 
            this.loadPrevious.AutoSize = true;
            this.loadPrevious.Location = new System.Drawing.Point(9, 44);
            this.loadPrevious.Name = "loadPrevious";
            this.loadPrevious.Size = new System.Drawing.Size(122, 17);
            this.loadPrevious.TabIndex = 1;
            this.loadPrevious.Text = "Load Previous State";
            this.loadPrevious.UseVisualStyleBackColor = true;
            this.loadPrevious.CheckedChanged += new System.EventHandler(this.loadPrevious_CheckedChanged);
            // 
            // frmSettings
            // 
            this.ClientSize = new System.Drawing.Size(481, 203);
            this.Controls.Add(this.startup);
            this.Controls.Add(this.immersiveMode);
            this.Controls.Add(this.hotkeys);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.hotkeys.ResumeLayout(false);
            this.hotkeys.PerformLayout();
            this.immersiveMode.ResumeLayout(false);
            this.immersiveMode.PerformLayout();
            this.startup.ResumeLayout(false);
            this.startup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox hotkeys;
        private System.Windows.Forms.GroupBox immersiveMode;
        private System.Windows.Forms.Label hotkeyLableincreaseDim;
        private System.Windows.Forms.TextBox hotkeyTextBoxImmersiveMode;
        private System.Windows.Forms.Label hotkeyLableImmersiveMode;
        private System.Windows.Forms.TextBox hotkeyTextBoxDecrease;
        private System.Windows.Forms.TextBox hotkeyTextBoxIncrease;
        private System.Windows.Forms.Label hotkeyLabledecreaseDim;
        private System.Windows.Forms.CheckBox immersiveModeCheckBox;
        private System.Windows.Forms.GroupBox startup;
        private System.Windows.Forms.CheckBox loadPrevious;
        private System.Windows.Forms.CheckBox runStartup;
    }
}