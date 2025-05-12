
namespace Scripts.Core.Utils.StateMachine
{
    using UnityEngine;

    public interface IState<T>
    {
        void Enter(T context);
        void Execute(T context);
        void Exit(T context);
    }
}
