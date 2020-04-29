using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class PlayerAnimation
    {
        private Animator _animator;
        private PlayerAnimationScriptableObject _playerAnimations;        

        public PlayerAnimation(Animator animator, PlayerAnimationScriptableObject playerAnimations, float playbackSpeed)
        {
            _animator = animator;
            _animator.speed = playbackSpeed;
            _playerAnimations = playerAnimations;            
        }

        public void PlayAnimation(AnimationType animationType, Vector2 animationDirection)
        {
            if(animationType == AnimationType.Idle)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.IdleUp);
                }
                else if (animationDirection == Vector2.right)
                {
                    _animator.Play(_playerAnimations.IdleRight);
                }
                else if (animationDirection == Vector2.down)
                {
                    _animator.Play(_playerAnimations.IdleDown);
                }
                else if (animationDirection == Vector2.left)
                {
                    _animator.Play(_playerAnimations.IdleLeft);
                }
            }
            else if(animationType == AnimationType.Walk)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.WalkUp);
                }
                else if (animationDirection == Vector2.right)
                {
                    _animator.Play(_playerAnimations.WalkRight);
                }
                else if (animationDirection == Vector2.down)
                {
                    _animator.Play(_playerAnimations.WalkDown);
                }
                else if (animationDirection == Vector2.left)
                {
                    _animator.Play(_playerAnimations.WalkLeft);
                }
            }
        }

        public void PlayAnimationOnce(AnimationType animationType, Vector2 animationDirection)
        {
            const int IdleAnimationLayer = 0;
            const int WalkAnimationLayer = -1;

            if (animationType == AnimationType.Idle)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.IdleUp, IdleAnimationLayer);
                }
                else if (animationDirection == Vector2.right)
                {
                    _animator.Play(_playerAnimations.IdleRight, IdleAnimationLayer);
                }
                else if (animationDirection == Vector2.down)
                {
                    _animator.Play(_playerAnimations.IdleDown, IdleAnimationLayer);
                }
                else if (animationDirection == Vector2.left)
                {
                    _animator.Play(_playerAnimations.IdleLeft, IdleAnimationLayer);
                }
            }
            else if (animationType == AnimationType.Walk)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.WalkUp, WalkAnimationLayer);
                }
                else if (animationDirection == Vector2.right)
                {
                    _animator.Play(_playerAnimations.WalkRight, WalkAnimationLayer);
                    
                }
                else if (animationDirection == Vector2.down)
                {
                    _animator.Play(_playerAnimations.WalkDown, WalkAnimationLayer);
                }
                else if (animationDirection == Vector2.left)
                {
                    _animator.Play(_playerAnimations.WalkLeft, WalkAnimationLayer);
                }
            }
        }
    }
}
