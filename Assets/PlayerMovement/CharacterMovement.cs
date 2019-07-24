using UnityEngine;

namespace Movement2D
{
    public class CharacterMovement : MonoBehaviour
    {
        private Transform _transform;
        private float _speed = 50f;

        private void Start()
        {
            _transform = this.gameObject.transform;
        }
        protected virtual Vector2 Move(Vector2 movementVector)
        {
            _transform.position += new Vector3(movementVector.x, movementVector.y, _transform.position.z) * _speed * Time.deltaTime;
            return _transform.position;
        }        
    }
}
