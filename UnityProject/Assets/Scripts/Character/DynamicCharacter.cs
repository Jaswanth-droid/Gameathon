using UnityEngine;

namespace CyberSec
{
    public class DynamicCharacter : MonoBehaviour
    {
        public CharacterProfile profile;
        
        [Header("Movement Settings")]
        public bool useIdleMovement = true;
        public float bobSpeed = 2f;
        public float bobAmount = 0.1f;
        private Vector3 startPosition;

        [Header("Current State")]
        public MoodState currentMood = MoodState.Neutral;
        public int relationshipScore = 0; // -100 to 100

        private void Start()
        {
            startPosition = transform.position;
            UpdateAppearance();
        }

        private void Update()
        {
            if (useIdleMovement)
            {
                float newY = startPosition.y + Mathf.Sin(Time.time * bobSpeed) * bobAmount;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }

        private void OnMouseDown()
        {
            Debug.Log($"Clicked on {profile?.characterName}.");
            SetMood(MoodState.Interested);
            // Visual feedback - slight scale up
            transform.localScale = Vector3.one * 1.1f;
        }

        private void OnMouseUp()
        {
            Debug.Log($"Released click on {profile?.characterName}.");
            // Reset scale
            transform.localScale = Vector3.one;
            
            // Trigger dialogue or interaction
            string greeting = GetGreeting();
            PopupController.Instance?.ShowPopup(profile?.characterName ?? "NPC", greeting);
        }

        public void SetMood(MoodState newMood)
        {
            currentMood = newMood;
            UpdateAppearance();
        }

        public void ModifyRelationship(int amount)
        {
            relationshipScore += amount;
            relationshipScore = Mathf.Clamp(relationshipScore, -100, 100);
            
            // Auto-adjust mood based on relationship if significant
            if (relationshipScore < -50) currentMood = MoodState.Angry;
            else if (relationshipScore > 50) currentMood = MoodState.Happy;
            
            UpdateAppearance();
        }

        private void UpdateAppearance()
        {
            if (profile == null) return;
            
            // This would normally signal the SpriteRenderer or Dialogue UI
            Sprite currentPortrait = profile.GetPortrait(currentMood);
            Debug.Log($"Character {profile.characterName} changed appearance to {currentMood}.");
            
            // If the character has a SpriteRenderer, update it
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null && currentPortrait != null)
            {
                sr.sprite = currentPortrait;
            }
        }
        
        public string GetGreeting()
        {
            if (profile == null) return "Hello.";
            
            if (relationshipScore > 70) return $"So good to see you again, my friend!";
            if (relationshipScore < -70) return $"What do YOU want now?";
            
            return profile.introductionText;
        }
    }
}
