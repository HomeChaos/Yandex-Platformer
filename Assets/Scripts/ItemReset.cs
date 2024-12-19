using UnityEngine;

namespace LevelSystem.ResetComponents
{
    [AddComponentMenu("Reset/ItemReset")]
    public class ItemReset : Resettable
    {
        [SerializeField] private Transform _startPoint;

        public override void ApplyReset()
        {
            Event?.Invoke();
            transform.position = _startPoint.position;
        }
    }
}