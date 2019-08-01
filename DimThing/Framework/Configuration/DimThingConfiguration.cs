using System;
using System.Windows.Forms;

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
            ImmersiveMode = false;
            ImmersiveModeAllowed = false;
            FirstRun = true;
            RunAtStart = true;
            LoadAtStart = true;
        }

        public float Dimness { get; set; }
        public HotKeys IncreaseDimness { get; set; }
        public HotKeys DecreaseDimness { get; set; }
        public HotKeys ToggleMode { get; set; }
        public Boolean ImmersiveMode { get; set; }
        public Boolean ImmersiveModeAllowed { get; set; }
        public Boolean FirstRun { get; set; }
        public Boolean RunAtStart { get; set; }
        public Boolean LoadAtStart { get; set; }

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
