﻿using System.Collections;
using Cinemachine;
using DG.Tweening;
using PlayerComponents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;
        [SerializeField] private PlayerFreezer _playerFreezer;
        [SerializeField] private Transform _exitPoint;
        [SerializeField] private CinemachineBrain _cinemachineBrain;
        
        private Resettable[] _components;
        private Coroutine _resetCoroutine;
        private Coroutine _leaveCoroutine;
        
        private void Awake()
        {
            _components = FindObjectsOfType<Resettable>();
        }

        public void OnPlayerExit()
        {
            if (_leaveCoroutine != null)
            {
                Debug.LogWarning("The leave process is already underway");
                return;
            }
            
            _leaveCoroutine = StartCoroutine(ApplyLeaveLevelLogic());
        }

        public void RestartLevel()
        {
            if (_resetCoroutine != null)
            {
                Debug.LogWarning("The restart process is already underway");
                return;
            }
            
            _resetCoroutine = StartCoroutine(ApplyResetLogic());
        }

        private IEnumerator ApplyResetLogic()
        {
            _playerFreezer.FreezeDeath();
            _cinemachineBrain.m_DefaultBlend.m_Time = 0f;
            yield return _curtain.ShowCurtain();
            _playerFreezer.UnFreeze();
            
            foreach (var res in _components)
            {
                res.ApplyReset();
            }
            
            yield return _curtain.HideCurtain();
            _cinemachineBrain.m_DefaultBlend.m_Time = 2f;
            
            _resetCoroutine = null;
        }

        [SerializeField] private float _timeOfMove = 0.5f;
        
        private IEnumerator ApplyLeaveLevelLogic()
        {
            _playerFreezer.gameObject.transform.DOMove(_exitPoint.position, _timeOfMove).SetEase(Ease.Linear);
            _playerFreezer.FreezeExit();
            yield return _curtain.ShowCurtain();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}