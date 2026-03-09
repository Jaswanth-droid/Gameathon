export const storyData = {
  start: {
    id: 'start',
    text: "It's lunchtime at school. You see Leo, the kid who always has the latest gear, surrounded by a crowd. He's playing 'NEON-STRIKE 2' on a customized handheld.",
    speaker: "Scene",
    speakerName: "School Hallway",
    type: 'cinematic',
    choices: [
      { text: "Go see what the hype is about.", nextId: 'school_leo' }
    ]
  },
  school_leo: {
    id: 'school_leo',
    text: "Leo: 'Check it out! I got the early access build. It's normally $70, but my dad just bought it for me. You probably can't afford it, right?'",
    speaker: "Leo",
    speakerName: "Leo",
    choices: [
      { text: "Ignore him and walk away.", nextId: 'home_moping' },
      { text: "Ask if there's any way to get it cheaper.", nextId: 'leo_hint' }
    ]
  },
  leo_hint: {
    id: 'leo_hint',
    text: "Leo smirks. 'I mean, if you're desperate, I heard there's a cracked version on some forum... but that's for people who enjoy getting their devices fried.'",
    speaker: "Leo",
    speakerName: "Leo",
    choices: [
      { text: "Go home and think about it.", nextId: 'home_moping' }
    ]
  },
  home_moping: {
    id: 'home_moping',
    text: "You're at your computer. Your bank balance shows exactly $4.50. You really want that game. You open a search tab.",
    speaker: "Scene",
    speakerName: "Your Bedroom",
    choices: [
      { text: "Search: 'NEON-STRIKE 2 Official Store'", nextId: 'search_official' },
      { text: "Search: 'NEON-STRIKE 2 FREE DOWNLOAD CRACK'", nextId: 'search_shady' }
    ]
  },
  search_official: {
    id: 'search_official',
    text: "OFFICIAL STORE: 'NEON-STRIKE 2 - $69.99'. You don't have enough. The temptation of the 'free' versions you saw earlier starts to grow.",
    speaker: "System",
    speakerName: "Web Browser",
    choices: [
      { text: "Go back to the search results.", nextId: 'home_moping' }
    ]
  },
  search_shady: {
    id: 'search_shady',
    text: "FORUM THREAD: '100% WORKING CRACK - NO VIRUS!'. The download button is flashing bright red. Do you click it?",
    speaker: "System",
    speakerName: "ShadyForum.net",
    choices: [
      {
        text: "It's just a game, click DOWNLOAD.",
        nextId: 'hacker_breach',
        isCritical: true,
        feedback: "Your curiosity outweighed your caution. You've invited someone into your system."
      },
      {
        text: "Too risky. Close the tab.",
        nextId: 'safe_path',
        scoreChange: 50
      }
    ]
  },
  hacker_breach: {
    id: 'hacker_breach',
    text: "The screen freezes. The lights in your virtual room flicker. Slowly, a terminal window opens on your screen, typing itself out...",
    speaker: "Hacker",
    speakerName: "???",
    type: 'breach',
    choices: [
      { text: "Who are you?", nextId: 'hacker_intro' }
    ]
  },
  hacker_intro: {
    id: 'hacker_intro',
    text: "Hacker: 'Thanks for the access, kid. You wanted the game for free? I'll take your data as payment. Let's see what's in your bank stash...'",
    speaker: "Hacker",
    speakerName: "The Shadow",
    choices: [
      { text: "TRY TO SHUT DOWN", nextId: 'fail_end' }
    ]
  },
  safe_path: {
    id: 'safe_path',
    text: "You closed the tab. It sucks not having the game, but your identity and savings are safe. Sarah (your mentor) texts you: 'Heard you avoided that fake crack. Good job. Patience pays off.'",
    speaker: "Sarah",
    speakerName: "Sarah (SMS)",
    choices: [
      { text: "Restart Simulation", nextId: 'start' }
    ]
  },
  fail_end: {
    id: 'fail_end',
    text: "SYSTEM ERROR. Bank Balance: $0.00. Personal Photos: UPLOADED. You learned the hard way that 'free' always has a price.",
    speaker: "System",
    speakerName: "CRITICAL FAILURE",
    choices: [
      { text: "Restart and Try Again", nextId: 'start' }
    ]
  }
};
