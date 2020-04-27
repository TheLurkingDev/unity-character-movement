using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class TurnBasedPlayerMovement : PlayerMovementBase
    {
        private bool _isMoving;
        private Vector2 _currentPosition;
        private Vector2 _targetPosition;

        private void Start()
        {
            BaseStart();
        }

        private void Update()
        {
            if(_isMoving)
            {
                _currentPosition = Move(_currentPosition);
                CheckForMoveStop();
            }
            else
            {
                CheckForNewMove();
            }
        }

        private void CheckForNewMove()
        {
            var movementVector = GetMovementDirectionFromKeyboardInput(Input.GetKeyDown);
            if (movementVector != Vector2.zero)
            {
                StartMoving(movementVector);                
            }           
        }

        private void StartMoving(Vector2 movementVector)
        {
            Debug.Log("Start Moving!");
            _isMoving = true;
            _targetPosition = new Vector2(_transform.position.x, _transform.position.y) + movementVector;

            PlayWalkAnimationOnce(movementVector);
            PlayFootstepAudioClipOnce();
        }

        private void StopMoving()
        {
            Debug.Log("Stop Moving!");
            _isMoving = false;
            base.PlayIdleAnimation();
        }

        private void CheckForMoveStop()
        {
            if (_transform.position == new Vector3(_targetPosition.x, _targetPosition.y))
            {
                StopMoving();
            }
        }

        protected override Vector2 Move(Vector2 movementVector)
        {   
            _transform.position = Vector2.Lerp(_transform.position, _targetPosition, _speed);            

            return _transform.position;
        }
    }
}
