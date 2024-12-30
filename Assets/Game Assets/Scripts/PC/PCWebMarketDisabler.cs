using UnityEngine;
using TMPro;
using DG.Tweening;
using NaughtyAttributes;

public class PCWebMarketDisabler : MonoBehaviour
{
    [Foldout("Канвас")]
    [SerializeField] private Canvas _webMarketCanvas;
    [Foldout("Канвас")]
    [SerializeField] private TMP_Text _interactText;
    [Foldout("Канвас")]
    [SerializeField] private CanvasGroup _webMarketCanvasGroup;

    [Foldout("Камеры")]
    [SerializeField] private Camera _pcCamera;
    [Foldout("Камеры")]
    [SerializeField] private Camera _playerCamera;

    [SerializeField] private PlayerCanMoveStateController _playerStateMoveController;
    [SerializeField] private AudioSource _closePcSound;

    public void CloseShop()
    {
        _playerStateMoveController.UnfreezePlayer();
        _pcCamera.enabled = false;
        _webMarketCanvas.enabled = false;
        _interactText.enabled = true;
        _webMarketCanvasGroup.DOFade(0, 1.0f);
        _playerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _closePcSound.PlayOneShot(_closePcSound.clip);
    }

    private void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.F)) && _webMarketCanvas.enabled == true)
            CloseShop();
    }
}
