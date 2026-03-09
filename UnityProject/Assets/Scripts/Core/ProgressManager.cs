using UnityEngine;

namespace CyberSec
{
    public class ProgressManager : MonoBehaviour
    {
        public static ProgressManager Instance { get; private set; }

        private const string PROGRESS_KEY = "CyberSec_Progress";
        private const string PLAYER_NAME_KEY = "CyberSec_PlayerName";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        public void SaveProgress()
        {
            if (LevelManager.Instance == null) return;

            var data = new ProgressData();
            data.playerName = GameManager.Instance?.playerName ?? "Agent";
            data.levelCount = LevelManager.Instance.totalLevels;
            data.unlocked = new bool[data.levelCount];
            data.completed = new bool[data.levelCount];
            data.stars = new int[data.levelCount];
            data.highScores = new int[data.levelCount];

            for (int i = 0; i < data.levelCount; i++)
            {
                var level = LevelManager.Instance.levels[i];
                data.unlocked[i] = level.isUnlocked;
                data.completed[i] = level.isCompleted;
                data.stars[i] = level.stars;
                data.highScores[i] = level.highScore;
            }

            string json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(PROGRESS_KEY, json);
            PlayerPrefs.Save();
            Debug.Log("Progress saved.");
        }

        public void LoadProgress()
        {
            if (!PlayerPrefs.HasKey(PROGRESS_KEY)) return;
            if (LevelManager.Instance == null) return;

            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            var data = JsonUtility.FromJson<ProgressData>(json);

            if (GameManager.Instance != null)
                GameManager.Instance.playerName = data.playerName;

            int count = Mathf.Min(data.levelCount, LevelManager.Instance.totalLevels);
            for (int i = 0; i < count; i++)
            {
                var level = LevelManager.Instance.levels[i];
                level.isUnlocked = data.unlocked[i];
                level.isCompleted = data.completed[i];
                level.stars = data.stars[i];
                level.highScore = data.highScores[i];
            }
            Debug.Log("Progress loaded.");
        }

        public void ResetProgress()
        {
            PlayerPrefs.DeleteKey(PROGRESS_KEY);
            PlayerPrefs.Save();
            Debug.Log("Progress reset.");
        }
    }

    [System.Serializable]
    public class ProgressData
    {
        public string playerName;
        public int levelCount;
        public bool[] unlocked;
        public bool[] completed;
        public int[] stars;
        public int[] highScores;
    }
}
