using System;
using UnityEngine;

public class GroundControl : MonoBehaviour {

    [SerializeField] private Transform groundPoolParent;
    private float xSpawnPosition = 6.7f;
    private float ySpawnPosition = -4f;

    private void OnEnable()
    {
        GroundMove.onSpawnGround += SpawnGround;
    }
    private void OnDisable()
    {
        GroundMove.onSpawnGround -= SpawnGround;
    }

    public void SpawnGround()
    {
        Transform ground = groundPoolParent.GetChild(0);
        ground.SetParent(null);
        ground.gameObject.SetActive(true);
        ground.position = new Vector2(xSpawnPosition, ySpawnPosition);
    }
}