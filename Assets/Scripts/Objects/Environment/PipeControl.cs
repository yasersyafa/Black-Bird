using UnityEngine;

public class PipeControl : MonoBehaviour
{
    [SerializeField] private Transform pipePoolParent;
    private float xSpawnPosition = 9f;
    private float ySpawnPosition;

    [SerializeField, Range(0.1f, 5f)] private float spawnInterval = 0.75f;
    private float timer;

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
