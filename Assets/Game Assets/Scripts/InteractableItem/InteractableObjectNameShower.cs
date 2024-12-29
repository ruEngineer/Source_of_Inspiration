using TMPro;
using UnityEngine;

public class InteractableObjectNameShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _textObjectName;

    [SerializeField] private ObjectInteractor _objectInteractor;

    private void OnEnable()
    {
        _objectInteractor.OnInteractWithObject += ShowTextWithObjectName;
        _objectInteractor.OnStopInteractWithObject += ClearObjectNameText;
    }
    
    private void OnDisable()
    {
        _objectInteractor.OnInteractWithObject -= ShowTextWithObjectName;
        _objectInteractor.OnStopInteractWithObject -= ClearObjectNameText;
    }

    private void ShowTextWithObjectName(string interactObjectText)
    {
        _textObjectName.text = interactObjectText;
    }

    private void ClearObjectNameText()
    {
        _textObjectName.text = "";
    }
}
