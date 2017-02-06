using System;
using System.Windows.Forms;
using System.Collections.Generic;

using DimThing.Framework;
using DimThing.Framework.Configuration;

namespace DimThing
{
    public partial class frmTray : Form
    {
        private LinkedList<ToolStripMenuItem> dimAmounts;
        private LinkedListNode<ToolStripMenuItem> currentCheckedDimness;

        public static App app;

        public frmTray()
        {
            InitializeComponent();
            dimAmounts = new LinkedList<ToolStripMenuItem>();

            dimAmounts.AddFirst(menu99);
            dimAmounts.AddFirst(menu90);
            dimAmounts.AddFirst(menu80);
            dimAmounts.AddFirst(menu70);
            dimAmounts.AddFirst(menu60);
            dimAmounts.AddFirst(menu50);
            dimAmounts.AddFirst(menu50);
            dimAmounts.AddFirst(menu40);
            dimAmounts.AddFirst(menu30);
            dimAmounts.AddFirst(menu20);
            dimAmounts.AddFirst(menu10);
            dimAmounts.AddFirst(menuNormal);

            currentCheckedDimness = dimAmounts.First;
            currentCheckedDimness.Value.Checked = true;
            app = new App(this);

        }

        public void increaseDimness()
        {
            if (currentCheckedDimness == null) return;
            if (currentCheckedDimness.Next != null)
            {
                currentCheckedDimness.Value.Checked = false;
                currentCheckedDimness = currentCheckedDimness.Next;
                currentCheckedDimness.Value.Checked = true;
            }
        }

        public void decreaseDimness()
        {
            if (currentCheckedDimness.Previous != null)
            {
                currentCheckedDimness.Value.Checked = false;
                currentCheckedDimness = currentCheckedDimness.Previous;
                currentCheckedDimness.Value.Checked = true;
            }
        }


        private void frmTray_Load(object sender, EventArgs e)
        {
            menuNormal.Click += numericMenus_Click;
            menu10.Click += numericMenus_Click;
            menu20.Click += numericMenus_Click;
            menu30.Click += numericMenus_Click;
            menu40.Click += numericMenus_Click;
            menu50.Click += numericMenus_Click;
            menu60.Click += numericMenus_Click;
            menu70.Click += numericMenus_Click;
            menu80.Click += numericMenus_Click;
            menu90.Click += numericMenus_Click;
            menu99.Click += numericMenus_Click;
        }

        private void numericMenus_Click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;

            if (currentCheckedDimness.Value != null)
                currentCheckedDimness.Value.Checked = false;

            menuItem.Checked = true;
            currentCheckedDimness = dimAmounts.Find(menuItem);

            var value = float.Parse((menuItem.Tag.ToString()));
            app.changeDimness(value);

        }

        private void monitorMode_click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;
            app.toggleImmersiveMode();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            contextMenuStrip1.Show();
        }

        private void settings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.Show();
        }

        private void menuRestart_Click(object sender, EventArgs e)
        {
            //Save Configuration
            AppConfigs.Configuration.Dimness = app.getDimness();
            AppConfigs.Configuration.ImmersiveMode = app.getImmersiveMode();
            AppConfigs.Configuration.Save();

            var exePath = Application.ExecutablePath;
            Application.Restart();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            //Display a Message box asking if the user wishes to exit.
            DialogResult reply = MessageBox.Show("Are you sure you want to exit?", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //If users answer was yes.
            if (reply == DialogResult.Yes)
            {
                //Save Configuration
                AppConfigs.Configuration.Dimness = app.getDimness();
                AppConfigs.Configuration.ImmersiveMode = app.getImmersiveMode();
                AppConfigs.Configuration.Save();

                //Remove tray Icon
                notifyIcon1.Dispose();
                app.exit();
            }
        }

        public void ToggleMode()
        {
            immersiveMode.Checked = !immersiveMode.Checked;
        }
    }

}