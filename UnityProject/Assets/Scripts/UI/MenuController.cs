using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CyberSec
{
    public class MenuController : MonoBehaviour
    {
        [Header("Panels")]
        public GameObject mainPanel;
        public GameObject settingsPanel;
        public GameObject nameInputPanel;

        [Header("Name Input")]
        public TMP_InputField nameInput;
        public TextMeshProUGUI welcomeText;

        [Header("Settings")]
        public Slider musicSlider;
        public Slider sfxSlider;

        private void Start()
        {
            ShowMainPanel();

            if (musicSlider != null)
            {
                musicSlider.value = SettingsManager.Instance?.musicVolume ?? 0.8f;
                musicSlider.onValueChanged.AddListener(OnMusicChanged);
            }
            if (sfxSlider != null)
            {
                sfxSlider.value = SettingsManager.Instance?.sfxVolume ?? 1f;
                sfxSlider.onValueChanged.AddListener(OnSFXChanged);
            }
        }

        public void OnPlayClicked()
        {
            if (string.IsNullOrEmpty(GameManager.Instance?.playerName) || GameManager.Instance.playerName == "Agent")
            {
                ShowNameInput();
            }
            else
            {
                GoToLevelSelect();
            }
        }

        public void OnNameSubmitted()
        {
            string name = nameInput?.text ?? "Agent";
            GameManager.Instance?.SetPlayerName(name);
            GoToLevelSelect();
        }

        public void OnSettingsClicked()
        {
            ShowSettingsPanel();
        }

        public void OnBackFromSettings()
        {
            SettingsManager.Instance?.SaveSettings();
            ShowMainPanel();
        }

        public void OnQuitClicked()
        {
            GameManager.Instance?.QuitGame();
        }

        private void GoToLevelSelect()
        {
            SceneLoader.Instance?.LoadLevelSelect();
        }

        private void ShowMainPanel()
        {
            if (mainPanel) mainPanel.SetActive(true);
            if (settingsPanel) settingsPanel.SetActive(false);
            if (nameInputPanel) nameInputPanel.SetActive(false);
        }

        private void ShowSettingsPanel()
        {
            if (mainPanel) mainPanel.SetActive(false);
            if (settingsPanel) settingsPanel.SetActive(true);
        }

        private void ShowNameInput()
        {
            if (mainPanel) mainPanel.SetActive(false);
            if (nameInputPanel) nameInputPanel.SetActive(true);
        }

        private void OnMusicChanged(float val) => SettingsManager.Instance?.SetMusicVolume(val);
        private void OnSFXChanged(float val) => SettingsManager.Instance?.SetSFXVolume(val);
    }
}
