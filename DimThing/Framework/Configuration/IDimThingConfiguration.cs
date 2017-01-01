using System;
using System.Collections.Generic;

namespace DimThing.Framework.Configuration
{
    public interface IDimThingConfiguration : IConfiguration
    {
        float Dimness { get; set; }
        HotKeys IncreaseDimness { get; set; }
        HotKeys DecreaseDimness { get; set; }
        HotKeys ToggleMode { get; set; }
        Boolean MonitorMode { get; set; }
    }
}
