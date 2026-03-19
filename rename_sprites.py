import os

images_dir = r"c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\images"

mapping = {
    "WhatsApp Image 2026-03-16 at 14.58.46.png": "prof_meera.png",
    "WhatsApp Image 2026-03-16 at 14.58.47.png": "arjun.png",
    "WhatsApp Image 2026-03-16 at 14.58.54.png": "maya.png",
    "WhatsApp Image 2026-03-16 at 14.58.56 (6).png": "kavita.png",
    "WhatsApp Image 2026-03-16 at 14.58.52 (1).png": "rahul.png",
    "WhatsApp Image 2026-03-16 at 14.58.52 (2).png": "ananya.png",
    "WhatsApp Image 2026-03-16 at 14.58.52 (3).png": "riya.png",
    "WhatsApp Image 2026-03-16 at 14.58.52 (4).png": "vikram.png",
    "WhatsApp Image 2026-03-16 at 14.58.56 (1).png": "naveen.png",
    "WhatsApp Image 2026-03-16 at 14.58.56 (2).png": "sanjay.png",
    "WhatsApp Image 2026-03-16 at 14.58.56 (5).png": "zoe.png",
    "WhatsApp Image 2026-03-16 at 14.58.56 (7).png": "amit.png",
    "WhatsApp Image 2026-03-16 at 14.58.55.png": "rajesh.png",
    "WhatsApp Image 2026-03-16 at 14.58.47 (2).png": "hacker.png"
}

for old_name, new_name in mapping.items():
    old_path = os.path.join(images_dir, old_name)
    new_path = os.path.join(images_dir, new_name)
    if os.path.exists(old_path):
        os.rename(old_path, new_path)
        print(f"Renamed {old_name} to {new_name}")
    else:
        print(f"Skipped {old_name} (not found)")
