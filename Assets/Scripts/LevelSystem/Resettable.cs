using System;
using UnityEngine;
using UnityEngine.Events;

namespace LevelSystem
{
    public abstract class Resettable : MonoBehaviour
    {
        [SerializeField] protected UnityEvent Event;
        
        public abstract void ApplyReset();
    }
}