using UnityEngine;
using System.Collections.Generic;

namespace CyberSec
{
    public class RansomwareController : BaseLevelController
    {
        protected override void Start()
        {
            levelNumber = 6;
            levelTitle = "Ransomware Response";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Ransomware encrypts your files and demands payment!",
                "You'll learn how to respond to a ransomware attack.",
                "Remember: Never pay the ransom. Report, disconnect, restore from backups."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();

            var nodes = new List<DialogNode> {
                new DialogNode { id = "start", speaker = "System", text = "⚠ YOUR FILES HAVE BEEN ENCRYPTED ⚠\n\nPay 0.5 Bitcoin ($15,000) within 48 hours or your files will be deleted permanently.\n\nTimer: 47:59:58", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Pay the ransom to get my files back!", nextId = "paid", scoreChange = -30, feedback = "Paying doesn't guarantee you'll get files back and funds criminal activity!" },
                    new DialogChoice { text = "Don't pay. Disconnect from the network.", nextId = "disconnect", scoreChange = 20 },
                    new DialogChoice { text = "Try to negotiate a lower ransom", nextId = "negotiate", scoreChange = -15, feedback = "Negotiating still funds criminals and wastes precious response time." }
                }},
                new DialogNode { id = "paid", speaker = "Hacker", text = "Payment received... Just kidding, your files are still encrypted. Thanks for the money!", choices = new List<DialogChoice> {
                    new DialogChoice { text = "What do I do now?", nextId = "after_pay" }
                }},
                new DialogNode { id = "after_pay", speaker = "System", text = "You paid but got nothing back. Here's what you should have done:", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Learn the right steps", nextId = "learn" }
                }},
                new DialogNode { id = "negotiate", speaker = "System", text = "While you were negotiating, the malware spread to other devices on your network.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Disconnect now!", nextId = "late_disconnect" }
                }},
                new DialogNode { id = "late_disconnect", speaker = "System", text = "You disconnected, but the damage has spread. Act faster next time.", choices = new List<DialogChoice> {
                    new DialogChoice { text = "What should I do?", nextId = "learn" }
                }},
                new DialogNode { id = "disconnect", speaker = "System", text = "Good! You immediately disconnected from the network. What's your next step?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Report to IT security / authorities", nextId = "reported", scoreChange = 15 },
                    new DialogChoice { text = "Try to remove the malware myself", nextId = "self_fix", scoreChange = -5, feedback = "While brave, tampering without expertise can make recovery harder." }
                }},
                new DialogNode { id = "reported", speaker = "System", text = "IT Security is on it. Do you have backups of your important files?", choices = new List<DialogChoice> {
                    new DialogChoice { text = "Yes! I backed up to an external drive last week.", nextId = "backup_success", scoreChange = 20, feedback = "Backups are your best defense against ransomware!" },
                    new DialogChoice { text = "No... I never set up backups.", nextId = "no_backup", scoreChange = -10 }
                }},
                new DialogNode { id = "backup_success", speaker = "System", text = "Excellent! IT wiped the infected system and you restored from backup. No data lost!", choices = new List<DialogChoice>() },
                new DialogNode { id = "no_backup", speaker = "System", text = "Without backups, some files may be permanently lost. Set up regular backups going forward!", choices = new List<DialogChoice>() },
                new DialogNode { id = "self_fix", speaker = "System", text = "You accidentally deleted encryption keys. Some files are now unrecoverable.", choices = new List<DialogChoice>() },
                new DialogNode { id = "learn", speaker = "System", text = "The correct steps:\n1. Disconnect immediately\n2. Report to IT/authorities\n3. Restore from backups\n4. NEVER pay the ransom", choices = new List<DialogChoice>() }
            };

            DialogSystem.Instance?.StartDialog(nodes, (result) => CompleteLevel());
        }
    }
}
