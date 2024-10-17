using Components;
using UnityEngine;

namespace LevelSystem.ResetComponents
{
    [AddComponentMenu("Reset/SpriteAnimationReset")]
    public class SpriteAnimationReset : Resettable
    {
        [SerializeField] private SpriteAnimation _animation;
        [SerializeField] private string _animationState;
        
        public override void ApplyReset()
        {
            Event?.Invoke();
            _animation.gameObject.SetActive(true);
            _animation.SetClip(_animationState);
        }
    }
}