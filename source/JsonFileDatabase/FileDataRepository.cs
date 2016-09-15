using Newtonsoft.Json;
using System.IO;

namespace Magrathea.Data
{
    /// <summary>
    /// Generic File Data Repository
    /// </summary>
    public class FileDataRepository
    {
        private string _filename;

        /// <summary>
        /// Create a new instance of the FileDataRepository
        /// </summary>
        /// <param name="fileName"></param>
        public FileDataRepository(string fileName)
        {
            _filename = fileName;
        }

        /// <summary>
        /// Read all data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Read<T>() where T : new()
        {
            if (File.Exists(_filename))
            {
                using (var file = File.OpenText(_filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return (T)serializer.Deserialize(file, typeof(T));
                }
            }

            return new T();
        }

        /// <summary>
        /// Save all data
        /// </summary>
        /// <typeparam name="T">Type of object to save</typeparam>
        /// <param name="data">instance of object of type T that contains data to be written to disk</param>
        public void Save<T>(T data)
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            string contents = JsonConvert.SerializeObject(data, (Formatting)1);
            File.WriteAllText(_filename, contents);

            //using (var file = File.CreateText(_filename))
            //{
            //    var serializer = new JsonSerializer();
            //    serializer.Serialize(file, data);
            //}
        }

        public void Delete()
        {
            File.Delete(_filename);
        }
    }
}
