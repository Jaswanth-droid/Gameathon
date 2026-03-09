using UnityEngine;

namespace CyberSec
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Player Info")]
        public string playerName = "Agent";
        public int currentLevel = 0;
        public bool isGamePaused = false;

        [Header("Game State")]
        public GameState state = GameState.MainMenu;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            ProgressManager.Instance?.LoadProgress();
        }

        public void SetPlayerName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                playerName = name;
        }

        public void PauseGame()
        {
            isGamePaused = true;
            Time.timeScale = 0f;
            state = GameState.Paused;
        }

        public void ResumeGame()
        {
            isGamePaused = false;
            Time.timeScale = 1f;
            state = GameState.Playing;
        }

        public void QuitGame()
        {
            ProgressManager.Instance?.SaveProgress();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        LevelComplete,
        GameOver
    }
}
