using UnityEngine.SceneManagement;

namespace BootstrapSystem
{
    public static class BootstrapInitiator
    {
        private const int INDEX_OF_BOOT_SCENE = 0;
        
        public static string lastLoadScene = string.Empty;

        public static void InitBootstrap(string loadScene)
        {
            lastLoadScene = loadScene;
            SceneManager.LoadScene(INDEX_OF_BOOT_SCENE);
        }
    }
}