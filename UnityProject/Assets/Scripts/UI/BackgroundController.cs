using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CyberSec
{
    public class BackgroundController : MonoBehaviour
    {
        public static BackgroundController Instance { get; private set; }

        public Image backgroundImage;
        public float fadeDuration = 1.0f;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void SetBackground(Sprite newSprite)
        {
            if (backgroundImage == null || newSprite == null) return;
            
            if (backgroundImage.sprite == null)
            {
                backgroundImage.sprite = newSprite;
                backgroundImage.color = Color.white;
            }
            else
            {
                StartCoroutine(FadeToBackground(newSprite));
            }
        }

        private IEnumerator FadeToBackground(Sprite newSprite)
        {
            // Simple fade out/in
            float elapsed = 0;
            while (elapsed < fadeDuration / 2)
            {
                elapsed += Time.deltaTime;
                backgroundImage.color = Color.lerp(Color.white, Color.clear, elapsed / (fadeDuration / 2));
                yield return null;
            }

            backgroundImage.sprite = newSprite;

            elapsed = 0;
            while (elapsed < fadeDuration / 2)
            {
                elapsed += Time.deltaTime;
                backgroundImage.color = Color.lerp(Color.clear, Color.white, elapsed / (fadeDuration / 2));
                yield return null;
            }
            
            backgroundImage.color = Color.white;
        }
    }
}
