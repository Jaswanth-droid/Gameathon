import re

file_path = r"c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\script.rpy"

with open(file_path, 'r', encoding='utf-8') as f:
    content = f.read()

# 1. Add URL parsing logic after GAME START
init_block = """
init python:
    import os
    # Try to import emscripten for web builds
    try:
        import emscripten
        is_web = True
    except ImportError:
        is_web = False

    def get_web_level():
        if is_web:
            try:
                # Read the current URL query string
                query = emscripten.run_script_string("window.location.search")
                if "level=" in query:
                    # Extract the level number
                    level_str = query.split("level=")[1].split("&")[0]
                    return int(level_str)
            except Exception as e:
                pass
        return None

    def post_level_done(level_num):
        if is_web:
            try:
                emscripten.run_script(f"window.parent.postMessage({{ type: 'LEVEL_DONE', level: {level_num} }}, '*')")
            except Exception as e:
                pass

"""

if "init python:" not in content:
    # Insert before GAME START
    content = content.replace("#  GAME START", init_block + "\n#  GAME START")


# 2. Modify label start to jump directly if web level is specified
start_override = """label start:
    $ requested_level = get_web_level()
    if requested_level == 1:
        jump level_1
    elif requested_level == 2:
        jump level_2
    elif requested_level == 3:
        jump level_3
    elif requested_level == 4:
        jump level_4
    elif requested_level == 5:
        jump level_5
    elif requested_level == 6:
        jump level_6
    elif requested_level == 7:
        jump level_7
    elif requested_level == 8:
        jump level_8
    elif requested_level == 9:
        jump level_9
    elif requested_level == 10:
        jump level_10
"""

if "requested_level = get_web_level()" not in content:
    content = re.sub(r'label start:', start_override + '\n    # Standard Desktop Start:', content)

# 3. Add JS postMessage before every jump level_select at the end of a level
for i in range(1, 11):
    level_end_pattern = fr'(\$ level_{i}_done = True.*?)(    jump level_select|    jump ending)'
    replacement = fr'\1    $ post_level_done({i})\n\2'
    
    # Check if we already patched it
    if f"$ post_level_done({i})" not in content:
        content = re.sub(level_end_pattern, replacement, content, flags=re.DOTALL)

with open(file_path, 'w', encoding='utf-8') as f:
    f.write(content)

print("Integration script applied.")
