using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

namespace CyberSec
{
    public class VideoController : MonoBehaviour
    {
        [Header("Components")]
        public VideoPlayer videoPlayer;
        public RawImage videoDisplay;
        public GameObject videoPanel;

        [Header("Controls")]
        public Button playButton;
        public Button skipButton;

        private Action onVideoComplete;

        private void Start()
        {
            if (skipButton) skipButton.onClick.AddListener(SkipVideo);
            if (playButton) playButton.onClick.AddListener(TogglePlayPause);
            if (videoPlayer) videoPlayer.loopPointReached += OnVideoEnd;
            if (videoPanel) videoPanel.SetActive(false);
        }

        public void PlayVideo(VideoClip clip, Action onComplete = null)
        {
            onVideoComplete = onComplete;

            if (videoPlayer == null || clip == null)
            {
                onComplete?.Invoke();
                return;
            }

            RenderTexture rt = new RenderTexture(1920, 1080, 0);
            videoPlayer.targetTexture = rt;
            if (videoDisplay) videoDisplay.texture = rt;

            videoPlayer.clip = clip;
            if (videoPanel) videoPanel.SetActive(true);
            videoPlayer.Play();
        }

        private void TogglePlayPause()
        {
            if (videoPlayer == null) return;
            if (videoPlayer.isPlaying) videoPlayer.Pause();
            else videoPlayer.Play();
        }

        public void SkipVideo()
        {
            if (videoPlayer) videoPlayer.Stop();
            if (videoPanel) videoPanel.SetActive(false);
            onVideoComplete?.Invoke();
        }

        private void OnVideoEnd(VideoPlayer vp)
        {
            if (videoPanel) videoPanel.SetActive(false);
            onVideoComplete?.Invoke();
        }

        private void OnDestroy()
        {
            if (videoPlayer) videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
