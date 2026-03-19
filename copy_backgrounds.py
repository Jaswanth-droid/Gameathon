import shutil
import os

src_dirs = [
    r"c:\Users\DELL\OneDrive\Desktop\Gameathon\Assets\Images_1",
    r"c:\Users\DELL\OneDrive\Desktop\Gameathon\Assets\Images_2"
]
dest_dir = r"c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\images"

mapping = {
    # Images_1
    "WhatsApp Image 2026-03-12 at 14.38.03 (1).jpeg": "bg_hacker_room.jpg",
    "WhatsApp Image 2026-03-12 at 14.38.03.jpeg": "bg_server_room.jpg",
    "WhatsApp Image 2026-03-12 at 14.38.04 (1).jpeg": "bg_cafe.jpg",
    "WhatsApp Image 2026-03-12 at 14.38.04.jpeg": "bg_bedroom.jpg",
    "WhatsApp Image 2026-03-12 at 14.46.43 (1).jpeg": "bg_library.jpg",
    "WhatsApp Image 2026-03-12 at 14.46.43.jpeg": "bg_mall.jpg",
    "WhatsApp Image 2026-03-12 at 14.46.44.jpeg": "bg_street.jpg",
    # Images_2
    "WhatsApp Image 2026-03-12 at 15.05.53.jpeg": "bg_app_store.jpg",
    "WhatsApp Image 2026-03-12 at 15.05.56.jpeg": "bg_settings.jpg"
}

for src_dir in src_dirs:
    for filename in os.listdir(src_dir):
        if filename in mapping:
            src_path = os.path.join(src_dir, filename)
            dest_path = os.path.join(dest_dir, mapping[filename])
            shutil.copy2(src_path, dest_path)
            print(f"Copied {filename} to {mapping[filename]}")
