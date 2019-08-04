using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Persistence
{
    public class ObjectPersistenceService
    {
        public static void SaveObjectToJsonFile<T>(T objectToSave, string objectName)
        {
            File.WriteAllText(Application.dataPath + "/" + objectName + ".json", JsonConvert.SerializeObject
                (objectToSave, 
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }

        public static T LoadObjectFromJsonFile<T>(string objectName)
        {
            var fileString = File.ReadAllText(Application.dataPath + "/" + objectName + ".json");            
            var loadedObject = JsonConvert.DeserializeObject<T>(fileString);
            return loadedObject;            
        }

        public static void SaveObjectToBinaryFile<T>(T objectToSave, string objectName)
        {
            var filePath = Application.dataPath + "/";

            var jsonString = JsonConvert.SerializeObject(objectToSave,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            var jsonBytes = Encoding.ASCII.GetBytes(jsonString);
            var jsonBase64 = Convert.ToBase64String(jsonBytes);

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath + objectName + ".dat", FileMode.OpenOrCreate)))
            {
                writer.Write(jsonBase64);
            }            
        }
    }
}
