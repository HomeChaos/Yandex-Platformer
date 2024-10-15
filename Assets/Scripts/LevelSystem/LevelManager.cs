using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        public void OnPlayerExit()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}