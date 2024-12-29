using UnityEngine;
using UnityEngine.UI;

public class FullscreenModeSetter : MonoBehaviour
{
    [SerializeField] private Toggle _fullscreenToggle;

    private void OnEnable()
    {
        _fullscreenToggle.onValueChanged.AddListener(SetWindowMode);
    }

    private void OnDisable()
    {
        _fullscreenToggle.onValueChanged.RemoveListener(SetWindowMode);
    }

    private void SetWindowMode(bool isFullscreen)
    {
        if(isFullscreen == true)
            SetFullscreenMod();
        else
            SetWindowedMode();
    }

    private void SetFullscreenMod()
    {
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
    }

    private void SetWindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
