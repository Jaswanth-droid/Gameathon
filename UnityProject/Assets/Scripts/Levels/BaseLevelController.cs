using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public abstract class BaseLevelController : MonoBehaviour
    {
        [Header("Level Info")]
        public int levelNumber;
        public string levelTitle;
        public int maxScore = 100;

        [Header("Tutorial")]
        public List<string> tutorialSteps;
        public bool showTutorial = true;

        protected bool isLevelActive = false;

        protected virtual void Start()
        {
            ScoreManager.Instance?.ResetScore(maxScore);

            if (showTutorial && tutorialSteps != null && tutorialSteps.Count > 0)
            {
                TutorialUI tutorial = FindObjectOfType<TutorialUI>();
                if (tutorial != null)
                    tutorial.ShowTutorial(tutorialSteps, OnTutorialComplete);
                else
                    StartLevel();
            }
            else
            {
                StartLevel();
            }
        }

        protected virtual void OnTutorialComplete()
        {
            StartLevel();
        }

        public virtual void StartLevel()
        {
            isLevelActive = true;
            Debug.Log($"Level {levelNumber}: {levelTitle} started!");
        }

        public virtual void CompleteLevel()
        {
            isLevelActive = false;
            int score = ScoreManager.Instance?.currentScore ?? 0;
            int stars = ScoreManager.Instance?.CalculateStars() ?? 0;

            LevelManager.Instance?.CompleteLevel(levelNumber, score, stars);

            PopupController.Instance?.ShowPopup(
                "Level Complete!",
                $"Score: {score}/{maxScore}\nStars: {new string('★', stars)}{new string('☆', 3 - stars)}",
                () => SceneLoader.Instance?.LoadLevelSelect()
            );

            EventManager.TriggerEvent(Constants.EVENT_LEVEL_COMPLETE);
        }

        public virtual void FailLevel(string reason = "")
        {
            isLevelActive = false;

            PopupController.Instance?.ShowPopup(
                "Level Failed",
                string.IsNullOrEmpty(reason) ? "Better luck next time!" : reason,
                () => SceneLoader.Instance?.ReloadCurrentScene()
            );

            EventManager.TriggerEvent(Constants.EVENT_LEVEL_FAILED);
        }

        protected void AwardPoints(int points)
        {
            ScoreManager.Instance?.AddScore(points);
        }

        protected void DeductPoints(int points)
        {
            ScoreManager.Instance?.DeductScore(points);
        }
    }
}
