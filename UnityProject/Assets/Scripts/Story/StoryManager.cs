using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class StoryManager : MonoBehaviour
    {
        public static StoryManager Instance { get; private set; }

        public StoryNode startNode;
        private StoryNode currentNode;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            if (startNode != null)
            {
                PlayNode(startNode);
            }
        }

        public void PlayNode(StoryNode node)
        {
            currentNode = node;
            
            // Update UI via DialogSystem
            DialogSystem.Instance?.ShowStoryNode(node);
            
            // Update Background
            if (node.backgroundSprite != null)
            {
                BackgroundController.Instance?.SetBackground(node.backgroundSprite);
            }
        }

        public void MakeChoice(StoryChoice choice)
        {
            // Apply impacts
            if (choice.securityIntegrityChange != 0)
            {
                ScoreManager.Instance?.AddScore(choice.securityIntegrityChange);
            }

            if (!string.IsNullOrEmpty(choice.feedbackText))
            {
                PopupController.Instance?.ShowPopup("System Log", choice.feedbackText);
            }

            if (choice.nextNode != null)
            {
                PlayNode(choice.nextNode);
            }
        }

        public void Continue()
        {
            if (currentNode.nextNode != null)
            {
                PlayNode(currentNode.nextNode);
            }
        }
    }
}
