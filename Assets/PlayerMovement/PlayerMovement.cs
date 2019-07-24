using UnityEngine;

namespace Movement2D
{
    public class PlayerMovement : CharacterMovement
    {
        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput();
            if(movementVector != Vector2.zero)
            {
                base.Move(movementVector);
            }
        }

        private Vector2 GetMovementDirectionFromKeyboardInput()
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                moveY = +1f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveX = +1f;
            }

            return new Vector2(moveX, moveY).normalized;
        }
    }
}
