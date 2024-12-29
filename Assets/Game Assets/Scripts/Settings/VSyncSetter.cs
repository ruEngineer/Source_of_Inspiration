using UnityEngine;
using UnityEngine.UI;

public class VSyncSetter : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(SetVSyncType);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveListener(SetVSyncType);
    }

    private void SetVSyncType(bool vsyncEnabled)
    {
        if(vsyncEnabled == true)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
}
