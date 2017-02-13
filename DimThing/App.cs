using System;
using System.Windows.Forms;
using System.Collections.Generic;

using DimThing.Framework;
using DimThing.Framework.Configuration;
using Microsoft.Win32;

namespace DimThing
{
    public sealed class App
    {
        // list of overlays currently displayed
        private List<frmMain> overlays = new List<frmMain>();

        private frmTray tray;

        //Current Dimness percent
        private Boolean immersiveModeAllowed;
        private Boolean immersiveMode;
        private float dimness = 0;
        KeyboardHook keyHook = new KeyboardHook();       

        public App(frmTray o)
        {
            tray = o;
            //event to handle hotkeys
            keyHook.KeyPressed += new EventHandler<KeyPressedEventArgs>(keyHook_KeyPressed);
            //register hotkeys
            keyHook.RegisterHotKey(AppConfigs.Configuration.IncreaseDimness); //Increase Dimness    
            keyHook.RegisterHotKey(AppConfigs.Configuration.DecreaseDimness); //Decrease Dimness   
            keyHook.RegisterHotKey(AppConfigs.Configuration.ToggleMode); //Toggle Monitor Mode
            

            if (AppConfigs.Configuration.FirstRun)
            {
                AppConfigs.Configuration.ImmersiveModeAllowed = Screen.AllScreens.Length > 1;
                AppConfigs.Configuration.FirstRun = false;
                AddApplicationToStartup();
            }

            if (AppConfigs.Configuration.LoadAtStart)
            {
                //Load previous dimness from file
                this.dimness = AppConfigs.Configuration.Dimness;
                this.immersiveMode = AppConfigs.Configuration.ImmersiveMode;
            }
            else
            {
                this.dimness = 0;
                this.immersiveMode = false;
            }

            immersiveModeAllowed = AppConfigs.Configuration.ImmersiveModeAllowed;  
                         
            //Select dimness percent in tray
            for (int i = 0; i < dimness; i+= 10)
            {
                tray.increaseDimness();                
            }

            tray.ImmersiveModeCheck(immersiveMode);                            
            
            configureOverlays();
            updateOverlays();
        }        

        public void changeDimness(float val)
        {
            dimness = val;
            updateOverlays();
        }

        public void toggleImmersiveMode()
        {
            immersiveMode = !immersiveMode;
            foreach (var overlay in overlays)
            {
                if (overlay.primaryMonitor)
                {
                    if (immersiveMode) { overlay.Dimness = 0; }
                    else { overlay.Dimness = this.dimness / 100; }
                    return;
                }
            }
        }
        private void updateOverlays()
        {
            foreach (frmMain overlay in overlays)
            {
                if (immersiveMode)
                {
                    if (!overlay.primaryMonitor) { overlay.Dimness = dimness / 100; }
                    else { overlay.Dimness = 0; }
                }
                else { overlay.Dimness = dimness / 100; }
            }
        }

        public void keyHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //Increase Percrent of Dimming.
            if (e.HotKeys == AppConfigs.Configuration.IncreaseDimness)
            {
                if (dimness == 99) return;
                changeDimness(Math.Min(dimness + 10, 99));
                tray.increaseDimness();
            }

            //Decrease Percent of Dimming.
            if (e.HotKeys == AppConfigs.Configuration.DecreaseDimness)
            {
                
                if (dimness == 0) return;
                if (dimness == 99)
                {
                    changeDimness(90);
                }
                else
                {
                    changeDimness(dimness - 10);
                }                
                tray.decreaseDimness();
            }

            //Only allow shortcut if more than one screen present
            if (e.HotKeys == AppConfigs.Configuration.ToggleMode && immersiveModeAllowed)
            {
                tray.ToggleMode();
                toggleImmersiveMode();
                return;
            }

        }

        private void configureOverlays()
        {
            // remove exiting overlays
            clearOverlays();                

            // add screens if they don't already exist
            if (overlays.Count != Screen.AllScreens.Length)
            {
                // apply dimness onto all screens
                foreach (var screen in Screen.AllScreens)
                {
                    frmMain overlay = new frmMain();
                    overlay.Dimness = this.dimness / 100;
                    overlay.primaryMonitor = screen.Primary;
                    overlay.Area = screen.Bounds;
                    overlay.Show();

                    // add to list of overlays
                    overlays.Add(overlay);
                }
            }
            updateOverlays();
        }

        private void clearOverlays()
        {
            foreach (var overlay in overlays)
                overlay.Dispose();

            overlays.Clear();
        }

        public bool SetHotKeyCombination(HotKeys hotkeys, String function)
        {
            HotKeys current = null;
            switch (function)
            {
                case "Increase":
                    current = AppConfigs.Configuration.IncreaseDimness;
                    break;
                case "Decrease":
                    current = AppConfigs.Configuration.DecreaseDimness;
                    break;
                case "Mode":
                    current = AppConfigs.Configuration.ToggleMode;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(function);
            }

            keyHook.UnRegisterHotKey(current);
            if (!keyHook.RegisterHotKey(hotkeys))
            {
                new Exception("Can't register HotKey: " + hotkeys);
                return false;
            }

            switch (function)
            {
                case "Increase":
                    AppConfigs.Configuration.IncreaseDimness = hotkeys;
                    break;
                case "Decrease":
                    AppConfigs.Configuration.DecreaseDimness = hotkeys;
                    break;
                case "Mode":
                    AppConfigs.Configuration.ToggleMode = hotkeys;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(function);
            }

            AppConfigs.Configuration.Save();
            return true;      

        }

        public void exit()
        {            
            // remove all overlays
            clearOverlays();
            //Remove Hotkey Hooks
            keyHook.Dispose();
            //Clean up any used memeory.
            GC.Collect();
            //Close the Application.            
            Application.Exit();
        }

        public void immersiveModeAllowedSet(Boolean state)
        {
            immersiveModeAllowed = state;
            if (!state)
            {
                immersiveMode = false;
                updateOverlays();
            }
        }

        public float getDimness()
        {
            return dimness;
        }

        public Boolean getImmersiveMode()
        {
            return immersiveMode;
        }

        public Boolean ImmersiveModeAllowedSet()
        {
            return immersiveModeAllowed;
        }

        
        public static void RemoveApplicationFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.DeleteValue("DimThing", false);
            }
        }

        public static void AddApplicationToStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                key.SetValue("DimThing", Application.ExecutablePath);
            }
        }
    }
}
