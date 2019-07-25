﻿using UnityEngine;

namespace MovementVector2D
{
    public class PlayerMovement : CharacterMovement
    {
        [SerializeField]
        private AnimationClip _idleUp;

        [SerializeField]
        private AnimationClip _idleRight;

        [SerializeField]
        private AnimationClip _idleDown;

        [SerializeField]
        private AnimationClip _idleLeft;

        [SerializeField]
        private AnimationClip _walkUp;

        [SerializeField]
        private AnimationClip _walkRight;

        [SerializeField]
        private AnimationClip _walkDown;

        [SerializeField]
        private AnimationClip _walkLeft;

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
