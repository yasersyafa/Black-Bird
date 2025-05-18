using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Core.EventSystem
{
    public static class EventBus
    {
        public static event Action<GameState> OnStateChanged;
        public static event Action OnPipePassed;
        public static event Action<float> OnGameUpdate;
        public static event Action OnQuestInitiated;
        public static event Action<string> OnQuestCompleted;

        public static void PublishGameState(GameState newState) =>
            OnStateChanged?.Invoke(newState);

        public static void PublishPipePassed() =>
            OnPipePassed?.Invoke();

        public static void PublishGameUpdate(float deltaTime) =>
            OnGameUpdate?.Invoke(deltaTime);

        public static void PublishQuestInitiated() =>
            OnQuestInitiated?.Invoke();
        public static void PublishQuestCompleted(string questId) =>
            OnQuestCompleted?.Invoke(questId);
       
    }

    public enum GameState
    {
        Waiting,
        Playing,
        GameOver,
    }
}
