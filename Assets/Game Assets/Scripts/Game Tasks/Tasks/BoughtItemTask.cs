using UnityEngine;

public class BoughtItemTask : TasksBase
{
    [SerializeField] private GoodsButtonBought _goodsBoughtButton;

    private void OnEnable()
    {
        _goodsBoughtButton.OnSuccesfulBought += CompleteTask;
    }

    private void OnDisable()
    {
        _goodsBoughtButton.OnSuccesfulBought -= CompleteTask;
    }

    private protected override void CompleteTask()
    {
        _percentOfDoneTask = 100.0f;
        base.CompleteTask();
    }
}
