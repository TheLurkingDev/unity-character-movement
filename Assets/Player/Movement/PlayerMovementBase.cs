using System;
using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    public abstract class PlayerMovementBase : MonoBehaviour
    {
        protected Transform _transform;
        protected float _speed = 5f;
        private Animator _animator;
        private Vector2 _lastMovementDirection;
        private PlayerAnimation _playerAnimation;
        [SerializeField] private PlayerAnimationScriptableObject _playerAnimationClips;

        private AudioSource _audioSource;        
        private float _footStepSoundAudioScale = 1f;
        [SerializeField] private AudioClip _footStepSoundClip;

        protected void BaseStart()
        {
            if(_playerAnimationClips == null)
            {
                throw new Exception("Player Animation Clips not assigned to player");
            }

            if(_footStepSoundClip == null)
            {
                throw new Exception("Footstep Soundclip not assigned to player.");
            }

            _transform = this.gameObject.transform;
            _animator = GetComponent<Animator>();
            _lastMovementDirection = Vector2.down;
            _playerAnimation = new PlayerAnimation(_animator, _playerAnimationClips);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _footStepSoundClip;            
        }

        protected abstract Vector2 Move(Vector2 movementVector);

        protected Vector2 GetMovementDirectionFromKeyboardInput(Func<KeyCode, bool> getKeyFunc)
        {
            float moveX = 0f;
            float moveY = 0f;

            if(getKeyFunc(KeyCode.W) || getKeyFunc(KeyCode.UpArrow))
            {
                moveY = +1f;
            }
            if (getKeyFunc(KeyCode.S) || getKeyFunc(KeyCode.DownArrow))
            {
                moveY = -1f;
            }
            if (getKeyFunc(KeyCode.A) || getKeyFunc(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            if (getKeyFunc(KeyCode.D) || getKeyFunc(KeyCode.RightArrow))
            {
                moveX = +1f;
            }

            return new Vector2(moveX, moveY).normalized;
        }

        protected void PlayFootstepAudioClipOnce()
        {
            _audioSource.PlayOneShot(_footStepSoundClip, _footStepSoundAudioScale);
        }

        protected void PlayFootstepAudioClipLooped()
        {
            _audioSource.Play();
        }

        protected void StopPlayingFootStepAudioClip()
        {
            _audioSource.Stop();
        }

        protected bool FootstepAudioClipIsPlaying()
        {
            return _audioSource.isPlaying;
        }

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
