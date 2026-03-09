using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class SocialEngineeringController : BaseLevelController
    {
        private List<DialogNode> scenarioNodes;
        private int scenarioIndex = 0;

        private List<List<DialogNode>> scenarios = new List<List<DialogNode>>();

        protected override void Start()
        {
            levelNumber = 3;
            levelTitle = "Social Engineering";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Welcome to Social Engineering Defense!",
                "People may try to manipulate you into revealing sensitive information.",
                "You'll face scenarios where someone tries to trick you.",
                "Stay alert: verify identities, don't share personal info with strangers."
            };

            GenerateScenarios();
            base.Start();
        }

        private void GenerateScenarios()
        {
            // Scenario 1: Fake IT support call
            scenarios.Add(new List<DialogNode> {
                new DialogNode { id = "s1_start", speaker = "Unknown Caller", text = "Hi, this is IT Support. We've detected a virus on your computer. I need your password to fix it remotely.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Sure, my password is...", nextId = "s1_fail", scoreChange = -20, feedback = "Never share your password! IT support will never ask for it." },
                    new DialogChoice { text = "I'll contact IT directly through official channels.", nextId = "s1_pass", scoreChange = 20, feedback = "Great thinking! Always verify through official channels." }
                }},
                new DialogNode { id = "s1_fail", speaker = "System", text = "The caller was a scammer! They now have access to your account.", choices = new List<DialogChoice>() },
                new DialogNode { id = "s1_pass", speaker = "System", text = "Smart move! The caller was indeed a scammer. You stayed safe.", choices = new List<DialogChoice>() }
            });

            // Scenario 2: Tailgating
            scenarios.Add(new List<DialogNode> {
                new DialogNode { id = "s2_start", speaker = "Stranger", text = "Hey, I forgot my badge! Can you hold the door open for me? I work on the 3rd floor.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Sure, come on in!", nextId = "s2_fail", scoreChange = -20, feedback = "This is tailgating! Always verify identity before granting access." },
                    new DialogChoice { text = "Sorry, you'll need to check in at reception.", nextId = "s2_pass", scoreChange = 20, feedback = "Correct! Never let unverified people into secure areas." }
                }},
                new DialogNode { id = "s2_fail", speaker = "System", text = "The person was an intruder who stole sensitive documents.", choices = new List<DialogChoice>() },
                new DialogNode { id = "s2_pass", speaker = "System", text = "The stranger left when asked to verify. Security protocols kept everyone safe!", choices = new List<DialogChoice>() }
            });

            // Scenario 3: USB drop
            scenarios.Add(new List<DialogNode> {
                new DialogNode { id = "s3_start", speaker = "Scene", text = "You find a USB drive labeled 'CONFIDENTIAL - Salary Info' in the parking lot.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Plug it into my computer to see what's on it!", nextId = "s3_fail", scoreChange = -20, feedback = "Never plug in unknown USB drives! They can contain malware." },
                    new DialogChoice { text = "Turn it in to security without plugging it in.", nextId = "s3_pass", scoreChange = 20, feedback = "Perfect! Unknown USB drives are a common attack vector." }
                }},
                new DialogNode { id = "s3_fail", speaker = "Hacker", text = "The USB contained malware that infected your entire network!", choices = new List<DialogChoice>() },
                new DialogNode { id = "s3_pass", speaker = "System", text = "Good call! Security confirmed it was a planted attack device.", choices = new List<DialogChoice>() }
            });
        }

        public override void StartLevel()
        {
            base.StartLevel();
            scenarioIndex = 0;
            ShowNextScenario();
        }

        private void ShowNextScenario()
        {
            if (scenarioIndex >= scenarios.Count)
            {
                CompleteLevel();
                return;
            }

            DialogSystem.Instance?.StartDialog(scenarios[scenarioIndex], (result) =>
            {
                scenarioIndex++;
                Invoke(nameof(ShowNextScenario), 1f);
            });
        }
    }
}
