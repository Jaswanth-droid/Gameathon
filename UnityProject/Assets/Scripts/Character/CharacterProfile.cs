using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    [CreateAssetMenu(fileName = "NewCharacterProfile", menuName = "CyberSec/Character Profile")]
    public class CharacterProfile : ScriptableObject
    {
        public string characterName;
        public CharacterTrait baseTrait;
        public Sprite defaultPortrait;
        
        [Header("Dialogue Variability")]
        [TextArea(3, 10)]
        public string introductionText;
        
        [Header("Mood Sprites")]
        public Sprite happyPortrait;
        public Sprite angryPortrait;
        public Sprite sadPortrait;
        public Sprite afraidPortrait;

        public Sprite GetPortrait(MoodState mood)
        {
            switch (mood)
            {
                case MoodState.Happy: return happyPortrait != null ? happyPortrait : defaultPortrait;
                case MoodState.Angry: return angryPortrait != null ? angryPortrait : defaultPortrait;
                case MoodState.Afraid: return afraidPortrait != null ? afraidPortrait : defaultPortrait;
                default: return defaultPortrait;
            }
        }
    }
}
