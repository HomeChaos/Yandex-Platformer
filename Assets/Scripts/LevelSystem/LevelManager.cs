using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Curtain _curtain;
        
        private Resettable[] _components;
        private Coroutine _resetCoroutine;
        
        private void Awake()
        {
            _components = FindObjectsOfType<Resettable>();
        }

        public void OnPlayerExit()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            yield return _curtain.ShowCurtain();
            
            foreach (var res in _components)
            {
                res.ApplyReset();
            }

            yield return _curtain.HideCurtain();
            _resetCoroutine = null;
        }
    }
}