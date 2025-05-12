using UnityEngine;

namespace Scripts.Objects.Env
{
    public class BackgroundResizer : MonoBehaviour
    {
        [SerializeField] private float mobileAspectThreshold = 1.6f;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr == null || sr.sprite == null) return;

            float spriteWidth = sr.sprite.bounds.size.x;
            float spriteHeight = sr.sprite.bounds.size.y;

            float worldHeight = Camera.main.orthographicSize * 2f;
            float worldWidth = worldHeight * Screen.width / Screen.height;

            float aspectRatio = (float)Screen.width / Screen.height;

            Vector3 scale = transform.localScale;

            if (aspectRatio <= mobileAspectThreshold)
            {
                // Tablet/HP → Fullscreen scaling
                scale.x = worldWidth / spriteWidth;
                scale.y = worldHeight / spriteHeight;
            }
            else
            {
                // Desktop atau device lebar → scale hanya tinggi
                scale.y = worldHeight / spriteHeight;
                scale.x = scale.y; // jaga aspect ratio sprite
            }

            transform.localScale = scale;

        }
    }
}
