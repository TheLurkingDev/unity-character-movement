# Character Movement and Object Persistence

## Character Movement


## Object Persistence
The `ObjectPersistenceService` class provides functionality for persisting data to either a json file or a binary file. To create a file that is not readable by a user, and therefore not editable, choose to persist to a binary file. Conversely, choose a json file if you want to allow the user to make changes to mod the game.

### Setting Up Persistence In An Existing Project
* Create a class within the `Persistence` namespace to contain all of the data to be persisted for an object

```
using UnityEngine;

namespace TheLurkingDev.Persistence
{
    public class PlayerPersistence
    {
        public Vector3 PlayerPosition { get; set; }

        public PlayerPersistence(Vector3 currentPosition)
        {
            this.PlayerPosition = currentPosition;
        }
    }
}

```

* Create an instance of the new class and populate its properties
* Utilize the static method `ObjectPersistenceService.SaveObjectToBinaryFile` and pass the object to be saved into it along with a string name that will be used to later retrieve the object's data
* Utilize the static method `ObjectPersistenceService.LoadObjectFromBinaryFile` to retrieve the object by the name specified during saving

