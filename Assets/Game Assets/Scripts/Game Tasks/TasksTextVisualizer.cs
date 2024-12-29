using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksTextVisualizer : MonoBehaviour
{
    [SerializeField] private List<TasksBase> _tasks;
    [SerializeField] private TasksHandler _tasksHandler;
    [SerializeField] private TMP_Text _tasksText;

    [SerializeField] private DayTasks[] _dayTasks;

    private string _language;

    private void Awake()
    {
        _language = GameLanguage.Instance.GetLanguage();
    }

    private void OnEnable()
    {
        foreach(DayTasks dayTasks in _dayTasks)
            dayTasks.OnTaskStateChangedCompleted += () => ChangeTasksText(dayTasks);
        _tasksHandler.OnDayTasksChanged += ChangeTasksText;
    }

    private void OnDisable()
    {
        foreach(DayTasks dayTasks in _dayTasks)
            dayTasks.OnTaskStateChangedCompleted -= () => ChangeTasksText(dayTasks);
        _tasksHandler.OnDayTasksChanged -= ChangeTasksText;
    }

    private void ChangeTasksText(DayTasks dayTasks)
    {
        _tasksText.text = GetAllTasksText(dayTasks);
    }

    public string GetAllTasksText(DayTasks dayTasks)
    {
        string tasksText = "";
        foreach(TasksBase task in dayTasks.GetDayTasks())
        {
            tasksText += task.GetTaskText(_language) + " \n";
        }  

        return tasksText;
    }
}
