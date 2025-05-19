using Scripts.Core.EventSystem;
using Scripts.Core.Utils.StateMachine;
using UnityEngine;

namespace Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        private StateMachine<GameManager> _stateMachine;
        public bool IsGameOver { get; private set; }

        [SerializeField] private UIManager _uiManager;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _stateMachine = new StateMachine<GameManager>(this);
            ChangeState(GameState.Waiting, new Waiting());
        }

        // Update is called once per frame
        void Update()
        {
            _stateMachine?.Update();
        }

        public void ChangeState(GameState newStateEnum, IState<GameManager> newState)
        {
            _stateMachine.ChangeState(newState);
            EventBus.PublishGameState(newStateEnum);
        }

        

        public void ShowUIMainMenu()
        {
            // Show the main menu UI
            // _uiManager.ShowMainMenu();
        }

        public void ShowUIGameOver()
        {
            // Show the game over UI
            // _uiManager.ShowGameOver();
        }
        public void ShowUIPlaying()
        {
            // Show the playing UI
            // _uiManager.ShowPlaying();
        }
    }
}
