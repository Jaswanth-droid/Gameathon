using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class DataPrivacyController : BaseLevelController
    {
        protected override void Start()
        {
            levelNumber = 9;
            levelTitle = "Data Privacy";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Your personal data is valuable — companies and hackers both want it.",
                "Learn to manage privacy settings and control what you share online.",
                "Think before you post: once data is online, it's hard to remove."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "System", text = "You're setting up a new social media account. The app asks for access to:", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Allow ALL permissions (camera, contacts, location, microphone)", nextId = "all_perms", scoreChange = -20, feedback = "Most apps don't need all permissions! Only grant what's necessary." },
                    new DialogChoice { text = "Only allow what's needed for the app to work", nextId = "smart_perms", scoreChange = 20 }
                }},
                new DialogNode { id = "all_perms", speaker = "System", text = "The app now has access to everything. It's quietly uploading your contacts and tracking your location 24/7.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Go to settings and fix this", nextId = "smart_perms" }
                }},
                new DialogNode { id = "smart_perms", speaker = "System", text = "Good! Now the app asks you to complete your profile. What info do you share?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Full name, school, birthday, address, phone number", nextId = "overshare", scoreChange = -15, feedback = "That's way too much personal info! Especially your address and phone." },
                    new DialogChoice { text = "First name only, no school or address", nextId = "minimal", scoreChange = 20, feedback = "Smart! Share the minimum needed." },
                    new DialogChoice { text = "Use a nickname and no real info", nextId = "anon", scoreChange = 15 }
                }},
                new DialogNode { id = "overshare", speaker = "System", text = "A stranger used your public info to find your school and tried to contact you. Be careful what you share!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Remove my personal details", nextId = "privacy_settings" }
                }},
                new DialogNode { id = "minimal", speaker = "System", text = "Good balance! Now let's check your privacy settings.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Continue", nextId = "privacy_settings" }
                }},
                new DialogNode { id = "anon", speaker = "System", text = "Maximum privacy! Let's make sure your account settings match.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Continue", nextId = "privacy_settings" }
                }},
                new DialogNode { id = "privacy_settings", speaker = "System", text = "Who can see your posts?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Everyone (Public)", nextId = "public_bad", scoreChange = -10, feedback = "Public posts can be seen by anyone, including strangers and scrapers." },
                    new DialogChoice { text = "Friends Only", nextId = "friends_good", scoreChange = 15, feedback = "Good choice! Limit your audience to people you know." },
                    new DialogChoice { text = "Only Me (Private)", nextId = "private_ok", scoreChange = 10 }
                }},
                new DialogNode { id = "public_bad", speaker = "System", text = "Your posts are now visible to the entire internet, including data miners.", choices = new List<DialogChoice>() },
                new DialogNode { id = "friends_good", speaker = "System", text = "Only approved friends can see your content. Much safer!", choices = new List<DialogChoice>() },
                new DialogNode { id = "private_ok", speaker = "System", text = "Maximum privacy achieved! Your data is well protected.", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
