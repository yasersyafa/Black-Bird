using UnityEngine;

public class PipeControl : MonoBehaviour
{
    [SerializeField] private Transform pipePoolParent;
    private float xSpawnPosition = 9f;
    private float ySpawnPosition;

    [Range(0.5f, 2.5f)][SerializeField] private float spawnInterval = 1.5f;
    private float timer;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPipe), 0f, spawnInterval);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    public void SpawnPipe()
    {
        ySpawnPosition = Random.Range(-2f, 2f);
        Transform pipe = pipePoolParent.GetChild(0);
        pipe.SetParent(null);
        pipe.gameObject.SetActive(true);
        pipe.position = new Vector2(xSpawnPosition, ySpawnPosition);
    }
}
