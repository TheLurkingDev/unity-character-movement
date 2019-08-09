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
            _transform = this.gameObject.transform;
            _animator = GetComponent<Animator>();
            _lastMovementDirection = Vector2.down;
            _playerAnimation = new PlayerAnimation(_animator, _playerAnimationClips);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.clip = _footStepSoundClip;            
        }

        protected abstract Vector2 Move(Vector2 movementVector);

        protected abstract Vector2 GetMovementDirectionFromKeyboardInput();

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
