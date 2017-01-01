using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DimThing.Framework.Configuration
{
    class DimThingConfiguration : IDimThingConfiguration
    {
        public DimThingConfiguration()
        {           
            Dimness = 0;
            IncreaseDimness = new HotKeys(Keys.Oemplus, HotKeys.ModifierKeys.Alt);
            DecreaseDimness = new HotKeys(Keys.OemMinus, HotKeys.ModifierKeys.Alt);
            ToggleMode = new HotKeys(Keys.OemPipe, HotKeys.ModifierKeys.Alt);
            MonitorMode = false;
        }

        public float Dimness { get; set; }
        public HotKeys IncreaseDimness { get; set; }
        public HotKeys DecreaseDimness { get; set; }
        public HotKeys ToggleMode { get; set; }
        public Boolean MonitorMode { get; set; }

        //Needed by Interface
        public string FileLocation { get; set; }

        public void Save()
        {            
            {                
                ConfigurationManager.SaveConfiguration(this);
            }
        }

    }
}
