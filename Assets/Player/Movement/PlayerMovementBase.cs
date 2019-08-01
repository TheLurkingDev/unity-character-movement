using UnityEngine;

namespace MovementVector2D
{
    public abstract class PlayerMovementBase : MonoBehaviour
    {
        protected Transform _transform;
        protected float _speed = 5f;
        private Animator _animator;
        private Vector2 _lastMovementDirection;
        private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerAnimationScriptableObject _playerAnimationClips;

        protected void BaseStart()
        {
            _transform = this.gameObject.transform;
            _animator = GetComponent<Animator>();
            _lastMovementDirection = Vector2.down;
            _playerAnimation = new PlayerAnimation(_animator, _playerAnimationClips);
        }

        protected abstract Vector2 Move(Vector2 movementVector);

        protected abstract Vector2 GetMovementDirectionFromKeyboardInput();

        protected void PlayWalkAnimation(Vector2 movementVector)
        {
            _playerAnimation.PlayAnimation(AnimationType.Walk, movementVector);
            _lastMovementDirection = movementVector;
        }

        protected void PlayWalkAnimationOnce(Vector2 movementVector)
        {
            _playerAnimation.PlayAnimationOnce(AnimationType.Walk, movementVector);
            _lastMovementDirection = movementVector;
        }

        protected void PlayIdleAnimation()
        {
            _playerAnimation.PlayAnimation(AnimationType.Idle, _lastMovementDirection);
        }
    }
}
