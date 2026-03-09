using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class SafeBrowsingController : BaseLevelController
    {
        protected override void Start()
        {
            levelNumber = 8;
            levelTitle = "Safe Browsing";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Not all websites are safe to visit.",
                "Learn to identify secure vs. dangerous websites.",
                "Look for: HTTPS, valid certificates, official domains, no excessive pop-ups."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "Scene", text = "You need to buy a textbook online. Which website do you choose?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "www.amaz0n-discount-books.com (HTTP)", nextId = "fake_site", scoreChange = -20, feedback = "Fake domain with zero instead of 'o' and no HTTPS!" },
                    new DialogChoice { text = "www.amazon.com/books (HTTPS 🔒)", nextId = "legit_site", scoreChange = 20 },
                    new DialogChoice { text = "www.free-textbooks-download.xyz", nextId = "pirate_site", scoreChange = -15, feedback = ".xyz domains offering free premium content are suspicious." }
                }},
                new DialogNode { id = "fake_site", speaker = "System", text = "This is a clone website! Your credit card info would be stolen. Red flags:\n- No HTTPS\n- Misspelled domain (amaz0n)\n- Too-good-to-be-true prices", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Go to the real Amazon instead", nextId = "legit_site", scoreChange = 10 }
                }},
                new DialogNode { id = "pirate_site", speaker = "System", text = "The site is full of pop-ups and tries to install browser extensions. Your computer is now showing unwanted ads.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Close everything and go to a real store", nextId = "legit_site", scoreChange = 5 }
                }},
                new DialogNode { id = "legit_site", speaker = "System", text = "You're on the official Amazon site with HTTPS encryption. Now, a pop-up appears: 'Download our desktop app for 50% off!'", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Download the app!", nextId = "fake_popup", scoreChange = -15, feedback = "Amazon doesn't have a desktop app. That was a malicious pop-up!" },
                    new DialogChoice { text = "Ignore the pop-up and buy normally", nextId = "safe_purchase", scoreChange = 15, feedback = "Correct! Ignore unexpected pop-ups, even on legitimate sites." }
                }},
                new DialogNode { id = "fake_popup", speaker = "System", text = "That pop-up was injected by adware. Always use the official website controls, not pop-ups.", choices = new List<DialogChoice>() },
                new DialogNode { id = "safe_purchase", speaker = "System", text = "You safely purchased your textbook! Remember to always check:\n✓ HTTPS lock icon\n✓ Correct domain spelling\n✓ Ignore suspicious pop-ups", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
