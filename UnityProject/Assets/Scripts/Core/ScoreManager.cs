using UnityEngine;

namespace CyberSec
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int currentScore { get; private set; }
        public int maxPossibleScore { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }

        public void ResetScore(int maxScore = 100)
        {
            currentScore = 0;
            maxPossibleScore = maxScore;
        }

        public void AddScore(int points)
        {
            currentScore += points;
            EventManager.TriggerEvent("ScoreChanged", currentScore);
        }

        public void DeductScore(int points)
        {
            currentScore = Mathf.Max(0, currentScore - points);
            EventManager.TriggerEvent("ScoreChanged", currentScore);
        }

        public float GetPercentage() =>
            maxPossibleScore > 0 ? (float)currentScore / maxPossibleScore * 100f : 0f;

        public int CalculateStars()
        {
            float pct = GetPercentage();
            if (pct >= 90f) return 3;
            if (pct >= 60f) return 2;
            if (pct >= 30f) return 1;
            return 0;
        }
    }
}
