using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class TwoFactorAuthController : BaseLevelController
    {
        protected override void Start()
        {
            levelNumber = 7;
            levelTitle = "Two-Factor Authentication";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Two-Factor Authentication (2FA) adds an extra layer of security.",
                "Even if someone steals your password, they can't log in without the second factor.",
                "Common 2FA methods: SMS codes, authenticator apps, hardware keys."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "System", text = "Your account security settings are open. Would you like to enable Two-Factor Authentication?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Yes, let's set it up!", nextId = "choose_method", scoreChange = 10 },
                    new DialogChoice { text = "Nah, my password is strong enough.", nextId = "no_2fa", scoreChange = -15, feedback = "Even strong passwords can be leaked in data breaches!" }
                }},
                new DialogNode { id = "no_2fa", speaker = "System", text = "A week later... Your account was accessed from an unknown location. Your password was found in a data breach.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "I should have set up 2FA...", nextId = "choose_method" }
                }},
                new DialogNode { id = "choose_method", speaker = "System", text = "Choose your 2FA method:\n\n1. SMS Text Code\n2. Authenticator App (Google/Microsoft)\n3. Hardware Security Key", choices = new List<DialogChoice> {
                    new DialogChoice { text = "SMS Text Code", nextId = "sms", scoreChange = 10, feedback = "SMS is better than nothing, but can be intercepted via SIM swapping." },
                    new DialogChoice { text = "Authenticator App", nextId = "app", scoreChange = 20, feedback = "Authenticator apps are very secure and work offline!" },
                    new DialogChoice { text = "Hardware Security Key", nextId = "hardware", scoreChange = 20, feedback = "Hardware keys are the most secure 2FA method!" }
                }},
                new DialogNode { id = "sms", speaker = "System", text = "SMS 2FA enabled! Note: SMS can be vulnerable to SIM swapping attacks. Consider upgrading to an authenticator app.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Good to know, I'll consider upgrading", nextId = "test_login" }
                }},
                new DialogNode { id = "app", speaker = "System", text = "Authenticator app set up! It generates time-based codes that change every 30 seconds.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Let's test it!", nextId = "test_login" }
                }},
                new DialogNode { id = "hardware", speaker = "System", text = "Hardware key registered! Just plug it in or tap it when logging in.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Let's test it!", nextId = "test_login" }
                }},
                new DialogNode { id = "test_login", speaker = "System", text = "Test: Someone tries to log in with your password from another country. They are blocked because they don't have your 2FA device!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "2FA saved my account!", nextId = "complete", scoreChange = 15 }
                }},
                new DialogNode { id = "complete", speaker = "System", text = "Excellent! 2FA is one of the simplest and most effective security measures you can use.", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
