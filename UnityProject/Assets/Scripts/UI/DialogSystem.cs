using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace CyberSec
{
    public class DialogSystem : MonoBehaviour
    {
        public static DialogSystem Instance { get; private set; }

        [Header("UI References")]
        public GameObject dialogPanel;
        public TextMeshProUGUI speakerNameText;
        public TextMeshProUGUI dialogueText;
        public Transform choiceContainer;
        public GameObject choiceButtonPrefab;
        public Image speakerPortrait;

        [Header("Typewriter Settings")]
        public float typingSpeed = 0.03f;
        public bool useTypewriter = true;

        private DialogNode currentNode;
        private Dictionary<string, DialogNode> dialogMap = new Dictionary<string, DialogNode>();
        private Coroutine typingCoroutine;
        private bool isTyping = false;
        private string fullText = "";

        private System.Action<string> onDialogComplete;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void StartDialog(List<DialogNode> nodes, System.Action<string> callback = null)
        {
            dialogMap.Clear();
            foreach (var node in nodes)
                dialogMap[node.id] = node;

            onDialogComplete = callback;
            EventManager.TriggerEvent(Constants.EVENT_DIALOG_STARTED);

            if (dialogPanel) dialogPanel.SetActive(true);
            ShowNode(nodes[0].id);
        }

        public void ShowNode(string nodeId)
        {
            if (!dialogMap.ContainsKey(nodeId))
            {
                EndDialog(nodeId);
                return;
            }

            currentNode = dialogMap[nodeId];

            // Update speaker
            if (speakerNameText) speakerNameText.text = currentNode.speaker;

            // Clear choices
            if (choiceContainer)
            {
                foreach (Transform child in choiceContainer)
                    Destroy(child.gameObject);
            }

            // Show text
            fullText = currentNode.text;
            if (useTypewriter)
            {
                if (typingCoroutine != null) StopCoroutine(typingCoroutine);
                typingCoroutine = StartCoroutine(TypeText(fullText));
            }
            else
            {
                if (dialogueText) dialogueText.text = fullText;
                ShowChoices();
            }
        }

        private IEnumerator TypeText(string text)
        {
            isTyping = true;
            dialogueText.text = "";
            foreach (char c in text)
            {
                dialogueText.text += c;
                yield return new WaitForSeconds(typingSpeed);
            }
            isTyping = false;
            ShowChoices();
        }

        public void SkipTyping()
        {
            if (isTyping && typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
                isTyping = false;
                dialogueText.text = fullText;
                ShowChoices();
            }
        }

        private void ShowChoices()
        {
            if (currentNode.choices == null || currentNode.choices.Count == 0)
            {
                // Auto-advance or end
                CreateChoiceButton("Continue", () => EndDialog("complete"));
                return;
            }

            foreach (var choice in currentNode.choices)
            {
                var c = choice; // capture for closure
                CreateChoiceButton(c.text, () =>
                {
                    if (c.scoreChange != 0)
                        ScoreManager.Instance?.AddScore(c.scoreChange);

                    if (!string.IsNullOrEmpty(c.feedback))
                        PopupController.Instance?.ShowPopup("Alert", c.feedback);

                    if (!string.IsNullOrEmpty(c.nextId))
                        ShowNode(c.nextId);
                    else
                        EndDialog("complete");
                });
            }
        }

        private void CreateChoiceButton(string text, System.Action onClick)
        {
            if (choiceContainer == null || choiceButtonPrefab == null) return;

            GameObject btnObj = Instantiate(choiceButtonPrefab, choiceContainer);
            var btnText = btnObj.GetComponentInChildren<TextMeshProUGUI>();
            if (btnText) btnText.text = text;

            var btn = btnObj.GetComponent<Button>();
            if (btn) btn.onClick.AddListener(() => onClick());
        }

        private void EndDialog(string result)
        {
            if (dialogPanel) dialogPanel.SetActive(false);
            EventManager.TriggerEvent(Constants.EVENT_DIALOG_ENDED);
            onDialogComplete?.Invoke(result);
        }

        private void Update()
        {
            if (isTyping && Input.GetMouseButtonDown(0))
                SkipTyping();
        }
    }

    [System.Serializable]
    public class DialogNode
    {
        public string id;
        public string speaker;
        [TextArea(2, 5)]
        public string text;
        public List<DialogChoice> choices;
    }

    [System.Serializable]
    public class DialogChoice
    {
        public string text;
        public string nextId;
        public int scoreChange;
        public string feedback;
    }
}
