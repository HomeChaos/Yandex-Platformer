using Cinemachine;
using UnityEngine;

namespace LevelSystem.ResetComponents
{
    [AddComponentMenu("Reset/PlayerReset")]
    public class PlayerReset : Resettable
    {
        [SerializeField] private Transform _startPoint;

        public override void ApplyReset()
        {
            Event?.Invoke();
            transform.position = _startPoint.position;
        }
    }
}