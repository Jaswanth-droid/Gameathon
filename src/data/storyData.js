import { characterAssets } from '../assets/characters'

export const storyData = {
  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 1: THE SUSPICIOUS EMAIL
  // ═══════════════════════════════════════════════════════════════
  level1_start: {
    id: 'level1_start',
    text: "━━━ LEVEL 1: THE SUSPICIOUS EMAIL ━━━\nYou are Arjun, a corporate analyst at CyberSafe Solutions. It's Monday morning. Your inbox has a new message.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Check your email.", nextId: 'level1_phone' }]
  },
  level1_phone: {
    id: 'level1_phone',
    type: 'module_email',
    text: "Arjun pulls out his phone and sees a notification...",
    speaker: "Arjun",
    speakerName: "Arjun",
    characterImage: characterAssets.Arjun,
    // Results from EmailPhone component will be mapped to these IDs
    moduleResults: {
      inspect: 'level1_inspect',
      delete: 'level1_delete',
      click: 'level1_click'
    }
  },
  level1_inspect: {
    id: 'level1_inspect',
    text: "Arjun: 'Wait... cybersafe-helpdesk.net? Our actual domain is cybersafe.com. This doesn't match.' Arjun notices the sender domain is suspicious.",
    speaker: "Arjun",
    speakerName: "Arjun",
    characterImage: characterAssets.Arjun,
    choices: [
      { 
        text: "Report it as phishing to the IT team", 
        nextId: 'level1_reported',
        scoreChange: 15,
        feedback: "✅ Phishing email reported and quarantined. Excellent awareness!"
      },
      { 
        text: "Click the link to check — maybe it's real", 
        nextId: 'level1_click',
        scoreChange: -20,
        feedback: "⚠️ Never enter credentials on unverified websites. Always check the URL carefully."
      }
    ]
  },
  level1_reported: {
    id: 'level1_reported',
    text: "Arjun: 'I'm forwarding this to IT Security right now. This is a phishing attempt.' The IT team confirms this was a targeted phishing campaign. Arjun's report helped protect the entire company.",
    speaker: "Arjun",
    speakerName: "Arjun",
    characterImage: characterAssets.Arjun,
    choices: [{ text: "Level 1 Complete", nextId: 'level_map' }]
  },
  level1_delete: {
    id: 'level1_delete',
    text: "Arjun: 'This looks suspicious. I'll just delete it.' A safe instinct, but the IT team could have used a report to protect others.",
    speaker: "Arjun",
    speakerName: "Arjun",
    characterImage: characterAssets.Arjun,
    choices: [{ text: "Level 1 Complete", nextId: 'level_map' }]
  },
  level1_click: {
    id: 'level1_click',
    text: "Hacker: 'Got your login. Too easy. Urgency is our best weapon.' 🚨 ACCOUNT COMPROMISED! The hacker used urgency to bypass your judgment.",
    speaker: "Hacker",
    speakerName: "The Shadow",
    characterImage: characterAssets.Hacker,
    choices: [{ text: "Level 1 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 2: PASSWORD SECURITY
  // ═══════════════════════════════════════════════════════════════
  level2_start: {
    id: 'level2_start',
    text: "━━━ LEVEL 2: PASSWORD SECURITY ━━━\nA university cybersecurity lab. Prof. Meera is teaching her students about password safety.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Enter the lab.", nextId: 'level2_lab' }]
  },
  level2_lab: {
    id: 'level2_lab',
    text: "Prof. Meera: 'Good morning, class. I've set up a simulated brute-force attack. Let's see how fast common passwords can be cracked.'",
    speaker: "Meera",
    speakerName: "Prof. Meera",
    characterImage: characterAssets.Meera,
    choices: [{ text: "Watch the demo.", nextId: 'level2_module' }]
  },
  level2_module: {
    id: 'level2_module',
    type: 'module_bruteforce',
    text: "Watching the screen as the attack begins...",
    nextId: 'level2_after_demo'
  },
  level2_after_demo: {
    id: 'level2_after_demo',
    text: "Prof. Meera: 'The password \"password\" was cracked in 0.3 seconds. Now, create a password for the lab system. It's Rahul's turn first.'",
    speaker: "Meera",
    speakerName: "Prof. Meera",
    characterImage: characterAssets.Meera,
    choices: [{ text: "Help Rahul.", nextId: 'level2_choose' }]
  },
  level2_choose: {
    id: 'level2_choose',
    text: "Rahul: 'I need to pick a password... what should I use?'",
    speaker: "Rahul",
    speakerName: "Rahul",
    characterImage: characterAssets.Rahul,
    choices: [
      { 
        text: "Use: MyD0g$Name2024! (long, mixed chars)", 
        nextId: 'level2_strong',
        scoreChange: 20,
        feedback: "✅ Excellent! That would take centuries to brute-force."
      },
      { 
        text: "Use: rahul123 (easy to remember)", 
        nextId: 'level2_weak',
        scoreChange: -15,
        feedback: "❌ Never use personal information or sequential numbers in passwords."
      },
      { 
        text: "Use: password (classic)", 
        nextId: 'level2_classic',
        scoreChange: -25,
        feedback: "🚨 We literally just saw that get cracked in 0.3 seconds!"
      }
    ]
  },
  level2_strong: {
    id: 'level2_strong',
    text: "Prof. Meera: 'Well done, Rahul. Now, Ananya, should you enable two-factor authentication too?'",
    speaker: "Meera",
    speakerName: "Prof. Meera",
    characterImage: characterAssets.Meera,
    choices: [
      { text: "Yes — enable 2FA with an app", nextId: 'level2_victory', scoreChange: 10 },
      { text: "No — a strong password is enough", nextId: 'level2_no2fa', scoreChange: -5 }
    ]
  },
  level2_weak: {
    id: 'level2_weak',
    text: "Prof. Meera: 'Rahul... that's your name followed by 123. A dictionary attack would crack this instantly.'",
    speaker: "Meera",
    speakerName: "Prof. Meera",
    characterImage: characterAssets.Meera,
    choices: [{ text: "Try again.", nextId: 'level2_choose' }]
  },
  level2_classic: {
    id: 'level2_classic',
    text: "Rahul: '...I'll change it.' Lesson: Common passwords are the first things hackers try.",
    speaker: "Rahul",
    speakerName: "Rahul",
    characterImage: characterAssets.Rahul,
    choices: [{ text: "Try again.", nextId: 'level2_choose' }]
  },
  level2_no2fa: {
    id: 'level2_no2fa',
    text: "Prof. Meera: 'A strong password is good, but 2FA adds a critical second layer. Always enable it when available.'",
    speaker: "Meera",
    speakerName: "Prof. Meera",
    characterImage: characterAssets.Meera,
    choices: [{ text: "Level 2 Complete", nextId: 'level_map' }]
  },
  level2_victory: {
    id: 'level2_victory',
    text: "Password + 2FA = very strong security. Level 2 Complete!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 2 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 3: SOCIAL ENGINEERING
  // ═══════════════════════════════════════════════════════════════
  level3_start: {
    id: 'level3_start',
    text: "━━━ LEVEL 3: SOCIAL ENGINEERING ━━━\nYou are Riya, a young professional. You just received a phone call from an unknown number.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Check your phone.", nextId: 'level3_module' }]
  },
  level3_module: {
    id: 'level3_module',
    type: 'module_phone',
    text: "Riya: 'I'm not expecting any calls. Let me check who this is...'",
    speaker: "Riya",
    speakerName: "Riya",
    characterImage: characterAssets.Riya,
    moduleResults: {
      decline: 'level3_decline',
      accept: 'level3_accept'
    }
  },
  level3_decline: {
    id: 'level3_decline',
    text: "Riya: 'I don't recognize this number. I'll let it go to voicemail.' The call goes to voicemail. No message is left. Smart move!",
    speaker: "Riya",
    speakerName: "Riya",
    characterImage: characterAssets.Riya,
    choices: [{ text: "Level 3 Complete", nextId: 'level_map' }]
  },
  level3_accept: {
    id: 'level3_accept',
    text: "Bank Officer: 'Good afternoon, this is Rajesh from National Secure Bank. Someone attempted a ₹50,000 transfer from your account. We need your OTP to block it.'",
    speaker: "Rajesh",
    speakerName: "Bank Officer",
    characterImage: characterAssets.Rajesh,
    choices: [
      { 
        text: "\"My bank would never ask for an OTP over the phone.\"", 
        nextId: 'level3_vishing_avoided',
        scoreChange: 15,
        feedback: "✅ Exactly! Banks never ask for OTPs to 'block' transactions."
      },
      { 
        text: "Provide the OTP — it sounds urgent", 
        nextId: 'level3_vishing_failed',
        scoreChange: -30,
        feedback: "🚨 DISASTER. The OTP authorized a real transfer of ₹50,000."
      }
    ]
  },
  level3_vishing_avoided: {
    id: 'level3_vishing_avoided',
    text: "Riya: 'I'm hanging up. Goodbye.' The scammer disconnected. Riya calls her bank directly and confirms it was a scam.",
    speaker: "Riya",
    speakerName: "Riya",
    characterImage: characterAssets.Riya,
    choices: [{ text: "Level 3 Complete", nextId: 'level_map' }]
  },
  level3_vishing_failed: {
    id: 'level3_vishing_failed',
    text: "System: 🚨 ALERT: ₹50,000 debited from your account! Lesson: OTPs are to confirm YOUR actions, not to block them.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 3 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 4: MALWARE & DOWNLOADS
  // ═══════════════════════════════════════════════════════════════
  level4_start: {
    id: 'level4_start',
    text: "━━━ LEVEL 4: MALWARE & DOWNLOADS ━━━\nYou are Vikram, a student looking for a free code editor for your project.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Start searching.", nextId: 'level4_choices' }]
  },
  level4_choices: {
    id: 'level4_choices',
    text: "Vikram: 'I found a site: SuperCodeEditor v3.1 — Free Download! What should I do?'",
    speaker: "Vikram",
    speakerName: "Vikram",
    characterImage: characterAssets.Vikram,
    choices: [
      { text: "Download from the official website instead", nextId: 'level4_official', scoreChange: 15 },
      { text: "Download from the sketchy site — it's free!", nextId: 'level4_module' },
      { text: "Search for a cracked version", nextId: 'level4_cracked', scoreChange: -25 }
    ]
  },
  level4_official: {
    id: 'level4_official',
    text: "Vikram: 'Actually, random sites can bundle malware. I'll stick to the official source.' Safe and secure!",
    speaker: "Vikram",
    speakerName: "Vikram",
    characterImage: characterAssets.Vikram,
    choices: [{ text: "Level 4 Complete", nextId: 'level_map' }]
  },
  level4_cracked: {
    id: 'level4_cracked',
    text: "System: 🚨 WARNING! The cracked installer contained a keylogger. Every password Vikram types is now being recorded.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 4 Complete", nextId: 'level_map' }]
  },
  level4_module: {
    id: 'level4_module',
    type: 'module_installer',
    text: "The download completes. Vikram runs the installer wizard...",
    speaker: "Vikram",
    speakerName: "Vikram",
    characterImage: characterAssets.Vikram,
    moduleResults: {
      cancel: 'level4_cancel',
      true: 'level4_toolbar_fail', // Toolbar was checked
      false: 'level4_toolbar_pass' // Toolbar was unchecked
    }
  },
  level4_cancel: {
    id: 'level4_cancel',
    text: "Vikram: 'On second thought, I should probably get this from the official site.' Good instinct!",
    speaker: "Vikram",
    speakerName: "Vikram",
    characterImage: characterAssets.Vikram,
    choices: [{ text: "Level 4 Complete", nextId: 'level_map' }]
  },
  level4_toolbar_fail: {
    id: 'level4_toolbar_fail',
    text: "System: ⚠️ BonusSearchToolbar™ installed! Your browser search history is now being tracked. Lesson: Read every checkbox!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 4 Complete", nextId: 'level_map' }]
  },
  level4_toolbar_pass: {
    id: 'level4_toolbar_pass',
    text: "Vikram: 'I unchecked that toolbar. I was paying attention!' Installation complete — without any bundled malware.",
    speaker: "Vikram",
    speakerName: "Vikram",
    characterImage: characterAssets.Vikram,
    choices: [{ text: "Level 4 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 5: PUBLIC WI-FI ATTACK
  // ═══════════════════════════════════════════════════════════════
  level5_start: {
    id: 'level5_start',
    text: "━━━ LEVEL 5: PUBLIC WI-FI ATTACK ━━━\nYou are Naveen, a freelancer working from Bean & Brew café. Time to get some work done.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Check Wi-Fi networks.", nextId: 'level5_module' }]
  },
  level5_module: {
    id: 'level5_module',
    type: 'module_wifi',
    text: "Naveen: 'Let me check the available networks...'",
    speaker: "Naveen",
    speakerName: "Naveen",
    characterImage: characterAssets.Naveen,
    moduleResults: {
      evil_twin: 'level5_evil',
      legit: 'level5_legit',
      other: 'level5_legit'
    }
  },
  level5_evil: {
    id: 'level5_evil',
    text: "Hacker: 'Beautiful. Unencrypted traffic on my Evil Twin hotspot.' 🚨 MAN-IN-THE-MIDDLE ATTACK! Your data is being intercepted.",
    speaker: "Hacker",
    speakerName: "The Shadow",
    characterImage: characterAssets.Hacker,
    choices: [
      { text: "Disconnect immediately and change all passwords", nextId: 'level5_recovery', scoreChange: 15 },
      { text: "Keep using it — it's probably fine", nextId: 'level5_failure', scoreChange: -20 }
    ]
  },
  level5_legit: {
    id: 'level5_legit',
    text: "Naveen: 'I'll use the guest network. It needs a password so it's encrypted. Should I use a VPN too?'",
    speaker: "Naveen",
    speakerName: "Naveen",
    characterImage: characterAssets.Naveen,
    choices: [
      { text: "Yes — turn on a VPN for extra protection", nextId: 'level5_victory', scoreChange: 10 },
      { text: "No — WPA2 is enough", nextId: 'level5_victory', scoreChange: 5 }
    ]
  },
  level5_recovery: {
    id: 'level5_recovery',
    text: "Damage control: passwords changed before the attacker could use them. Level 5 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 5 Complete", nextId: 'level_map' }]
  },
  level5_failure: {
    id: 'level5_failure',
    text: "The hacker continues capturing your data for the next hour. Major credentials compromised. Level 5 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 5 Complete", nextId: 'level_map' }]
  },
  level5_victory: {
    id: 'level5_victory',
    text: "Safe browsing habits! You stayed secure in a public place. Level 5 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 5 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 6: RANSOMWARE RESPONSE (Unity Source)
  // ═══════════════════════════════════════════════════════════════
  level6_start: {
    id: 'level6_start',
    text: "━━━ LEVEL 6: RANSOMWARE RESPONSE ━━━\nYou are Sanjay. ⚠ YOUR FILES HAVE BEEN ENCRYPTED! Pay 0.5 Bitcoin ($15,000) within 48 hours or lose everything.",
    speaker: "System",
    speakerName: "System",
    choices: [
      { text: "Pay the ransom to get files back!", nextId: 'level6_paid', scoreChange: -30, feedback: "Paying doesn't guarantee access and funds criminals!" },
      { text: "Don't pay. Disconnect from the network.", nextId: 'level6_disconnect', scoreChange: 20 },
      { text: "Try to negotiate a lower ransom", nextId: 'level6_negotiate', scoreChange: -15 }
    ]
  },
  level6_paid: {
    id: 'level6_paid',
    text: "Hacker: 'Payment received... Just kidding, your files are still encrypted. Thanks for the money!'",
    speaker: "Hacker",
    speakerName: "The Shadow",
    characterImage: characterAssets.Hacker,
    choices: [{ text: "What do I do now?", nextId: 'level6_disconnect' }]
  },
  level6_negotiate: {
    id: 'level6_negotiate',
    text: "While you were negotiating, the malware spread to other devices on your network. Disconnect NOW!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Disconnect!", nextId: 'level6_disconnect' }]
  },
  level6_disconnect: {
    id: 'level6_disconnect',
    text: "Good! You disconnected. Now, do you have backups?",
    speaker: "Sanjay",
    speakerName: "Sanjay",
    characterImage: characterAssets.Sanjay,
    choices: [
      { text: "Yes! Last week's external backup.", nextId: 'level6_success', scoreChange: 20 },
      { text: "No... I never set up backups.", nextId: 'level6_failure', scoreChange: -20 }
    ]
  },
  level6_success: {
    id: 'level6_success',
    text: "Excellent! You restored from backup. No data lost. Level 6 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 6 Complete", nextId: 'level_map' }]
  },
  level6_failure: {
    id: 'level6_failure',
    text: "Without backups, some files are permanently lost. Set them up now! Level 6 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 6 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 7: TWO-FACTOR AUTH (Unity Source)
  // ═══════════════════════════════════════════════════════════════
  level7_start: {
    id: 'level7_start',
    text: "━━━ LEVEL 7: TWO-FACTOR AUTH ━━━\nYou are Kavita. Your account security settings are open. Enable 2FA now?",
    speaker: "Kavita",
    speakerName: "Kavita",
    characterImage: characterAssets.Kavita,
    choices: [
      { text: "Yes, let's set it up!", nextId: 'level7_methods', scoreChange: 15 },
      { text: "Nah, my password is strong enough.", nextId: 'level7_breach', scoreChange: -20 }
    ]
  },
  level7_breach: {
    id: 'level7_breach',
    text: "A week later... Your account was accessed from an unknown location. Your password was leaked.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Set it up now.", nextId: 'level7_methods' }]
  },
  level7_methods: {
    id: 'level7_methods',
    text: "Choose your 2FA method:",
    speaker: "Kavita",
    speakerName: "Kavita",
    characterImage: characterAssets.Kavita,
    choices: [
      { text: "SMS Text Code", nextId: 'level7_sms', scoreChange: 10 },
      { text: "Authenticator App", nextId: 'level7_app', scoreChange: 20 },
      { text: "Hardware Security Key", nextId: 'level7_hardware', scoreChange: 20 }
    ]
  },
  level7_sms: {
    id: 'level7_sms',
    text: "SMS 2FA enabled! Note: SMS can be vulnerable to SIM swapping. Level 7 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 7 Complete", nextId: 'level_map' }]
  },
  level7_app: {
    id: 'level7_app',
    text: "Authenticator app set up! It generates time-based codes locally. Level 7 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 7 Complete", nextId: 'level_map' }]
  },
  level7_hardware: {
    id: 'level7_hardware',
    text: "Hardware key registered! The most secure method available. Level 7 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 7 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 8: SAFE BROWSING (Unity Source)
  // ═══════════════════════════════════════════════════════════════
  level8_start: {
    id: 'level8_start',
    text: "━━━ LEVEL 8: SAFE BROWSING ━━━\nYou are Zoe. You need to buy a textbook online. Which site do you choose?",
    speaker: "Zoe",
    speakerName: "Zoe",
    characterImage: characterAssets.Zoe,
    choices: [
      { text: "www.amaz0n-discount.com (HTTP)", nextId: 'level8_fake', scoreChange: -20 },
      { text: "www.amazon.com/books (HTTPS 🔒)", nextId: 'level8_secure', scoreChange: 20 },
      { text: "www.free-books.xyz", nextId: 'level8_pirate', scoreChange: -15 }
    ]
  },
  level8_fake: {
    id: 'level8_fake',
    text: "This is a clone website! Your credit card info would be stolen. Red flags: No HTTPS, domain misspelling (amaz0n).",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Go to legit site.", nextId: 'level8_secure' }]
  },
  level8_pirate: {
    id: 'level8_pirate',
    text: "The site is full of pop-ups and malware attempts. Your computer is infected.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Go to legit site.", nextId: 'level8_secure' }]
  },
  level8_secure: {
    id: 'level8_secure',
    text: "You're on the official site with HTTPS. A pop-up appears: 'Download our desktop app for 50% off!'",
    speaker: "System",
    speakerName: "System",
    choices: [
      { text: "Download the app!", nextId: 'level8_malware', scoreChange: -20, feedback: "Amazon doesn't have a desktop app. That was a fake pop-up!" },
      { text: "Ignore the pop-up", nextId: 'level8_victory', scoreChange: 15 }
    ]
  },
  level8_malware: {
    id: 'level8_malware',
    text: "Actually, that was adware. Always use official controls, not pop-ups. Level 8 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 8 Complete", nextId: 'level_map' }]
  },
  level8_victory: {
    id: 'level8_victory',
    text: "Safe purchase confirmed! You checked the URL and ignored the traps. Level 8 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 8 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 9: DATA PRIVACY (Unity Source)
  // ═══════════════════════════════════════════════════════════════
  level9_start: {
    id: 'level9_start',
    text: "━━━ LEVEL 9: DATA PRIVACY ━━━\nYou are Dr. Amit. Setting up a new social account. The app asks for ALL permissions.",
    speaker: "Amit",
    speakerName: "Dr. Amit",
    characterImage: characterAssets.Amit,
    choices: [
      { text: "Allow ALL (camera, contacts, location, mic)", nextId: 'level9_all', scoreChange: -20 },
      { text: "Allow only what's needed", nextId: 'level9_smart', scoreChange: 20 }
    ]
  },
  level9_all: {
    id: 'level9_all',
    text: "The app is now quietly uploading contacts and tracking your location 24/7. Fix this!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Fix settings.", nextId: 'level9_smart' }]
  },
  level9_smart: {
    id: 'level9_smart',
    text: "Smart choice. Now, what info do you share on your public profile?",
    speaker: "Amit",
    speakerName: "Dr. Amit",
    characterImage: characterAssets.Amit,
    choices: [
      { text: "Name, school, birthday, address, phone", nextId: 'level9_overshare', scoreChange: -20 },
      { text: "First name only, minimal details", nextId: 'level9_privacy', scoreChange: 20 }
    ]
  },
  level9_overshare: {
    id: 'level9_overshare',
    text: "A stranger used your public info to locate you. Be careful what you share!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Fix privacy.", nextId: 'level9_privacy' }]
  },
  level9_privacy: {
    id: 'level9_privacy',
    text: "Good balance. Who can see your posts?",
    speaker: "Amit",
    speakerName: "Dr. Amit",
    characterImage: characterAssets.Amit,
    choices: [
      { text: "Everyone (Public)", nextId: 'level9_victory_bad', scoreChange: -10 },
      { text: "Friends Only", nextId: 'level9_victory_good', scoreChange: 15 }
    ]
  },
  level9_victory_bad: {
    id: 'level9_victory_bad',
    text: "Your posts are visible to the entire internet. Lesson: Limit your audience. Level 9 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 9 Complete", nextId: 'level_map' }]
  },
  level9_victory_good: {
    id: 'level9_victory_good',
    text: "Safer! Only people you know can see your content. Level 9 Complete.",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Level 9 Complete", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  LEVEL 10: THE FINAL ATTACK (Unity Source)
  // ═══════════════════════════════════════════════════════════════
  level10_start: {
    id: 'level10_start',
    text: "━━━ LEVEL 10: THE FINAL ATTACK ━━━\nYou are Maya. ⚠ COORDINATED ATTACK DETECTED! Use everything you've learned.",
    speaker: "Maya",
    speakerName: "Maya",
    characterImage: characterAssets.Maya,
    choices: [{ text: "I'm ready.", nextId: 'level10_threat1' }]
  },
  level10_threat1: {
    id: 'level10_threat1',
    text: "THREAT 1: Email from 'ceo@company.com': 'Wire $50,000 immediately. Urgent & Confidential.'",
    speaker: "System",
    speakerName: "System",
    choices: [
      { text: "Wire the money — it's urgent!", nextId: 'level10_fail1', scoreChange: -20 },
      { text: "Call the CEO directly to verify", nextId: 'level10_pass1', scoreChange: 20 }
    ]
  },
  level10_fail1: {
    id: 'level10_fail1',
    text: "CEO Fraud! You sent $50,000 to a criminal. Threat continues...",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Continue.", nextId: 'level10_threat2' }]
  },
  level10_pass1: {
    id: 'level10_pass1',
    text: "The CEO confirms they never sent it. Threat neutralized! Next threat...",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Continue.", nextId: 'level10_threat2' }]
  },
  level10_threat2: {
    id: 'level10_threat2',
    text: "THREAT 2: Files on the server are being encrypted! A ransom note appears.",
    speaker: "System",
    speakerName: "System",
    choices: [
      { text: "Pay the ransom quickly!", nextId: 'level10_fail2', scoreChange: -20 },
      { text: "Disconnect systems and restore backup", nextId: 'level10_pass2', scoreChange: 20 }
    ]
  },
  level10_fail2: {
    id: 'level10_fail2',
    text: "Payment sent but files locked. You funded crime. Threat continues...",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Continue.", nextId: 'level10_threat3' }]
  },
  level10_pass2: {
    id: 'level10_pass2',
    text: "Systems isolated and restoring. Ransomware contained! Next threat...",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Continue.", nextId: 'level10_threat3' }]
  },
  level10_threat3: {
    id: 'level10_threat3',
    text: "THREAT 3: A 'technician' at the door needs server room access. No badge.",
    speaker: "System",
    speakerName: "System",
    choices: [
      { text: "Let them in — it sounds urgent!", nextId: 'level10_fail3', scoreChange: -20 },
      { text: "Ask for management verification", nextId: 'level10_pass3', scoreChange: 20 }
    ]
  },
  level10_fail3: {
    id: 'level10_fail3',
    text: "The 'technician' installed keyloggers everywhere. Breach detected!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Final Result.", nextId: 'level10_final' }]
  },
  level10_pass3: {
    id: 'level10_pass3',
    text: "The imposter fled. Physical security maintained! You've protected the company!",
    speaker: "System",
    speakerName: "System",
    choices: [{ text: "Final Result.", nextId: 'level10_final' }]
  },
  level10_final: {
    id: 'level10_final',
    text: "VICTORY! You've navigated a coordinated attack. Cybersecurity is everyone's responsibility. GAME COMPLETE!",
    speaker: "Maya",
    speakerName: "Maya",
    characterImage: characterAssets.Maya,
    choices: [{ text: "Return to Chapter Selection", nextId: 'level_map' }]
  },

  // ═══════════════════════════════════════════════════════════════
  //  SYSTEM DATA
  // ═══════════════════════════════════════════════════════════════
  level_map: {
    id: 'level_map',
    type: 'level_map'
  }
}
