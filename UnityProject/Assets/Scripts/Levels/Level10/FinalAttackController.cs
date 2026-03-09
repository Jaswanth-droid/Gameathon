using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class FinalAttackController : BaseLevelController
    {
        private int threatsStopped = 0;

        protected override void Start()
        {
            levelNumber = 10;
            levelTitle = "The Final Attack";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "ALERT: A coordinated cyber attack is targeting your organization!",
                "You must use everything you've learned to defend against multiple threats.",
                "This is the final test — stay sharp and think critically!"
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();
            threatsStopped = 0;

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "System", text = "⚠ INCOMING THREAT DETECTED ⚠\n\nMultiple attack vectors detected simultaneously. You must respond to each one correctly.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "I'm ready. Let's do this.", nextId = "threat1" }
                }},

                // Threat 1: Phishing Email
                new DialogNode { id = "threat1", speaker = "System", text = "THREAT 1: Email from 'ceo@company-emergency.com': 'Wire $50,000 to this account immediately. This is urgent and confidential.'", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Wire the money — it's from the CEO!", nextId = "t1_fail", scoreChange = -15, feedback = "CEO fraud! Always verify unusual requests through a different channel." },
                    new DialogChoice { text = "Call the CEO directly to verify", nextId = "t1_pass", scoreChange = 15 }
                }},
                new DialogNode { id = "t1_fail", speaker = "Hacker", text = "That wasn't your CEO. You just sent $50,000 to a criminal.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat...", nextId = "threat2" }
                }},
                new DialogNode { id = "t1_pass", speaker = "System", text = "The CEO confirms they never sent that email. Threat neutralized!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat", nextId = "threat2" }
                }},

                // Threat 2: Ransomware
                new DialogNode { id = "threat2", speaker = "System", text = "THREAT 2: Files on the server are being encrypted! A ransom note appears demanding Bitcoin.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Pay the ransom quickly!", nextId = "t2_fail", scoreChange = -15, feedback = "Never pay ransom!" },
                    new DialogChoice { text = "Disconnect affected systems and restore from backup", nextId = "t2_pass", scoreChange = 15 }
                }},
                new DialogNode { id = "t2_fail", speaker = "System", text = "Payment sent but files remain encrypted. You funded criminal operations.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat...", nextId = "threat3" }
                }},
                new DialogNode { id = "t2_pass", speaker = "System", text = "Systems isolated and restoring from backup. Ransomware contained!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat", nextId = "threat3" }
                }},

                // Threat 3: Social Engineering
                new DialogNode { id = "threat3", speaker = "System", text = "THREAT 3: A 'technician' at the door says they need server room access for emergency maintenance. They have no badge.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Let them in — it sounds urgent!", nextId = "t3_fail", scoreChange = -15, feedback = "Always verify identity before granting physical access!" },
                    new DialogChoice { text = "Ask them to wait while you verify with management", nextId = "t3_pass", scoreChange = 15 }
                }},
                new DialogNode { id = "t3_fail", speaker = "System", text = "The 'technician' installed a hardware keylogger on every workstation.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat...", nextId = "threat4" }
                }},
                new DialogNode { id = "t3_pass", speaker = "System", text = "The imposter fled when you asked for verification. Physical security maintained!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Next threat", nextId = "threat4" }
                }},

                // Threat 4: Data Exfiltration
                new DialogNode { id = "threat4", speaker = "System", text = "THREAT 4: An employee's account is uploading hundreds of files to an external cloud storage at 3 AM.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Ignore it, they're probably working late", nextId = "t4_fail", scoreChange = -15, feedback = "Unusual data transfers at odd hours are a major red flag!" },
                    new DialogChoice { text = "Immediately suspend the account and investigate", nextId = "t4_pass", scoreChange = 15 }
                }},
                new DialogNode { id = "t4_fail", speaker = "System", text = "The compromised account exfiltrated 500GB of customer data. Major breach.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "See final results", nextId = "final" }
                }},
                new DialogNode { id = "t4_pass", speaker = "System", text = "The account was compromised. You stopped the data breach in time!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "See final results", nextId = "final" }
                }},

                new DialogNode { id = "final", speaker = "System", text = "THE ATTACK IS OVER.\n\nYou've experienced a coordinated cyber attack. Every lesson from the previous levels was tested.\n\nRemember: Cybersecurity is everyone's responsibility!", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
