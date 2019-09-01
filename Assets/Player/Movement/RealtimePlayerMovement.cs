using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class RealtimePlayerMovement : PlayerMovementBase
    {
        private void Start()
        {
            BaseStart();
        }

        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput();
            if (movementVector != Vector2.zero)
            {
                Move(movementVector);
                PlayWalkAnimation(movementVector);
                if(!FootstepAudioClipIsPlaying())
                {
                    PlayFootstepAudioClipLooped();
                }
            }
            else
            {
                PlayIdleAnimation();
                if(FootstepAudioClipIsPlaying())
                {
                    StopPlayingFootStepAudioClip();
                }
            }
        }

        protected override Vector2 Move(Vector2 movementVector)
        {
            _transform.position += new Vector3(movementVector.x, movementVector.y, _transform.position.z) * _speed * Time.deltaTime;
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
