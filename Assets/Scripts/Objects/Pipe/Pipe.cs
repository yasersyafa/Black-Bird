using UnityEngine;
using UnityEngine.Pool;

namespace Scripts.Objects.Pipe
{
    public class Pipe : MonoBehaviour
    {
        private ObjectPool<GameObject> pool;

        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float despawnX = -10f;

        public void SetPool(ObjectPool<GameObject> objectPool)
        {
            pool = objectPool;
        }

        private void Update()
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            if (transform.position.x < despawnX)
            {
                pool.Release(gameObject);
            }
        }
    }
}
