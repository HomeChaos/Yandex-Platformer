using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace LevelSystem
{
    public class Curtain : MonoBehaviour
    {
        [Serializable]
        private class AnimationSetup
        {
            public float Time;
            public Ease Ease;
        }
        
        [SerializeField] private Image _lockdownImage;
        [SerializeField] private AnimationSetup _showSetup;
        [SerializeField] private AnimationSetup _hideSetup;

        private void Awake()
        {
            _lockdownImage.DOFade(0, 0).OnComplete(() => _lockdownImage.gameObject.SetActive(false));
        }

        public IEnumerator ShowCurtain(Action func = null)
        {
            _lockdownImage.gameObject.SetActive(true);
            _lockdownImage.DOFade(1, _showSetup.Time).SetEase(_showSetup.Ease);
            yield return new WaitForSeconds(_showSetup.Time);
            
            func?.Invoke();
            yield return null;
        }

        public IEnumerator HideCurtain(Action func = null)
        {
            _lockdownImage.DOFade(0, _hideSetup.Time).SetEase(_hideSetup.Ease);
            yield return new WaitForSeconds(_hideSetup.Time);
            
            func?.Invoke();
            _lockdownImage.gameObject.SetActive(false);
            yield return null;
        }
    }
}