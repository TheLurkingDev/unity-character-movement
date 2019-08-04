using Persistence;
using UnityEngine;

namespace Player
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
                PlayerPersistence playerPersistence = ObjectPersistenceService.LoadObjectFromJsonFile<PlayerPersistence>("Player");
                _transform.position = playerPersistence.PlayerPosition;
            }
        }
    }
}
