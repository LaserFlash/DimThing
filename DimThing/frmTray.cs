using System;
using System.Windows.Forms;

namespace DimThing
{
	public partial class frmTray : Form
	{
		// list of overlays currently displayed
		private System.Collections.Generic.List<frmMain> overlays = new System.Collections.Generic.List<frmMain>();

		private ToolStripMenuItem lastMenuItem;
        private float dimness = 0;
        private Boolean mode = false;
        private Boolean primaryMonitorAllowed = false;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public frmTray()
        {
            InitializeComponent();

            /* Increase Dimness */
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.Alt, Keys.Add.GetHashCode());
            RegisterHotKey(this.Handle, 0, (int)KeyModifier.Alt, Keys.Oemplus.GetHashCode());

            /* Decrease Dimness */
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.Alt, Keys.Subtract.GetHashCode());
            RegisterHotKey(this.Handle, 1, (int)KeyModifier.Alt, Keys.OemMinus.GetHashCode());

            /* Toggle monitorMode */
            RegisterHotKey(this.Handle, 2, (int)KeyModifier.Alt, Keys.OemPipe.GetHashCode());

            this.dimness = Convert.ToSingle(System.Configuration.ConfigurationManager.AppSettings["dimness"]);

        }

        enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                /* Note that the three lines below are not needed if you only want to register one hotkey.
                 * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */

                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.

                //Increase Percrent of Dimming.
                if (id == 0)
                {
                    if (dimness == 99) return;
                    dimness = Math.Min(dimness + 10, 99);                    
                }

                //Decrease Percent of Dimming.
                if(id == 1)
                {
                    if (dimness == 0) return;
                    if (dimness == 99)
                    {
                        dimness = 80;
                    }
                    else
                    {
                        dimness -= 10;
                    }                 
                }

                //Only allow shortcut if more than one screen present
                if (id == 2 && primaryMonitorAllowed)
                {
                    mode = !mode;
                    monitorMode.PerformClick();
                    return;
                }


                //Choose the Menu Item based on new percent and click.
                foreach (ToolStripMenuItem item in this.contextMenuStrip1.Items)
                {
                    if (item.Text.Contains(dimness.ToString()))
                    {
                        item.PerformClick();
                        return;
                    }
                }



            }
        }

        private void configureOverlays(float dimValue)
		{
			// remove exiting overlays
			clearOverlays();

            monitorMode.Visible = false;
            primaryMonitorAllowed = false;
            toolStripSeparator2.Visible = false;

			// add screens if they don't already exist
			if (overlays.Count != Screen.AllScreens.Length)
			{
				// apply dimness onto all screens
				foreach (var screen in Screen.AllScreens)
				{
					frmMain overlay = new frmMain();
					overlay.Dimness = this.dimness / 100;
                    overlay.primaryMonitor = screen.Primary;
                    if(!screen.Primary)
                    {
                        monitorMode.Visible = true;
                        primaryMonitorAllowed = true;
                        toolStripSeparator2.Visible = true;
                    }

					overlay.Area = screen.Bounds;
					overlay.Show();

					// add to list of overlays
					overlays.Add(overlay);
				}
			}

            foreach (frmMain overlay in overlays)
                if (mode)
                {
                    if (!overlay.primaryMonitor)
                    {
                        overlay.Dimness = dimValue;
                    }
                }
                else
                {
                    overlay.Dimness = dimValue;
                }
		}

		private void clearOverlays()
		{
			foreach (var overlay in overlays)
                overlay.Dispose();

			overlays.Clear();
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

			// get command line values
			var arg = "";
			var args = Environment.GetCommandLineArgs();
			if (args.Length > 1) arg = args[1];

			//TEST: force command line arg to test
			//arg = "50";

			if (arg != "")
			{
				try
				{
					var val = float.Parse(arg) / 100;
					if (val > 99 || val < 0) throw new Exception("Out of range");
					configureOverlays(val);
                    dimness = val;
                }
				catch (Exception ex)
				{
					MessageBox.Show("Expecting number from 0 to 99 to represent percentage of dimming. 0 means normal, 99 being totally dark." + ex);
					configureOverlays(0);
                    dimness = 0;
				}
			}
			else
			{
				configureOverlays(dimness / 100);
            }
		}


		private void menuExit_Click(object sender, EventArgs e)
		{
			//Display a Message box asking if the user wishes to exit.
			DialogResult reply = MessageBox.Show("Are you sure you want to exit?", "Close?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			//If users answer was yes.
			if (reply == DialogResult.Yes)
			{
                // remove all overlays
                clearOverlays();
                //Remove tray Icon
                notifyIcon1.Dispose();
                //Remove Hotkey Hooks
                UnregisterHotKey(this.Handle, 0);
                UnregisterHotKey(this.Handle, 1);
                UnregisterHotKey(this.Handle, 2);
                //Clean up any used memeory.
                GC.Collect();
                //Close the Application.
                this.Dispose();
			}
		}

		private void numericMenus_Click(object sender, EventArgs e)
		{
			var menuItem = (ToolStripMenuItem)sender;

			if (lastMenuItem != null)
				lastMenuItem.Checked = false;

			menuItem.Checked = true;

			lastMenuItem = menuItem;

			var value = float.Parse((menuItem.Tag.ToString()));

            dimness = value;
            foreach (frmMain overlay in overlays)
                if (mode)
                {
                    if (!overlay.primaryMonitor)
                    {
                        overlay.Dimness = dimness / 100;
                    }
                }
                else
                {
                    overlay.Dimness = dimness / 100;
                }

            
		}

        private void monitorMode_click(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem)sender;          
            this.mode = menuItem.Checked;
            configureMonitorMode(menuItem.Checked, dimness);
        }

        private void configureMonitorMode(Boolean mode, float initialValue)
        {
            foreach (var overlay in overlays)
            {
                if (overlay.primaryMonitor)
                {
                    if (mode)
                        overlay.Dimness = 0;
                    else
                        overlay.Dimness = dimness / 100;
                    return;
                }
            }
        }

        private void menuRestart_Click(object sender, EventArgs e)
		{
			var exePath = Application.ExecutablePath;
			System.Diagnostics.Process.Start(exePath, (overlays[0].Dimness * 100).ToString());
			Application.Exit();
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
    }
}