using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    [CreateAssetMenu(fileName = "NewStoryNode", menuName = "CyberSec/Story Node")]
    public class StoryNode : ScriptableObject
    {
        public string speakerName;
        [TextArea(3, 10)]
        public string dialogueText;
        public Sprite characterPortrait;
        public Sprite backgroundSprite;
        
        [Header("Next Steps")]
        public StoryNode nextNode; // For sequential flow
        public List<StoryChoice> choices; // For branching flow
        
        [Header("Events")]
        public string eventToTrigger; // e.g. "StartPhishingMinigame"
    }

    [System.Serializable]
    public class StoryChoice
    {
        public string choiceText;
        public StoryNode nextNode;
        
        [Header("Impacts")]
        public int securityIntegrityChange;
        public int relationshipChange;
        public string feedbackText;
    }
}
