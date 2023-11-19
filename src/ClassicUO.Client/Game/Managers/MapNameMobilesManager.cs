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
            // Alterei o método AddTile para corrigir a adição ao dicionário.
            nameMobiles[serial] = name;
            Save(); // Adicionado para salvar imediatamente após a adição.
        }

        public bool IsNameMobile(int serial)
        {
            // Alterei o método IsTileMarked para verificar se o serial existe no dicionário.
            return nameMobiles.ContainsKey(serial);
        }

        public string GetTileName(int serial)
        {
            // Alterei o método para retornar o nome associado ao serial, se existir.
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
                Console.WriteLine($"Failed to save marked tile data. {ex.Message}");
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
                    Console.WriteLine($"Failed to load marked tile data. {ex.Message}");
                }
            }
        }
    }
}