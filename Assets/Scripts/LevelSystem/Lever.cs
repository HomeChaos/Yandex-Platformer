using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Lever : MonoBehaviour
{
    [SerializeField] private UnityEvent _action;
    [SerializeField] protected UnityEvent Event;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteOff;
    [SerializeField] private Sprite _spriteOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Рычаг активировался");
            _action?.Invoke();
            Event?.Invoke();
            _spriteRenderer.sprite = _spriteOn;
        }
    }

    public void ResetLever()
    {
        _spriteRenderer.sprite = _spriteOff;
    }
}