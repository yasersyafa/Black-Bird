using System;
using Scripts.Core.EventSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Rigidbody2D rb;

    private void OnEnable()
    {
        EventBus.OnStateChanged += HandleStateChanged;
    }

    private void OnDisable()
    {
        EventBus.OnStateChanged -= HandleStateChanged;
    }

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
            Debug.Log("Player passed the pipe");
            EventBus.PublishPipePassed();
        }

        else if (other.gameObject.CompareTag("DeathZone"))
        {
            Debug.Log("Player died");
            // change state to game over
            EventBus.PublishGameState(GameState.GameOver);
        }
        
    }

    private void HandleStateChanged(GameState currentState)
    {
        switch (currentState)
        {
            case GameState.Waiting:
                rb.simulated = false;
                break;
            case GameState.Playing:
                rb.simulated = true;
                break;
            case GameState.GameOver:
                rb.simulated = false;
                break;
        }
    }
}
