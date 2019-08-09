using UnityEngine;

namespace TheLurkingDev.Player.Movement2D
{
    [CreateAssetMenu]
    public class PlayerAnimationScriptableObject : ScriptableObject
    {
        [SerializeField] private AnimationClip _idleUp;
        [SerializeField] private AnimationClip _idleRight;
        [SerializeField] private AnimationClip _idleDown;
        [SerializeField] private AnimationClip _idleLeft;

        [SerializeField] private AnimationClip _walkUp;
        [SerializeField] private AnimationClip _walkRight;
        [SerializeField] private AnimationClip _walkDown;
        [SerializeField] private AnimationClip _walkLeft;

        public string IdleUp
        {
            get { return _idleUp.name; }
        }

        public string IdleRight
        {
            get { return _idleRight.name; }
        }

        public string IdleDown
        {
            get { return _idleDown.name; }
        }

        public string IdleLeft
        {
            get { return _idleLeft.name; }
        }

        public string WalkUp
        {
            get { return _walkUp.name; }
        }

        public string WalkRight
        {
            get { return _walkRight.name; }
        }

        public string WalkDown
        {
            get { return _walkDown.name; }
        }

        public string WalkLeft
        {
            get { return _walkLeft.name; }
        }
    }
}
