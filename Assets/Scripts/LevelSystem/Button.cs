using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Button : MonoBehaviour
{
    [SerializeField] protected UnityEvent EnterEvent;
    [SerializeField] private UnityEvent _enterAction;
    [SerializeField] protected UnityEvent ExitEvent;
    [SerializeField] private UnityEvent _exitAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Player"))
        {
            Debug.Log("Кнопка активировалась");
            _enterAction?.Invoke();
            EnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Item") || collision.CompareTag("Player"))
        {
            Debug.Log("Кнопка деактивировалась");
            _exitAction?.Invoke();
            ExitEvent?.Invoke();
        }
    }
}