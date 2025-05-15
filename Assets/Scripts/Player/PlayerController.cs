using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    public Rigidbody2D rb;
    public static Action onPlayerPass;
    public static Action onPlayerDie;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pass"))
        {
            onPlayerPass?.Invoke();
        }
        else if (other.CompareTag("Pipe"))
        {
            onPlayerDie?.Invoke();
        }
        else if (other.CompareTag("Ground"))
        {
            onPlayerDie?.Invoke();
        }
    }

}
