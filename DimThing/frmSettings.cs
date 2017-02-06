using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DimThing.Framework.Configuration;
using DimThing.Framework;
using System.Linq;

namespace DimThing
{
    public partial class frmSettings : Form
    {
        
        public frmSettings()
        {
            InitializeComponent();

            hotkeyTextBoxIncrease.KeyDown += (sender, args) => SetHotKey(args,hotkeyTextBoxIncrease);
            hotkeyTextBoxDecrease.KeyDown += (sender, args) => SetHotKey(args, hotkeyTextBoxDecrease);
            hotkeyTextBoxImmersiveMode.KeyDown += (sender, args) => SetHotKey(args, hotkeyTextBoxImmersiveMode);


            hotkeyTextBoxIncrease.Text = AppConfigs.Configuration.IncreaseDimness.ToString();
            hotkeyTextBoxDecrease.Text = AppConfigs.Configuration.DecreaseDimness.ToString();
            hotkeyTextBoxImmersiveMode.Text = AppConfigs.Configuration.ToggleMode.ToString();
            immersiveModeCheckBox.Checked = AppConfigs.Configuration.ImmersiveModeAllowed;

            hotkeyTextBoxIncrease.Tag = "Increase";
            hotkeyTextBoxDecrease.Tag = "Decrease";
            hotkeyTextBoxImmersiveMode.Tag = "Mode";

        }

        private void SetHotKey(KeyEventArgs e, TextBox t)
        {
            HotKeys.ModifierKeys modifierKeys = 0;
            String displayString = "";
            foreach(var pressedModifier in KeyboardWindowsAPI.GetPressedModifiers())
            {
                if ((pressedModifier & Keys.Modifiers) == Keys.Control)
                {
                    modifierKeys |= HotKeys.ModifierKeys.Control;
                    displayString += "Ctrl+";
                }
                if ((pressedModifier & Keys.Modifiers) == Keys.Alt)
                {
                    modifierKeys |= HotKeys.ModifierKeys.Alt;
                    displayString += "Alt+";
                }
                if ((pressedModifier & Keys.Modifiers) == Keys.Shift)
                {
                    modifierKeys |= HotKeys.ModifierKeys.Shift;
                    displayString += "Shift+";
                }
                if (pressedModifier == Keys.LWin || pressedModifier == Keys.RWin)
                {
                    modifierKeys |= HotKeys.ModifierKeys.Win;
                    displayString += "Win+";
                }
            }

            var normalPressedKeys = KeyboardWindowsAPI.GetNormalPressedKeys();
            var key = normalPressedKeys.FirstOrDefault();

            if(key == Keys.None)
            {
                t.Text = $"{displayString}";
                t.ForeColor = Color.Red;
            }
            else
            {
                t.Text = $"{displayString}{key}";
                t.ForeColor = frmTray.app.SetHotKeyCombination(new HotKeys(e.KeyCode, modifierKeys), t.Tag.ToString()) ? Color.Green : Color.Red;
            }
        }

        private void hotkeyTextBoxImmersiveMode_TextChanged(object sender, EventArgs e)
        {

        }

        private void hotkeyTextBoxDecrease_TextChanged(object sender, EventArgs e)
        {

        }

        private void hotkeyTextBoxIncrease_TextChanged(object sender, EventArgs e)
        {

        }

        private void immersiveModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            AppConfigs.Configuration.ImmersiveModeAllowed = immersiveModeCheckBox.Checked;
            frmTray.app.immersiveModeAllowedSet(immersiveModeCheckBox.Checked);
            
        }
    }
}
