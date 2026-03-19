import re

file_path = r"c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\script.rpy"

with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

# Replace "show character happy" or "show character sad" with "show character"
# Also handles "at center", "with dissolve", etc.
# Pattern: show [character_name] (happy|sad)
new_content = re.sub(r'(show\s+\w+)\s+(happy|sad)', r'\1', content)

# Also update the ending evaluation text if it says "All 5 levels complete"
new_content = new_content.replace("All 5 levels complete", "All 10 levels complete")

# Update level_select logic
# Find the level_select label and update the jump logic
# Currently it probably looks like:
# if not level_1_done: jump level_1
# ...
# if level_1_done and level_2_done and ... level_5_done: jump ending

# I'll do this more carefully in the next step.

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(new_content)
