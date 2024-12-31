using NaughtyAttributes;
using UnityEngine;

public class ScreamerTriggerEnabler : MonoBehaviour
{
    [SerializeField] private Collider _screamerTrigger;
    [SerializeField] private GameDayHandler _gameDayHandler; 

    [MinValue(1), MaxValue(6)]
    [SerializeField] private int _triggerDayActivation;

    private void OnEnable()
    {
        _gameDayHandler.OnCurrentDayChanged += ActivateScriptTrigger;
    }

    private void OnDisable()
    {
        _gameDayHandler.OnCurrentDayChanged -= ActivateScriptTrigger;
    }

    private void ActivateScriptTrigger(int currentDay)
    {
        if(currentDay == _triggerDayActivation)
        {
            _screamerTrigger.enabled = true;
        }
    }
}
