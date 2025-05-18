using Scripts.Core;
using Scripts.Core.EventSystem;
using Scripts.Core.Utils.StateMachine;
using UnityEngine;

public class Playing : IState<GameManager>
{
    public void Enter(GameManager context)
    {
        // Initialize game state, start the game, etc.
        EventBus.PublishGameState(GameState.Playing);
    }

    public void Execute(GameManager context)
    {
        EventBus.PublishGameUpdate(Time.deltaTime);
    }

    public void Exit(GameManager context)
    {
        
    }
}
