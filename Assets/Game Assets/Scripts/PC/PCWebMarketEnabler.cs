using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;
using TMPro;

public class PCWebMarketEnabler : InteractableObject, IInteractable
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

    [SerializeField] private AudioSource _openPC;

    public override void Interact()
    {
        OpenWebMarket();
    }

    private void OpenWebMarket()
    {
        if(_webMarketCanvas.enabled == false)
        {
            _openPC.Play();
            _playerStateMoveController.FreezePlayer();
            _pcCamera.enabled = true;
            _webMarketCanvas.enabled = true;
            _interactText.enabled = false;
            _webMarketCanvasGroup.DOFade(1, 1.0f);
            _playerCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}