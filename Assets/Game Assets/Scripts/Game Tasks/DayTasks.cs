using System;
using System.Collections.Generic;
using UnityEngine;

public class DayTasks : MonoBehaviour
{
    [SerializeField] private List<TasksBase> _tasks;    
    private List<TasksBase> _completedTasks;

    public event Action OnTaskStateChangedCompleted;
    public event Action OnAllTasksCompleted;

    private void Awake()
    {
        _completedTasks = new List<TasksBase>();
    }

    private void OnEnable() 
    {
        foreach(TasksBase task in _tasks)
        {
            task.OnTaskCompleted += AddTaskToCompletedTasks;
        }    
    }

    private void OnDisable() 
    {
        foreach(TasksBase task in _tasks)
        {
            task.OnTaskCompleted -= AddTaskToCompletedTasks;
        }    
    }

    private void AddTaskToCompletedTasks(TasksBase task)
    {
        foreach(TasksBase uncompletedTask in _tasks)
        {
            if(uncompletedTask.gameObject.name == task.gameObject.name)
            {
                if(!_completedTasks.Contains(task))
                {
                    OnTaskStateChangedCompleted?.Invoke();
                    _completedTasks.Add(uncompletedTask);
                    uncompletedTask.TaskMaybeCompleted = false;
                }
            }
        }

        CheckOnCompletedAllTasks();
    }

    public bool CheckOnCompletedAllTasks()
    {
        if(_tasks.Count == _completedTasks.Count)
        {
            OnAllTasksCompleted?.Invoke();
            return true;
        }
        return false;
    }

    public void InitDayTasks()
    {
        foreach(TasksBase task in _tasks)
            task.InitTask();
        _completedTasks.Clear();
    }

    public List<TasksBase> GetDayTasks()
    {
        return _tasks;
    }
}
