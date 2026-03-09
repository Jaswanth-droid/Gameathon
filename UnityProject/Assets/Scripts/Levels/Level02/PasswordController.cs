using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace CyberSec
{
    public class PasswordController : BaseLevelController
    {
        [Header("Password Level")]
        public TMP_InputField passwordInput;
        public TextMeshProUGUI strengthLabel;
        public Image strengthBar;
        public TextMeshProUGUI feedbackText;
        public Button submitButton;

        private PasswordStrengthChecker checker;
        private int challengeIndex = 0;
        private List<string> challenges = new List<string> {
            "Create a password for your email account",
            "Create a password for your bank account",
            "Create a password for your school portal"
        };

        protected override void Start()
        {
            levelNumber = 2;
            levelTitle = "Password Security";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Welcome to the Password Security Lab!",
                "You'll create passwords for different accounts.",
                "Strong passwords use: uppercase, lowercase, numbers, symbols.",
                "Avoid: names, birthdays, common words, or sequences like '123456'."
            };

            checker = GetComponent<PasswordStrengthChecker>();
            if (checker == null) checker = gameObject.AddComponent<PasswordStrengthChecker>();

            if (submitButton) submitButton.onClick.AddListener(OnSubmitPassword);
            if (passwordInput) passwordInput.onValueChanged.AddListener(OnPasswordChanged);

            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();
            challengeIndex = 0;
            ShowChallenge();
        }

        private void ShowChallenge()
        {
            if (challengeIndex >= challenges.Count)
            {
                CompleteLevel();
                return;
            }

            if (feedbackText) feedbackText.text = challenges[challengeIndex];
            if (passwordInput) passwordInput.text = "";
        }

        private void OnPasswordChanged(string password)
        {
            if (checker == null) return;
            var result = checker.EvaluatePassword(password);
            if (strengthLabel) strengthLabel.text = result.label;
            if (strengthBar)
            {
                strengthBar.fillAmount = result.score / 100f;
                strengthBar.color = result.color;
            }
        }

        private void OnSubmitPassword()
        {
            string password = passwordInput?.text ?? "";
            var result = checker.EvaluatePassword(password);

            if (result.score >= 70)
            {
                AwardPoints(Constants.SCORE_CORRECT_ANSWER + (int)(result.score * 0.1f));
                PopupController.Instance?.ShowSuccess($"Great password! Strength: {result.label}");
                challengeIndex++;
                Invoke(nameof(ShowChallenge), 2f);
            }
            else
            {
                DeductPoints(5);
                PopupController.Instance?.ShowAlert($"That password is too weak ({result.label}). Try again!\nTip: {result.tip}");
            }
        }
    }
}
