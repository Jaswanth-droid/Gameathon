using UnityEngine;

namespace CyberSec
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }

        public LevelData[] levels;
        public int totalLevels = 10;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        private void Start()
        {
            if (levels == null || levels.Length == 0)
                InitializeLevels();
        }

        private void InitializeLevels()
        {
            levels = new LevelData[totalLevels];
            string[] names = {
                "Phishing", "Password Security", "Social Engineering",
                "Malware Download", "Public WiFi", "Ransomware",
                "Two-Factor Auth", "Safe Browsing", "Data Privacy", "Final Attack"
            };
            string[] scenes = {
                "Level01_Phishing", "Level02_PasswordSecurity", "Level03_SocialEngineering",
                "Level04_MalwareDownload", "Level05_PublicWiFi", "Level06_Ransomware",
                "Level07_TwoFactorAuth", "Level08_SafeBrowsing", "Level09_DataPrivacy",
                "Level10_FinalAttack"
            };

            for (int i = 0; i < totalLevels; i++)
            {
                levels[i] = new LevelData
                {
                    levelNumber = i + 1,
                    levelName = names[i],
                    sceneName = scenes[i],
                    isUnlocked = (i == 0),
                    isCompleted = false,
                    stars = 0,
                    highScore = 0
                };
            }
        }

        public void UnlockLevel(int levelNumber)
        {
            if (levelNumber > 0 && levelNumber <= totalLevels)
                levels[levelNumber - 1].isUnlocked = true;
        }

        public void CompleteLevel(int levelNumber, int score, int stars)
        {
            if (levelNumber <= 0 || levelNumber > totalLevels) return;

            var level = levels[levelNumber - 1];
            level.isCompleted = true;
            if (score > level.highScore) level.highScore = score;
            if (stars > level.stars) level.stars = stars;

            // Unlock next level
            if (levelNumber < totalLevels)
                UnlockLevel(levelNumber + 1);

            ProgressManager.Instance?.SaveProgress();
        }

        public LevelData GetLevel(int num) =>
            (num > 0 && num <= totalLevels) ? levels[num - 1] : null;

        public void LoadLevel(int levelNumber)
        {
            if (levelNumber <= 0 || levelNumber > totalLevels) return;
            GameManager.Instance.currentLevel = levelNumber;
            GameManager.Instance.state = GameState.Playing;
            SceneLoader.Instance?.LoadScene(levels[levelNumber - 1].sceneName);
        }
    }

    [System.Serializable]
    public class LevelData
    {
        public int levelNumber;
        public string levelName;
        public string sceneName;
        public bool isUnlocked;
        public bool isCompleted;
        public int stars;
        public int highScore;
    }
}
