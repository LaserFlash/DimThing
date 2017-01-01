using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DimThing.Framework.Configuration;

namespace DimThing
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            hotkeyTextBoxIncrease.Text = AppConfigs.Configuration.IncreaseDimness.ToString();
            hotkeyTextBoxDecrease.Text = AppConfigs.Configuration.DecreaseDimness.ToString();
            hotkeyTextBoxMonitorMode.Text = AppConfigs.Configuration.ToggleMode.ToString();
        }

        private void hotkeyTextBoxMonitorMode_TextChanged(object sender, EventArgs e)
        {

        }

        private void hotkeyTextBoxDecrease_TextChanged(object sender, EventArgs e)
        {

        }

        private void hotkeyTextBoxIncrease_TextChanged(object sender, EventArgs e)
        {

        }

        private void monitorModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
