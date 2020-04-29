using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class TurnBasedPlayerMovement : PlayerMovementBase
    {
        private bool _isMoving;
        private Vector2 _currentPosition;
        private Vector2 _targetPosition;
        const float _stopWithinDistance = 0.05f;

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
            var targetVector3 = new Vector3(_targetPosition.x, _targetPosition.y);
            
            if (Vector3.Distance(_transform.position, targetVector3) < _stopWithinDistance)
            {
                _transform.position = targetVector3;
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
