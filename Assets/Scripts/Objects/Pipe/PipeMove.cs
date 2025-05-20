using System;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float xDespawnPosition = -3f;
    [SerializeField] private Transform pipePoolParent;

    void Update()
    {
        MovePipe();
        if (transform.position.x <= xDespawnPosition)
            DespawnPipe();   
    }

    void MovePipe()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    
    void DespawnPipe()
    {
        gameObject.SetActive(false);
        transform.SetParent(pipePoolParent);
        transform.SetAsLastSibling();
    }

}
