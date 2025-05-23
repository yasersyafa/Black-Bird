public enum QuestType
{
    MainQuest,
    UniqueQuest
}

[System.Serializable]
public class Quest
{
    public QuestType questType;
    public string description;
    public int target; 
    public int currentProgress;
    public bool isCompleted;

    public void UpdateProgress()
    {
        if (isCompleted) return;

        currentProgress++;
        if (currentProgress >= target)
        {
            isCompleted = true;
        }
    }
}
