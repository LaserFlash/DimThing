using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DimThing.Framework.Configuration
{
    public interface IConfiguration
    {
        /// <summary>
        ///     Where is the configuration saved
        ///     Any change to this will be discarded at the next loading of the configuration
        /// </summary>
        string FileLocation { get; set; }

        void Save();
    }

    public static class ConfigurationManager
    {
        private static readonly string SRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);

        static ConfigurationManager()
        {
            if (Directory.Exists(SRoot))
                return;

            Directory.CreateDirectory(SRoot);
        }

        /// <summary>
        ///     Load a ConfigurationManager from its file
        /// </summary>
        /// <returns>The loaded configuration if the file exists, else a new instance of the configuration</returns>
        public static T LoadConfiguration<T>() where T : IConfiguration, new()
        {
            var filePath = GetFilePath<T>();
            T obj;
            if (!File.Exists(filePath))
            {
                obj = new T();
            }
            else
            {
                var contents = File.ReadAllText(filePath);
                obj = JsonConvert.DeserializeObject<T>(contents);
                if (obj == null)
                {
                    Trace.WriteLine("Problem with Deserializer");
                    Trace.WriteLine("Contents: " + contents);
                    obj = new T();
                }
            }
            obj.FileLocation = filePath;
            return obj;
        }

        private static string GetFilePath<T>() where T : IConfiguration, new()
        {
            var filePath = Path.Combine(SRoot, typeof(T).Name + ".json");
            return filePath;
        }

        /// <summary>
        ///     Save the configuration in a json file.
        /// </summary>
        /// <param name="configuration">configuration object to save</param>
        public static void SaveConfiguration<T>(T configuration) where T : IConfiguration, new()
        {
            configuration.FileLocation = null;
            if (!Directory.Exists(SRoot))
            {
                Directory.CreateDirectory(SRoot);
            }                   
            var serializer = new JsonSerializer { NullValueHandling = NullValueHandling.Ignore };
            using (var writer = new JsonTextWriter(new StreamWriter(GetFilePath<T>())))
            {
                serializer.Serialize(writer, configuration);
            }
        }
    }
}
