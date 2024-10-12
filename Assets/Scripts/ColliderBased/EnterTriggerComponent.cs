using UnityEngine;
using UnityEngine.Events;

namespace ColliderBased
{
    [RequireComponent(typeof(Collider2D))]
    public class EnterTriggerComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;
        [SerializeField] private UnityEvent<GameObject> _action;

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.IsInLayer(_targetLayerMask))
            {
                _action?.Invoke(other.gameObject);
            }
        }
    }
}