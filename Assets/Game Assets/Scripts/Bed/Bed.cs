using System;
using System.Collections;
using UnityEngine;

public class Bed : InteractableObject, IInteractable
{
    [SerializeField] private GameDayHandler _gameDayHandler;
    [SerializeField] private TasksHandler _tasksHandler;

    [SerializeField] private PlayerCanMoveStateController _playerFreezer;

    private bool _canSleep;

    public event Action OnStartSleeping;
    public event Action OnSlept;

    private void OnEnable()
    {
        _tasksHandler.OnCurrentDayTasksCompleted += ChangeCanSleepState;
    }

    private void OnDisable()
    {
        _tasksHandler.OnCurrentDayTasksCompleted -= ChangeCanSleepState;
    }

    public override void Interact()
    {
        if(_canSleep == true)
        {
            _playerFreezer.FreezePlayer();
            OnStartSleeping?.Invoke();
            _canSleep = false;
            StartCoroutine(StopSleeping());
        }
    }

    private void ChangeCanSleepState()
    {
        _canSleep = true;
    }

    IEnumerator StopSleeping()
    {
        yield return new WaitForSeconds(2.5f);
        _playerFreezer.UnfreezePlayer();
        _gameDayHandler.StartNextDay();
        OnSlept?.Invoke();
    }
}
