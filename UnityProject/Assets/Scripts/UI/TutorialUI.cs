using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace CyberSec
{
    public class TutorialUI : MonoBehaviour
    {
        [Header("UI")]
        public GameObject tutorialPanel;
        public TextMeshProUGUI stepText;
        public TextMeshProUGUI stepCounterText;
        public Button nextButton;
        public Button prevButton;
        public Button skipButton;

        private List<string> steps = new List<string>();
        private int currentStep = 0;
        private System.Action onComplete;

        private void Start()
        {
            if (nextButton) nextButton.onClick.AddListener(NextStep);
            if (prevButton) prevButton.onClick.AddListener(PrevStep);
            if (skipButton) skipButton.onClick.AddListener(SkipTutorial);

            if (tutorialPanel) tutorialPanel.SetActive(false);
        }

        public void ShowTutorial(List<string> tutorialSteps, System.Action onCompleteCallback = null)
        {
            steps = tutorialSteps;
            onComplete = onCompleteCallback;
            currentStep = 0;

            if (tutorialPanel) tutorialPanel.SetActive(true);
            DisplayStep();
        }

        private void DisplayStep()
        {
            if (stepText && currentStep < steps.Count)
                stepText.text = steps[currentStep];

            if (stepCounterText)
                stepCounterText.text = $"Step {currentStep + 1} / {steps.Count}";

            if (prevButton) prevButton.interactable = currentStep > 0;
            if (nextButton)
            {
                var btnText = nextButton.GetComponentInChildren<TextMeshProUGUI>();
                if (btnText) btnText.text = currentStep >= steps.Count - 1 ? "Got it!" : "Next";
            }
        }

        public void NextStep()
        {
            currentStep++;
            if (currentStep >= steps.Count)
                CompleteTutorial();
            else
                DisplayStep();
        }

        public void PrevStep()
        {
            currentStep = Mathf.Max(0, currentStep - 1);
            DisplayStep();
        }

        public void SkipTutorial()
        {
            CompleteTutorial();
        }

        private void CompleteTutorial()
        {
            if (tutorialPanel) tutorialPanel.SetActive(false);
            onComplete?.Invoke();
        }
    }
}
