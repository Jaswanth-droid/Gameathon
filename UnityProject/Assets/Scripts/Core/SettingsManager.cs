using UnityEngine;

namespace CyberSec
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance { get; private set; }

        public float musicVolume = 0.8f;
        public float sfxVolume = 1f;
        public int qualityLevel = 2;
        public bool isFullscreen = true;

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
            LoadSettings();
            ApplySettings();
        }

        public void SetMusicVolume(float vol)
        {
            musicVolume = Mathf.Clamp01(vol);
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            EventManager.TriggerEvent("MusicVolumeChanged", musicVolume);
        }

        public void SetSFXVolume(float vol)
        {
            sfxVolume = Mathf.Clamp01(vol);
            PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
            EventManager.TriggerEvent("SFXVolumeChanged", sfxVolume);
        }

        public void SetQuality(int level)
        {
            qualityLevel = level;
            QualitySettings.SetQualityLevel(level);
            PlayerPrefs.SetInt("QualityLevel", level);
        }

        public void SetFullscreen(bool fs)
        {
            isFullscreen = fs;
            Screen.fullScreen = fs;
            PlayerPrefs.SetInt("Fullscreen", fs ? 1 : 0);
        }

        private void LoadSettings()
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.8f);
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
            qualityLevel = PlayerPrefs.GetInt("QualityLevel", 2);
            isFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        }

        private void ApplySettings()
        {
            QualitySettings.SetQualityLevel(qualityLevel);
            Screen.fullScreen = isFullscreen;
        }

        public void SaveSettings()
        {
            PlayerPrefs.Save();
        }
    }
}
