using System;
using ColliderBased;
using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Doors : MonoBehaviour
    {
        [SerializeField] private Sprite _openImage;
        [SerializeField] private EnterTriggerComponent _doorTrigger;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Open()
        {
            _spriteRenderer.sprite = _openImage;
            _doorTrigger.gameObject.SetActive(true);
        }
    }
}