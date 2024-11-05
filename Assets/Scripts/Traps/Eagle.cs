using DG.Tweening;
using LevelSystem;
using UnityEngine;

namespace Traps
{
    public class Eagle : Resettable
    {
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _right;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float _scale = 1;
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
            UpdateLookForward(true);
            _target.transform.DOMove(_right.position, 0);
        }

        private void DoPatrol()
        {
            _sequence = DOTween.Sequence();

            _sequence.Append(_target.transform
                .DOMove(_left.position, _speed)
                .OnComplete(() => UpdateLookForward(false))
                .SetEase(Ease.Linear));
            _sequence.Append(_target.transform
                .DOMove(_right.position, _speed)
                .OnComplete(() => UpdateLookForward(true))
                .SetEase(Ease.Linear));

            _sequence.SetLoops(-1, _loopType).SetEase(Ease.Linear);
        }

        private void UpdateLookForward(bool isLookLeft)
        {
            if (isLookLeft)
            {
                _target.transform.localScale = new Vector3(_scale, _scale, _scale);
            }
            else
            {
                _target.transform.localScale = new Vector3(-_scale, _scale, _scale);
            }
        }
    }
}