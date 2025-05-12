namespace Scripts.Core.Utils.StateMachine
{
    using UnityEngine;

    public class StateMachine<T>
    {
        private IState<T> _currentState;
        private T _context;

        public StateMachine(T context)
        {
            _context = context;
        }

        public void ChangeState(IState<T> newState)
        {
            _currentState?.Exit(_context);
            _currentState = newState;
            _currentState?.Enter(_context);
        }

        public void Update()
        {
            _currentState?.Execute(_context);
        }
    }
}