using System;
using System.IO;
using Newtonsoft.Json;

namespace TeacherService.Utils
{
    public class FileStorage
    {
        private readonly string _filePath;
        private readonly JsonSerializerSettings _settings;

        public FileStorage(string fileName)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _filePath = Path.Combine(directory, fileName);

            _settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
        }

        // ========== UMUMIY SAVE ==========
        public void Save<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data, _settings);
            File.WriteAllText(_filePath, json);
        }

        // ========== UMUMIY LOAD ==========
        public T Load<T>()
        {
            if (!File.Exists(_filePath))
                return default;

            var json = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        // ========== TEXT SAVE (MATN SAQLASH) ==========
        public void SaveText(string text)
        {
            File.WriteAllText(_filePath, text);
        }

        // ========== TEXT LOAD (MATN O'QISH) ==========
        public string LoadText()
        {
            if (!File.Exists(_filePath))
                return null;

            return File.ReadAllText(_filePath);
        }

        // ========== FAYL MAVJUDLIGINI TEKSHIRISH ==========
        public bool Exists()
        {
            return File.Exists(_filePath);
        }

        // ========== FAYLNI O'CHIRISH ==========
        public void Delete()
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);
        }

        // ========== FAYL HAQIDA MA'LUMOT ==========
        public FileInfo GetFileInfo()
        {
            return new FileInfo(_filePath);
        }
    }
}