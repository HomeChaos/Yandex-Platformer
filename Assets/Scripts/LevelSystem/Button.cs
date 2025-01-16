using UnityEngine;
using UnityEngine.Events;

// PressedButton
namespace LevelSystem
{
    [RequireComponent(typeof(Collider2D))]
    public class Button : MonoBehaviour
    {
        [SerializeField] private UnityEvent _enterAction;
        [SerializeField] private UnityEvent _exitAction;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Item") || collision.CompareTag("Player"))
            {
                Debug.Log("Кнопка активировалась");
                _enterAction?.Invoke();
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Item") || collision.CompareTag("Player"))
            {
                Debug.Log("Кнопка деактивировалась");
                _exitAction?.Invoke();
            }
        }
    }
}