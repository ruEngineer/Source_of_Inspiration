using UnityEngine;

public class EntryPointHandler : MonoBehaviour
{
    [SerializeField] private GameDayHandler _gameDayHandler;
    [SerializeField] private MarketItemSlot[] _marketSlots;

    private void Start()
    {
        Time.timeScale = 1;
        _gameDayHandler.Init();

        foreach(MarketItemSlot marketItemSlot in _marketSlots)
        {
            marketItemSlot.Init();
        }

    }
}
