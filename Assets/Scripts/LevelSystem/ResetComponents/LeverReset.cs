using Components;
using UnityEngine;

namespace LevelSystem.ResetComponents
{
    [AddComponentMenu("Reset/LeverReset")]
    public class LeverReset : Resettable
    {
        [SerializeField] private Lever _lever;
        
        public override void ApplyReset()
        {
            _lever.ResetLever();
        }
    }
}