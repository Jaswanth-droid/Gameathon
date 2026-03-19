
import os
import sys
from PIL import Image, ImageFilter, ImageEnhance
from rembg import remove
from tqdm import tqdm

input_dir = r'c:\Users\DELL\OneDrive\Desktop\Gameathon\Assets\NewCharacters'
output_dir = r'c:\Users\DELL\OneDrive\Desktop\Gameathon\CyberSecGame\game\images'

if not os.path.exists(output_dir):
    os.makedirs(output_dir)

images = [f for f in os.listdir(input_dir) if f.lower().endswith(('.png', '.jpg', '.jpeg'))]

print(f"Found {len(images)} images to process.")

for filename in tqdm(images):
    try:
        input_path = os.path.join(input_dir, filename)
        output_filename = os.path.splitext(filename)[0] + '.png'
        output_path = os.path.join(output_dir, output_filename)

        # 1. Load Image
        with open(input_path, 'rb') as i:
            input_data = i.read()
        
        # 2. Remove Background
        output_data = remove(input_data)
        
        # 3. Open with PIL for further processing
        with open(output_path, 'wb') as o:
            o.write(output_data)
            
        img = Image.open(output_path)
        
        # 4. Quality Enhancement
        # Sharpening
        img = img.filter(ImageFilter.SHARPEN)
        img = img.filter(ImageFilter.DETAIL)
        
        # Enhance Color/Contrast if needed
        enhancer = ImageEnhance.Contrast(img)
        img = enhancer.enhance(1.1)
        
        enhancer = ImageEnhance.Sharpness(img)
        img = enhancer.enhance(1.5)

        # 5. Upscale (Simple bilinear or bicubic for now if small)
        if img.width < 500:
            new_width = img.width * 2
            new_height = int(img.height * (new_width / img.width))
            img = img.resize((new_width, new_height), Image.Resampling.LANCZOS)

        # 6. Save final
        img.save(output_path, 'PNG', quality=95)

    except Exception as e:
        print(f"Error processing {filename}: {e}")

print("Processing complete.")
