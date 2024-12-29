using System;
using UnityEngine;

public class GamethroughTimer : MonoBehaviour
{
    private float _startTime;

    private int _hours;
    private int _minutes;
    private int _seconds;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        float timeElapsed = Time.time - _startTime; 
            
        _hours = Mathf.FloorToInt(timeElapsed / 3600); 
        _minutes = Mathf.FloorToInt((timeElapsed % 3600) / 60); 
        _seconds = Mathf.FloorToInt(timeElapsed % 60);
    }

    public String GetGamethroughTime()
    {
        return string.Format("{0:D2}:{1:D2}:{2:D2}", _hours, _minutes, _seconds);
    }
}
