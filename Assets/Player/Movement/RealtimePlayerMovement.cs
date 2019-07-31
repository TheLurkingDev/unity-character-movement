using UnityEngine;

namespace MovementVector2D
{
    public class RealtimePlayerMovement : PlayerMovementBase
    {
        private void Start()
        {
            base.BaseStart();
        }

        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput();
            if (movementVector != Vector2.zero)
            {
                Move(movementVector);
                base.PlayWalkAnimation(movementVector);
            }
            else
            {
                base.PlayIdleAnimation();
            }
        }

        protected override Vector2 Move(Vector2 movementVector)
        {
            base._transform.position += new Vector3(movementVector.x, movementVector.y, base._transform.position.z) * base._speed * Time.deltaTime;
            return _transform.position;
        }

        protected override Vector2 GetMovementDirectionFromKeyboardInput()
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                moveY = +1f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                moveX = +1f;
            }

            return new Vector2(moveX, moveY).normalized;
        }
    }
}
