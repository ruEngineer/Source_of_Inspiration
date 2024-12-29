using System;
using UnityEngine;

public abstract class TasksBase : MonoBehaviour
{
    public const float MaxPercentOfDoneTask = 100;
    public const float MinPercentOfDoneTask = 0;

    public bool TaskMaybeCompleted;

    [Multiline]
    [SerializeField] private string _tasksTextRu;
    [Multiline]
    [SerializeField] private string _tasksTextEn;
    [SerializeField] private float _taskProgressSpeed;

    [SerializeField] private AudioSource _taskCompletedSound;

    private protected float _percentOfDoneTask;

    public event Action<TasksBase> OnTaskCompleted;
    public event Action<float> OnTaskCompleting;
    public event Action OnTaskStopCompleting;

    private protected virtual void CompleteTask()
    {
        if(_taskCompletedSound != null)
        {
            _taskCompletedSound.Play();
        }
        OnTaskCompleted?.Invoke(this);
    }

    public void InitTask()
    {
        TaskMaybeCompleted = true;
        _percentOfDoneTask = 0;
    }

    public void CompletingTask()
    {
        _percentOfDoneTask = Mathf.Clamp(_percentOfDoneTask, MinPercentOfDoneTask, MaxPercentOfDoneTask);
        
        _percentOfDoneTask += _taskProgressSpeed * Time.fixedDeltaTime;
        OnTaskCompleting?.Invoke(_percentOfDoneTask);
        if(_percentOfDoneTask >= MaxPercentOfDoneTask)
        {
            CompleteTask();
        }
    }

    public void StopCompletingTask()
    {
        OnTaskStopCompleting?.Invoke();
    }

    public bool CheckOnCompletedTask()
    {
        return _percentOfDoneTask < MaxPercentOfDoneTask;
    }

    public string GetTaskText(string language)
    {
        if(_percentOfDoneTask < MaxPercentOfDoneTask)
        {
            if(language == "ru")
                return _tasksTextRu;
            else
                return _tasksTextEn;
        }
        else
        {
            if(language == "ru")
                return $" <s>{_tasksTextRu}</s> ";
            else
                return $" <s>{_tasksTextEn}</s> ";
        }
    }
}
