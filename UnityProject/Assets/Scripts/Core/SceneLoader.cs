using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace CyberSec
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader Instance { get; private set; }

        public float minimumLoadTime = 1f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1f;
            LoadScene(Constants.SCENE_MAIN_MENU);
        }

        public void LoadLevelSelect()
        {
            LoadScene(Constants.SCENE_LEVEL_SELECT);
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            EventManager.TriggerEvent("LoadingStarted");

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false;

            float timer = 0f;
            while (!operation.isDone)
            {
                timer += Time.unscaledDeltaTime;
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                EventManager.TriggerEvent("LoadingProgress", progress);

                if (operation.progress >= 0.9f && timer >= minimumLoadTime)
                {
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }

            EventManager.TriggerEvent("LoadingComplete");
        }

        public void ReloadCurrentScene()
        {
            LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
