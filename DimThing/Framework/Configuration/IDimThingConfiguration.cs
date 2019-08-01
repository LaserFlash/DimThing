using System;

namespace DimThing.Framework.Configuration
{
    public interface IDimThingConfiguration : IConfiguration
    {
        float Dimness { get; set; }
        HotKeys IncreaseDimness { get; set; }
        HotKeys DecreaseDimness { get; set; }
        HotKeys ToggleMode { get; set; }
        Boolean ImmersiveMode { get; set; }
        Boolean ImmersiveModeAllowed { get; set; }
        Boolean FirstRun { get; set; }
        Boolean RunAtStart { get; set; }
        Boolean LoadAtStart { get; set; }
    }
}
