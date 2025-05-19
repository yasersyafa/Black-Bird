using Scripts.Core;
using Scripts.Core.EventSystem;
using Scripts.Core.Utils.StateMachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOver : IState<GameManager>
{
    public void Enter(GameManager context)
    {
        EventBus.PublishGameState(GameState.GameOver);
    }

    public void Execute(GameManager context)
    {
        
    }

    public void Exit(GameManager context)
    {
        
    }
}
