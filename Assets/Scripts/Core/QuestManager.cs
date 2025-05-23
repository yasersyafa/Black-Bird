using UnityEngine;
using System.Collections.Generic;
using Scripts.Core.EventSystem;



public class QuestManager : MonoBehaviour
{
    public List<Quest> mainQuests;
    public List<Quest> uniqueQuests;
    private void OnEnable()
    {
        EventBus.OnPipePassed += HandlePipePassed;
        // EventBus.OnScreenTapped += HandleScreenTapped;
    }

    private void OnDisable()
    {
        EventBus.OnPipePassed -= HandlePipePassed;
        // EventBus.OnScreenTapped -= HandleScreenTapped;
    }
    private void HandlePipePassed()
    {
        foreach (var quest in mainQuests)
        {
            if (!quest.isCompleted)
                quest.UpdateProgress();
        }
    }

    private void HandleScreenTapped()
    {
        foreach (var quest in uniqueQuests)
        {
            if (!quest.isCompleted)
                quest.UpdateProgress();
        }
    }
}