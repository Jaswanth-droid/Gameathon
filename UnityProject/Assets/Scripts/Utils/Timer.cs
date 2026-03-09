using UnityEngine;
using System;

namespace CyberSec
{
    public class Timer : MonoBehaviour
    {
        public float duration = 60f;
        public float timeRemaining { get; private set; }
        public bool isRunning { get; private set; }

        public event Action OnTimerComplete;
        public event Action<float> OnTimerTick;

        public void StartTimer(float seconds)
        {
            duration = seconds;
            timeRemaining = seconds;
            isRunning = true;
        }

        public void StopTimer()
        {
            isRunning = false;
        }

        public void ResumeTimer()
        {
            isRunning = true;
        }

        public void ResetTimer()
        {
            timeRemaining = duration;
            isRunning = false;
        }

        private void Update()
        {
            if (!isRunning) return;

            timeRemaining -= Time.deltaTime;
            OnTimerTick?.Invoke(timeRemaining);

            if (timeRemaining <= 0f)
            {
                timeRemaining = 0f;
                isRunning = false;
                OnTimerComplete?.Invoke();
            }
        }

        public string GetFormattedTime()
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60f);
            int seconds = Mathf.FloorToInt(timeRemaining % 60f);
            return $"{minutes:00}:{seconds:00}";
        }

        public float GetPercentage() =>
            duration > 0 ? timeRemaining / duration : 0f;
    }
}
