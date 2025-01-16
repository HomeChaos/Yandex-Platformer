using UnityEngine;
using UnityEngine.Events;

namespace Traps
{
    [RequireComponent(typeof(Collider2D))]
    public class PlatformButton : MonoBehaviour
    {
        [SerializeField] protected UnityEvent EnterEvent;
        [SerializeField] private UnityEvent _enterAction;
        [SerializeField] protected UnityEvent ExitEvent;
        [SerializeField] private UnityEvent _exitAction;
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _spriteOff;
        [SerializeField] private Sprite _spriteOn;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Item") || collision.CompareTag("Player"))
            {
                _collider2D.offset = new Vector2(0f, 0f);
                if (_collider2D is BoxCollider2D boxCollider)
                {
                    boxCollider.size = new Vector2(1.112518f, 1.046667f);
                }
                Debug.Log("Кнопка активировалась");
                _enterAction?.Invoke();
                EnterEvent?.Invoke();
                _spriteRenderer.sprite = _spriteOn;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Item") || collision.CompareTag("Player"))
            {
                _collider2D.offset = new Vector2(0.006249666f, -0.00817728f);
                if (_collider2D is BoxCollider2D boxCollider)
                {
                    boxCollider.size = new Vector2(1.112518f, 0.8678184f);
                }
                Debug.Log("Кнопка деактивировалась");
                _exitAction?.Invoke();
                ExitEvent?.Invoke();
                _spriteRenderer.sprite = _spriteOff;
            }
        }
    }
}
