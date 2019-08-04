using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Persistence
{
    public class ObjectPersistenceService
    {
        public static void Save<T>(T objectToSave, string objectName)
        {
            File.WriteAllText(Application.dataPath + "/" + objectName + ".json", JsonConvert.SerializeObject
                (objectToSave, 
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
        }

        public static T Load<T>(string objectName)
        {
            var fileString = File.ReadAllText(Application.dataPath + "/" + objectName + ".json");            
            var loadedObject = JsonConvert.DeserializeObject<T>(fileString);
            return loadedObject;            
        }
    }
}
