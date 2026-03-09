using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CyberSec
{
    public class EmailSimulation : MonoBehaviour
    {
        [Header("Email UI")]
        public TextMeshProUGUI senderText;
        public TextMeshProUGUI subjectText;
        public TextMeshProUGUI bodyText;
        public Button markPhishingButton;
        public Button markSafeButton;
        public GameObject emailPanel;

        private PhishingController controller;

        private void Start()
        {
            controller = GetComponentInParent<PhishingController>();
            if (controller == null) controller = FindObjectOfType<PhishingController>();

            if (markPhishingButton) markPhishingButton.onClick.AddListener(() => controller?.OnPlayerAnswer(true));
            if (markSafeButton) markSafeButton.onClick.AddListener(() => controller?.OnPlayerAnswer(false));
        }

        public void DisplayEmail(EmailData email)
        {
            if (emailPanel) emailPanel.SetActive(true);
            if (senderText) senderText.text = $"From: {email.sender}";
            if (subjectText) subjectText.text = $"Subject: {email.subject}";
            if (bodyText) bodyText.text = email.body;
        }

        public void HideEmail()
        {
            if (emailPanel) emailPanel.SetActive(false);
        }
    }
}
