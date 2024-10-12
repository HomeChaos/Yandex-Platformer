using NaughtyAttributes;
using UnityEngine;

namespace ColliderBased
{
    public class LayerCheck : MonoBehaviour
    {
        [SerializeField] protected LayerMask GroundLayerMask;
        [SerializeField, ReadOnly] protected bool IsTouchingLayer;

        public bool IsTouching => IsTouchingLayer;
    }
}