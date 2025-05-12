using UnityEngine;

namespace Scripts.Objects.Env
{
    public class GroundResizer : MonoBehaviour
    {
        void Start()
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr == null || sr.sprite == null) return;

            float spriteWidth = sr.sprite.bounds.size.x;

            // Hitung lebar dunia berdasarkan ukuran kamera dan aspect ratio
            float worldHeight = Camera.main.orthographicSize * 2f;
            float worldWidth = worldHeight * Screen.width / Screen.height;

            // Resize hanya di sumbu X
            Vector3 scale = transform.localScale;
            scale.x = worldWidth / spriteWidth;
            transform.localScale = scale;

            // Tempatkan di bagian bawah layar
            // float spriteHeight = sr.bounds.size.y * scale.y;
            // Vector3 newPos = transform.position;
            // newPos.y = Camera.main.transform.position.y - (worldHeight / 2f) + (spriteHeight / 2f);
            // transform.position = newPos;
        }

    }
}
