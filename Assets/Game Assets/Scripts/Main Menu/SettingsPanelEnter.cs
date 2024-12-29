using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class SettingsPanelEnter : MonoBehaviour
{
    [SerializeField] private GameObject _playerUI;

    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private Transform _pcLookTransform;
    [SerializeField] private Vector3 _rotationToPcLook;

    [SerializeField] private Button _settingButton;

    private Vector3 _pcLookVector;

    private void OnEnable()
    {
        _settingButton.AddEventOnClick(RotateAndTransformCameraToSettings);
    }

    private void OnDisable()
    {
        _settingButton.RemoveEventOnClick(RotateAndTransformCameraToSettings);
    }

    private void Start()
    {
        _pcLookVector = _pcLookTransform.position;
    }

    private void RotateAndTransformCameraToSettings()
    {
        _playerUI.SetActive(false);
        _cameraTransform.DOLocalRotate(_rotationToPcLook, 2f);
        _cameraTransform.DOMove(_pcLookVector, 2f, false);
    }
}