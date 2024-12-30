using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionSetter : MonoBehaviour
{
    private Resolution[] _resolution;
    private List<string> _resolutions;
    [SerializeField] private TMP_Dropdown _dropdown;

    private void OnEnable()
    {
        _dropdown.onValueChanged.AddListener(SetResolution);
    }

    private void OnDisable()
    {
        _dropdown.onValueChanged.RemoveListener(SetResolution);
    }

    private void Awake()
    {
        _resolutions = new List<string>();
        _resolution = Screen.resolutions;
        foreach (var resolution in _resolution)
        {
            _resolutions.Add($"{resolution.width} x {resolution.height}  {resolution.refreshRateRatio} Hz");
        }
        _dropdown.ClearOptions();
        _dropdown.AddOptions(_resolutions);
    }

    private void SetResolution(int r)
    {
        Screen.SetResolution(_resolution[r].width, _resolution[r].height, Screen.fullScreen == true);
    }
}
