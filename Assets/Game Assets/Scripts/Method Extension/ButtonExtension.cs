using UnityEngine.Events;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventOnClick(this Button button, UnityAction action)
        => button.onClick.AddListener(action);

    public static void RemoveEventOnClick(this Button button, UnityAction action)
        => button.onClick.RemoveListener(action);

    public static void RemoveAllEventsOnClick(this Button button)
        => button.onClick.RemoveAllListeners();
}
