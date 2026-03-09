using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

namespace CyberSec
{
    public class PhishingController : BaseLevelController
    {
        [Header("Phishing Level")]
        public EmailSimulation emailSim;
        public List<EmailData> emails;
        private int currentEmailIndex = 0;
        private int correctAnswers = 0;

        protected override void Start()
        {
            levelNumber = 1;
            levelTitle = "Phishing Awareness";
            maxScore = 100;
            tutorialSteps = new List<string> {
                "Welcome to the Phishing Detection Lab!",
                "You will receive several emails. Some are legitimate, some are phishing attempts.",
                "Read each email carefully and decide: Is it SAFE or PHISHING?",
                "Look for red flags: misspellings, urgent language, suspicious links, unknown senders."
            };
            base.Start();
        }

        public override void StartLevel()
        {
            base.StartLevel();
            currentEmailIndex = 0;
            correctAnswers = 0;

            if (emails == null || emails.Count == 0)
                GenerateDefaultEmails();

            ShowCurrentEmail();
        }

        private void GenerateDefaultEmails()
        {
            emails = new List<EmailData> {
                new EmailData {
                    sender = "security@bankofamerica-verify.com",
                    subject = "URGENT: Your Account Has Been Compromised!",
                    body = "Dear Customer,\n\nWe detected suspicious activity on your account. Click here immediately to verify your identity or your account will be LOCKED in 24 hours!\n\nClick: www.bankofamerica-verify-now.com/login",
                    isPhishing = true,
                    explanation = "Red flags: Suspicious domain (bankofamerica-verify.com), urgent language, threatening account lock, suspicious link."
                },
                new EmailData {
                    sender = "noreply@school.edu",
                    subject = "Library Book Due Reminder",
                    body = "Hi Student,\n\nThis is a reminder that 'Introduction to Computer Science' is due on Friday. Please return it to the front desk.\n\nThanks,\nSchool Library",
                    isPhishing = false,
                    explanation = "This is a legitimate email from a known school domain with no suspicious links or urgency."
                },
                new EmailData {
                    sender = "support@amaz0n-deals.net",
                    subject = "You've Won a $500 Gift Card!",
                    body = "Congratulations!\n\nYou have been randomly selected to receive a $500 Amazon Gift Card! Click below to claim your prize now before it expires!\n\nClaim: www.amaz0n-deals.net/claim",
                    isPhishing = true,
                    explanation = "Red flags: Fake domain (amaz0n with zero), 'you've won' scam, too good to be true, urgency."
                },
                new EmailData {
                    sender = "teacher@school.edu",
                    subject = "Homework Assignment Update",
                    body = "Hello class,\n\nThe homework deadline for Chapter 5 has been extended to next Monday. Please submit via the school portal.\n\nBest regards,\nMrs. Johnson",
                    isPhishing = false,
                    explanation = "Legitimate email from a known teacher with a real school domain."
                },
                new EmailData {
                    sender = "prince.nigerian@royalmail.ng",
                    subject = "Confidential Business Proposal",
                    body = "Dear Friend,\n\nI am Prince Abubakar and I need your help transferring $15,000,000 USD. You will receive 30% for your assistance. Please send your bank details.\n\nYours faithfully,\nPrince Abubakar",
                    isPhishing = true,
                    explanation = "Classic Nigerian prince scam. No legitimate person asks strangers for bank details."
                }
            };
        }

        private void ShowCurrentEmail()
        {
            if (currentEmailIndex >= emails.Count)
            {
                CompleteLevel();
                return;
            }

            if (emailSim != null)
                emailSim.DisplayEmail(emails[currentEmailIndex]);
        }

        public void OnPlayerAnswer(bool markedAsPhishing)
        {
            var email = emails[currentEmailIndex];
            bool correct = (markedAsPhishing == email.isPhishing);

            if (correct)
            {
                correctAnswers++;
                AwardPoints(Constants.SCORE_CORRECT_ANSWER);
                PopupController.Instance?.ShowSuccess($"Correct! {email.explanation}");
            }
            else
            {
                DeductPoints(Mathf.Abs(Constants.SCORE_WRONG_ANSWER));
                PopupController.Instance?.ShowError($"Wrong! {email.explanation}");
            }

            currentEmailIndex++;
            Invoke(nameof(ShowCurrentEmail), 2f);
        }
    }

    [System.Serializable]
    public class EmailData
    {
        public string sender;
        public string subject;
        [TextArea(3, 8)]
        public string body;
        public bool isPhishing;
        public string explanation;
    }
}
