using UnityEngine;

namespace ColliderBased
{
    [RequireComponent(typeof(Collider2D))]
    public class ColliderCheck : LayerCheck
    {
        private Collider2D _collider;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _collider.isTrigger = true;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(GroundLayerMask);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(GroundLayerMask);
        }
    }
}