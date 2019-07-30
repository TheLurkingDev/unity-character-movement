using UnityEngine;

namespace MovementVector2D
{
    public class CharacterMovement : MonoBehaviour
    {
        private Transform _transform;
        private float _speed = 5f;

        protected void BaseStart()
        {
            _transform = this.gameObject.transform;
        }
        protected virtual Vector2 MoveRealTime(Vector2 movementVector)
        {
            _transform.position += new Vector3(movementVector.x, movementVector.y, _transform.position.z) * _speed * Time.deltaTime;
            return _transform.position;
        }
        
        protected virtual Vector2 MoveTurnBased(Vector2 movementVector)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                _transform.Translate(Vector3.up);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                _transform.Translate(Vector3.down);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                _transform.Translate(Vector3.left);
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                _transform.Translate(Vector3.right);
            }
                        
            return _transform.position;
        }
    }
}
