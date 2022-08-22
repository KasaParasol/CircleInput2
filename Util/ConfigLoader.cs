using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CircleInput2
{
    class ConfigLoader
    {
        static string CONFIG_FILE_NAME = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\configure.json";

        public static bool IsExists()
        {
            return !!File.Exists(CONFIG_FILE_NAME);
        }

        public static Dictionary<string, Config> LoadConfig()
        {
            if (!File.Exists(CONFIG_FILE_NAME))
            {
                try
                {
                    using (FileStream fs = File.Create(CONFIG_FILE_NAME))
                    {
                        var configList = new Dictionary<string, Config>()
                        {
                            { "*", DefaultConfig.defaultConfig }
                        };
                        string jsonString = JsonSerializer.Serialize(configList);
                        byte[] info = new UTF8Encoding(true).GetBytes(jsonString);
                        fs.Write(info, 0, info.Length);
                        return configList;
                    }
                }
                catch
                {
                    throw;
                }
            }
            else
            {
                using (StreamReader fs = new StreamReader(CONFIG_FILE_NAME))
                {
                    string jsonString = fs.ReadToEnd();
                    Dictionary<string, Config> config = JsonSerializer.Deserialize<Dictionary<string, Config>>(jsonString);
                    return config;
                }
            }
        }
    }
}
