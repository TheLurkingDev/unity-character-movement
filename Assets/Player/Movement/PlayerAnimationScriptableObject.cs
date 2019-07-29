using UnityEngine;

namespace MovementVector2D
{
    [CreateAssetMenu]
    public class PlayerAnimationScriptableObject : ScriptableObject
    {
        [SerializeField] private AnimationClip _idleUp;
        [SerializeField] private AnimationClip _idleRight;
        [SerializeField] private AnimationClip _idleDown;
        [SerializeField] private AnimationClip _idleLeft;

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
    }
}
