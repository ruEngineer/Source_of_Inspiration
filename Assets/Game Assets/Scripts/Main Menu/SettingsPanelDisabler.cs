using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsPanelDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;

    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Transform _defaultLookTransform;
    [SerializeField] private Vector3 _defaultRotation;

    [SerializeField] private Button _exitButton;

    private Vector3 _defaultLookVector;

    private void OnEnable()
    {
        _exitButton.AddEventOnClick(RotateAndTransformCameraToSettings);
    }

    private void OnDisable()
    {
        _exitButton.RemoveEventOnClick(RotateAndTransformCameraToSettings);
    }

    private void Start()
    {
        _defaultLookVector = _defaultLookTransform.position;
    }

    private void RotateAndTransformCameraToSettings()
    {
        _cameraTransform.DOLocalRotate(_defaultRotation, 2f);
        _cameraTransform.DOMove(_defaultLookVector, 2f, false).OnComplete(OpenPlayerUI);
    }

    private void OpenPlayerUI()
    {
        _playerUI.SetActive(true);
    }
}
