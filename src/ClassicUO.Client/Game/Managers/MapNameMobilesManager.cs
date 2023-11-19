using ClassicUO.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassicUO.Game.Managers
{
    internal class MapNameMobilesManager
    {
        public static MapNameMobilesManager Instance { get; private set; } = new MapNameMobilesManager();

        private Dictionary<int, string> nameMobiles = new Dictionary<int, string>();

        private MapNameMobilesManager() { Load(); }

        private string savePath = Path.Combine(CUOEnviroment.ExecutablePath, "Data", "Profiles", "MapNameMobile.bin");

        public void AddNameMobile(int serial, string name)
        {
            nameMobiles[serial] = name;
            Save(); 
        }

        public bool IsNameMobile(int serial)
        {
            return nameMobiles.ContainsKey(serial);
        }

        public string GetTileName(int serial)
        {
            if (nameMobiles.TryGetValue(serial, out string name))
            {
                return name;
            }
            return null;
        }

        public void Save()
        {
            try
            {
                using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, nameMobiles);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save NameMobiles data. {ex.Message}");
            }
        }

        private void Load()
        {
            if (File.Exists(savePath))
            {
                try
                {
                    using (FileStream fs = File.OpenRead(savePath))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        nameMobiles = (Dictionary<int, string>)bf.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load NameMobiles data. {ex.Message}");
                }
            }
        }
    }
}