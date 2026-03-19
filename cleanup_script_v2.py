import re

file_path = r"c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\script.rpy"

with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

# Replace "show [character] happy" or "show [character] sad" with just "show [character]"
# We need to handle cases where there are other attributes like "at center"
# Regex: show\s+(\w+)\s+(happy|sad) -> show \1
new_content = re.sub(r'show\s+(\w+)\s+(happy|sad)', r'show \1', content)

# Check for any remaining occurrences
if " happy" in new_content or " sad" in new_content:
    print("Warning: some 'happy' or 'sad' mentions remain outside simple show statements.")

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(new_content)

print("Expression cleanup complete.")
