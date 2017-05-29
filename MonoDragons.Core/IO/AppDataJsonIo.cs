using System;
using System.IO;
using Newtonsoft.Json;

namespace MonoDragons.Core.IO
{
    public sealed class AppDataJsonIo
    {
        private readonly string _gameStorageFolder;

        public AppDataJsonIo(string gaemFolderName)
        {
            _gameStorageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), gaemFolderName);
        }

        public T Load<T>(string saveName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(GetSavePath(saveName)));
        }

        public void Save(string saveName, object data)
        {
            if (!Directory.Exists(_gameStorageFolder))
                Directory.CreateDirectory(_gameStorageFolder);
            File.WriteAllText(GetSavePath(saveName), JsonConvert.SerializeObject(data));
        }

        private string GetSavePath(string saveName)
        {
            return Path.Combine(_gameStorageFolder, saveName) + ".sav";
        }
    }
}
