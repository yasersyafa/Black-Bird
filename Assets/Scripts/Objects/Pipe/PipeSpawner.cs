using UnityEngine;
using UnityEngine.Pool;

namespace Scripts.Objects.Pipe
{
    public class PipeSpawner : MonoBehaviour
    {
        [Header("Pipe Settings")]
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private float spawnX = 10f;
        [SerializeField] private float minY = -1f;
        [SerializeField] private float maxY = 2f;
        [SerializeField] private float spawnInterval = 2f;

        private ObjectPool<GameObject> pipePool;
        private float timer;

        private void Awake()
        {
            pipePool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(pipePrefab),
                actionOnGet: (pipe) => pipe.SetActive(true),
                actionOnRelease: (pipe) => pipe.SetActive(false),
                actionOnDestroy: (pipe) => Destroy(pipe),
                collectionCheck: false,
                defaultCapacity: 10,
                maxSize: 20
            );
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                timer = 0f;
                SpawnPipe();
            }
        }

        private void SpawnPipe()
        {
            float randomY = Random.Range(minY, maxY);
            Vector3 spawnPos = new(spawnX, randomY, 0f);

            GameObject pipeObj = pipePool.Get();
            pipeObj.transform.position = spawnPos;

            Pipe pipe = pipeObj.GetComponent<Pipe>();
            pipe.SetPool(pipePool);
        }
    }
}
