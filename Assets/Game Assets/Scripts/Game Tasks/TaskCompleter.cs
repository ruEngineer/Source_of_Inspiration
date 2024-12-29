using UnityEngine;

public class TaskCompleter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    private TasksBase _raycastedTask;

    private RaycastHit _hit;
    private Ray _ray;

    private void FixedUpdate()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit, 1.25f) && _hit.collider.TryGetComponent(out TasksBase task))
        {
            _raycastedTask = task;
            if(Input.GetKey(KeyCode.E) && (task.CheckOnCompletedTask() == true && task.TaskMaybeCompleted == true))
            {
                task.CompletingTask();
            }
            else
            {
                task.StopCompletingTask();
            }
        }

        else if(_raycastedTask != null)
        {
            _raycastedTask.StopCompletingTask();
        }
    }
}
