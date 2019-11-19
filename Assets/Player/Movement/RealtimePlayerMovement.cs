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
            var movementVector = GetMovementDirectionFromKeyboardInput(Input.GetKey);
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
    }
}
