using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace CyberSec
{
    public class PopupController : MonoBehaviour
    {
        public static PopupController Instance { get; private set; }

        [Header("UI")]
        public GameObject popupPanel;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI messageText;
        public Button closeButton;
        public Button confirmButton;

        [Header("Settings")]
        public float autoHideDelay = 0f;

        private System.Action onConfirm;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            if (popupPanel) popupPanel.SetActive(false);
            if (closeButton) closeButton.onClick.AddListener(HidePopup);
            if (confirmButton) confirmButton.onClick.AddListener(OnConfirmClicked);
        }

        public void ShowPopup(string title, string message, System.Action onConfirmAction = null)
        {
            if (titleText) titleText.text = title;
            if (messageText) messageText.text = message;

            onConfirm = onConfirmAction;
            if (confirmButton) confirmButton.gameObject.SetActive(onConfirmAction != null);

            if (popupPanel) popupPanel.SetActive(true);

            if (autoHideDelay > 0)
                StartCoroutine(AutoHide());
        }

        public void ShowAlert(string message)
        {
            ShowPopup("⚠ SYSTEM ALERT", message);
        }

        public void ShowSuccess(string message)
        {
            ShowPopup("✓ SUCCESS", message);
        }

        public void ShowError(string message)
        {
            ShowPopup("✗ ERROR", message);
        }

        public void HidePopup()
        {
            if (popupPanel) popupPanel.SetActive(false);
        }

        private void OnConfirmClicked()
        {
            onConfirm?.Invoke();
            HidePopup();
        }

        private IEnumerator AutoHide()
        {
            yield return new WaitForSeconds(autoHideDelay);
            HidePopup();
        }
    }
}
