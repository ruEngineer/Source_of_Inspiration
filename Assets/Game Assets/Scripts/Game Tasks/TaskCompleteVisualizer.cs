using UnityEngine;
using UnityEngine.UI;

public class TaskCompleteVisualizer : MonoBehaviour
{
    [SerializeField] private TasksBase[] _tasks;
    [SerializeField] private Image _circleOfDoneTask;

    private void OnEnable()
    {
        foreach(TasksBase task in _tasks)
        {
            task.OnTaskCompleting += ShowCircleOfDoneTask;
            task.OnTaskStopCompleting += CloseCircleOfDoneTask;
        }
    }

    private void OnDisable()
    {
        foreach(TasksBase task in _tasks)
        {
            task.OnTaskCompleting -= ShowCircleOfDoneTask;
            task.OnTaskStopCompleting -= CloseCircleOfDoneTask;
        }
    }

    private void ShowCircleOfDoneTask(float percentOfDoneTask)
    {
        _circleOfDoneTask.enabled = true;
        _circleOfDoneTask.fillAmount = percentOfDoneTask / 100;
    }

    private void CloseCircleOfDoneTask()
    {
        _circleOfDoneTask.enabled = false;
        _circleOfDoneTask.fillAmount = 0;
    }
}
