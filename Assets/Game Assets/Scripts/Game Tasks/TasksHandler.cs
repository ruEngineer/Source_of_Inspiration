using System;
using UnityEngine;

public class TasksHandler : MonoBehaviour
{
    public bool CurrentDayTasksCompleted { private set; get; }

    [SerializeField] private GameDayHandler _gameDayHandler;
    [SerializeField] private DayTasks[] _dayTasks;
    [SerializeField] private DayTasks _currentDayTasks;

    public event Action<DayTasks> OnDayTasksChanged;
    public event Action OnCurrentDayTasksCompleted;

    private void OnEnable()
    {
        _gameDayHandler.OnCurrentDayChanged += ChangeDayTasks;
    }

    private void OnDisable()
    {
        _gameDayHandler.OnCurrentDayChanged -= ChangeDayTasks;
        foreach(DayTasks dayTasks in _dayTasks)
            dayTasks.OnAllTasksCompleted -= ChangeTasksCompletedState;
    }

    private void ChangeDayTasks(int currentDay)
    {
        if(currentDay != 6)
        {
            _currentDayTasks = _dayTasks[currentDay - 1];
            _currentDayTasks.enabled = true;
            _currentDayTasks.OnAllTasksCompleted += ChangeTasksCompletedState;
            _currentDayTasks.InitDayTasks();
        }

        foreach(DayTasks dayTasks in _dayTasks)
            if(dayTasks != _currentDayTasks)
                dayTasks.enabled = false;

        OnDayTasksChanged?.Invoke(_currentDayTasks);
    }

    private void ChangeTasksCompletedState()
    {
        OnCurrentDayTasksCompleted?.Invoke();
    }
}
