using Scripts.Core;
using Scripts.Core.EventSystem;
using Scripts.Core.Utils.StateMachine;
using UnityEngine;

public class Waiting : IState<GameManager>
{
    public void Enter(GameManager context)
    {
        context.ShowUIMainMenu();
        EventBus.PublishGameState(GameState.Waiting);
    }

    public void Execute(GameManager context)
    {
        if (Input.anyKey)
        {
            context.ChangeState(GameState.Playing, new Playing());
        }
    }

    public void Exit(GameManager context)
    {
        throw new System.NotImplementedException();
    }
}
