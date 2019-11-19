using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class TurnBasedPlayerMovement : PlayerMovementBase
    {
        

        private void Start()
        {
            BaseStart();
        }

        private void Update()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput(Input.GetKeyDown);
            if (movementVector != Vector2.zero)
            {
                Move(movementVector);
                PlayWalkAnimationOnce(movementVector);
                PlayFootstepAudioClipOnce();
            }
            else
            {
                base.PlayIdleAnimation();
            }
        }

        protected override Vector2 Move(Vector2 movementVector)
        {
            _transform.Translate(movementVector);            

            return _transform.position;
        }
    }
}
