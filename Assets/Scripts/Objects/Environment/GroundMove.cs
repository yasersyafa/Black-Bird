using System;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float xDespawnPosition = -6.7f;
    [SerializeField] private Transform GroundPoolParent;

    public static Action onSpawnGround;

    private void FixedUpdate()
    {
        MoveGround();
        if (transform.position.x <= xDespawnPosition)
            DespawnGround();
    }
    
    void MoveGround()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void DespawnGround()
    {
            onSpawnGround?.Invoke();
            gameObject.SetActive(false);
            transform.SetParent(GroundPoolParent);
            transform.SetAsLastSibling();
    }
}
