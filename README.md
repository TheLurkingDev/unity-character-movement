# Character Movement and Object Persistence

## Character Movement
The `PlayerMovementBase` class sets up shared base functionality for movement, animation, and audio related to movement, such as the sound of footsteps. 

### Inheriting From `PlayerMovementBase`
`PlayerMovementBase` is an abstract class that must be inherited. The parent class must call to the `BaseStart()` method during its own `Start()`.

In the `Update()` method of the parent class, if keyboard movement is detected, the parent class should ultimately utilize the `_transform.position` object found withn the base class to perform movement. Additionally, if movement is turn-based, calls to the base class methods `PlayWalkAnimationOnce()` and `PlayFootstepAudioClipOnce` should be called to play animation and associated audio respectively. Conversely, if movement is real-time, the methods `PlayWalkAnimation()` and `PlayFootstepAudioClipLooped` should be used.

## Object Persistence
The `ObjectPersistenceService` class provides functionality for persisting data to either a json file or a binary file. To create a file that is not readable by a user, and therefore not editable, choose to persist to a binary file. Conversely, choose a json file if you want to allow the user to make changes to mod the game.

### Setting Up Persistence In An Existing Project
* Create a class within the `Persistence` namespace to contain all of the data to be persisted for an object

``` c#
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

Here is a simple example that saves and loads the position of a `Player`:

``` c#
namespace TheLurkingDev.Player
{
    public class Player : MonoBehaviour
    {
        private Transform _transform;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                PlayerPersistence persistence = new PlayerPersistence(_transform.position);
                //ObjectPersistenceService.SaveObjectToJsonFile(persistence, "Player");
                ObjectPersistenceService.SaveObjectToBinaryFile(persistence, "Player");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                //PlayerPersistence playerPersistence = ObjectPersistenceService.LoadObjectFromJsonFile<PlayerPersistence>("Player");
                PlayerPersistence playerPersistence = ObjectPersistenceService.LoadObjectFromBinaryFile<PlayerPersistence>("Player");
                _transform.position = playerPersistence.PlayerPosition;
            }
        }
    }
}
```


