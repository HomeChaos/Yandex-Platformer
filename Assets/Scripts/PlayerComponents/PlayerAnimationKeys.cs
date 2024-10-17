using UnityEngine;

namespace PlayerComponents
{
    public static class PlayerAnimationKeys
    {
        public static readonly int Death = Animator.StringToHash("death");
        public static readonly int Exit = Animator.StringToHash("exit");
        public static readonly int Reset = Animator.StringToHash("reset");
        public static readonly int IsWalk = Animator.StringToHash("is-walk");
        public static readonly int Vertical = Animator.StringToHash("vertical");
        public static readonly int IsGround = Animator.StringToHash("is=ground");
    }
}