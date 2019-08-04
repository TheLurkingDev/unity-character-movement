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
                ObjectPersistenceService.Save(persistence, "Player");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {                
                PlayerPersistence playerPersistence = ObjectPersistenceService.Load<PlayerPersistence>("Player");
                _transform.position = playerPersistence.PlayerPosition;
            }
        }
    }
}
