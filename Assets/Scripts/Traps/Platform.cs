using DG.Tweening;
using LevelSystem;
using UnityEngine;

namespace Traps
{
    public class Platform : Resettable
    {
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private LoopType _loopType;

        private Sequence _sequence;

        private void Start()
        {
            ApplyReset();
        }
        
        public override void ApplyReset()
        {
            if (_sequence != null)
            {
                _sequence.Kill();
            }

            ResetPosition();
            DoPatrol();
        }

        private void ResetPosition()
        {
            _target.transform.position = _right.position;
        }

        private void DoPatrol()
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(_target.transform
                .DOMove(_left.position, _speed)
                .SetEase(Ease.Linear));
            _sequence.Append(_target.transform
                .DOMove(_right.position, _speed)
                .SetEase(Ease.Linear));

            _sequence.SetLoops(-1, _loopType).SetEase(Ease.Linear);
        }
    }
}