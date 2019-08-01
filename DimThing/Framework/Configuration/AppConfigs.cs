
namespace DimThing.Framework.Configuration
{
    public static class AppConfigs
    {
        public static IDimThingConfiguration Configuration { get; private set; } = ConfigurationManager.LoadConfiguration<DimThingConfiguration>();
    }
}
