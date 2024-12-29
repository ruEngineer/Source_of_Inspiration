using UnityEngine;

public class GarbageTask : TasksBase
{
    [SerializeField] private GameObject _monster;

    private protected override void CompleteTask()
    {
        base.CompleteTask();
        _monster.SetActive(true);
    }
}
