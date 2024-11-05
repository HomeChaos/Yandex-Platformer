using System.Collections;
using LevelSystem;
using UnityEngine;

namespace Traps
{
    public class FallingFloor : Resettable
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _delay;
        [SerializeField] private float _timeToFly;

        private Coroutine _animationCoroutine;
        private Vector3 _startPosition;

        private void Start()
        {
            _startPosition = _rigidbody2D.gameObject.transform.position;
        }

        public override void ApplyReset()
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
                _animationCoroutine = null;
            }

            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _rigidbody2D.velocity = Vector2.zero;
            _collider.isTrigger = false;
            _rigidbody2D.gameObject.transform.position = _startPosition;
        }

        public void Activate()
        {
            if (_animationCoroutine != null)
                return;
            
            _animationCoroutine = StartCoroutine(Apply());
        }

        private IEnumerator Apply()
        {
            yield return new WaitForSeconds(_delay);

            _collider.isTrigger = true;
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

            yield return new WaitForSeconds(_timeToFly);
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}