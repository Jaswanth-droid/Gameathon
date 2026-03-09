using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CyberSec
{
    public class LevelSelectUI : MonoBehaviour
    {
        [Header("UI")]
        public Transform levelGrid;
        public GameObject levelButtonPrefab;
        public TextMeshProUGUI playerNameText;

        [Header("Colors")]
        public Color unlockedColor = new Color(0f, 0.8f, 0.6f, 1f);
        public Color lockedColor = new Color(0.3f, 0.3f, 0.3f, 0.5f);
        public Color completedColor = new Color(0.2f, 0.6f, 1f, 1f);

        private void Start()
        {
            if (playerNameText != null && GameManager.Instance != null)
                playerNameText.text = $"Agent: {GameManager.Instance.playerName}";

            PopulateLevels();
        }

        private void PopulateLevels()
        {
            if (LevelManager.Instance == null || levelGrid == null || levelButtonPrefab == null)
                return;

            // Clear existing
            foreach (Transform child in levelGrid)
                Destroy(child.gameObject);

            for (int i = 0; i < LevelManager.Instance.totalLevels; i++)
            {
                var level = LevelManager.Instance.levels[i];
                GameObject btnObj = Instantiate(levelButtonPrefab, levelGrid);

                // Set button text
                TextMeshProUGUI btnText = btnObj.GetComponentInChildren<TextMeshProUGUI>();
                if (btnText != null)
                {
                    btnText.text = $"Level {level.levelNumber}\n{level.levelName}";
                    if (level.isCompleted)
                        btnText.text += $"\n★ {level.stars}/3";
                }

                // Set button color and interactability
                Button btn = btnObj.GetComponent<Button>();
                Image btnImage = btnObj.GetComponent<Image>();

                if (level.isCompleted && btnImage)
                    btnImage.color = completedColor;
                else if (level.isUnlocked && btnImage)
                    btnImage.color = unlockedColor;
                else if (btnImage)
                    btnImage.color = lockedColor;

                btn.interactable = level.isUnlocked;

                int levelNum = level.levelNumber;
                btn.onClick.AddListener(() => OnLevelSelected(levelNum));
            }
        }

        private void OnLevelSelected(int levelNumber)
        {
            LevelManager.Instance?.LoadLevel(levelNumber);
        }

        public void OnBackClicked()
        {
            SceneLoader.Instance?.LoadMainMenu();
        }
    }
}
