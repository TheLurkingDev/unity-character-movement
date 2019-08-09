using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public class PlayerAnimation
    {
        private Animator _animator;
        private PlayerAnimationScriptableObject _playerAnimations;

        public PlayerAnimation(Animator animator, PlayerAnimationScriptableObject playerAnimations)
        {
            _animator = animator;
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
            if (animationType == AnimationType.Idle)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.IdleUp, 0, 1f);
                }
                else if (animationDirection == Vector2.right)
                {
                    _animator.Play(_playerAnimations.IdleRight, 0, 1f);
                }
                else if (animationDirection == Vector2.down)
                {
                    _animator.Play(_playerAnimations.IdleDown, 0, 1f);
                }
                else if (animationDirection == Vector2.left)
                {
                    _animator.Play(_playerAnimations.IdleLeft, 0, 1f);
                }
            }
            else if (animationType == AnimationType.Walk)
            {
                if (animationDirection == Vector2.up)
                {
                    _animator.Play(_playerAnimations.WalkUp, -1, 1000f);
                    
                    
                }
                else if (animationDirection == Vector2.right)
                {
                    //_animator.Play(_playerAnimations.WalkRight, -1, 1000f);
                    
                }
                else if (animationDirection == Vector2.down)
                {
                    //_animator.Play(_playerAnimations.WalkDown, -1, 1000f);
                    _animator.SetBool("walk", true);
                }
                else if (animationDirection == Vector2.left)
                {
                    //_animator.Play(_playerAnimations.WalkLeft, -1, 1000f);
                    
                }
            }
        }
    }
}
