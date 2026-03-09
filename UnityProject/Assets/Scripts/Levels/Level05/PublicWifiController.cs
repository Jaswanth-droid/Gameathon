using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class PublicWifiController : BaseLevelController
    {
        protected override void Start()
        {
            levelNumber = 5;
            levelTitle = "Public WiFi Dangers";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "You're at a coffee shop and need to get online.",
                "Public WiFi can be dangerous — hackers can intercept your data.",
                "Learn to identify safe vs. unsafe networks and protect your connection."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "Scene", text = "You're at CyberCafe and need to connect to WiFi for some online banking. You see several networks:", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Connect to 'FREE_COFFEESHOP_WIFI' (no password)", nextId = "unsafe1", scoreChange = -15, feedback = "Unsecured networks can be monitored by anyone!" },
                    new DialogChoice { text = "Connect to 'CyberCafe_Guest' (requires password from staff)", nextId = "safer", scoreChange = 15 },
                    new DialogChoice { text = "Use your mobile data instead", nextId = "safest", scoreChange = 20 }
                }},
                new DialogNode { id = "unsafe1", speaker = "System", text = "Connected to open WiFi. You open your bank app. Meanwhile, a hacker on the same network is capturing your traffic...", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Log in to my bank", nextId = "hacked", scoreChange = -20, feedback = "Never do banking on public WiFi without VPN!" },
                    new DialogChoice { text = "Wait, this might not be safe. Disconnect.", nextId = "recover", scoreChange = 10 }
                }},
                new DialogNode { id = "hacked", speaker = "Hacker", text = "Your bank credentials have been intercepted. The hacker is transferring your savings.", choices = new List<DialogChoice>() },
                new DialogNode { id = "recover", speaker = "System", text = "Good recovery! You disconnected before any damage was done.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Use mobile data instead", nextId = "safest", scoreChange = 10 }
                }},
                new DialogNode { id = "safer", speaker = "System", text = "You connected to the password-protected guest network. It's better, but still not ideal for sensitive transactions. Do you want to use a VPN?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Yes, enable VPN first", nextId = "vpn_safe", scoreChange = 15, feedback = "Excellent! VPN encrypts your traffic, even on public WiFi." },
                    new DialogChoice { text = "No, it should be fine", nextId = "risky_but_ok", scoreChange = -5 }
                }},
                new DialogNode { id = "vpn_safe", speaker = "System", text = "Your connection is now encrypted via VPN. You can safely browse and bank.", choices = new List<DialogChoice>() },
                new DialogNode { id = "risky_but_ok", speaker = "System", text = "You got lucky this time, but without VPN your data could still be intercepted.", choices = new List<DialogChoice>() },
                new DialogNode { id = "safest", speaker = "System", text = "Using mobile data is the safest choice for sensitive transactions. Smart thinking!", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
