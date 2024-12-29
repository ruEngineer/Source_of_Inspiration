using System;
using UnityEngine;

public class GameDayHandler : MonoBehaviour
{
    private int _currentDay = 1;

    public event Action<int> OnCurrentDayChanged;

    public void Init()
    {
        OnCurrentDayChanged?.Invoke(1);
    }

    public void StartNextDay()
    {
        _currentDay++;
        OnCurrentDayChanged?.Invoke(_currentDay);
    }
}
