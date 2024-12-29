using System;
using UnityEngine;


public class ObjectInteractor : MonoBehaviour 
{
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit; 

    private string _language;

    public event Action<string> OnInteractWithObject;
    public event Action OnStopInteractWithObject;

    private void Start()
    {
        _language = GameLanguage.Instance.GetLanguage();
    }

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(_ray, out _hit, 1.5f) && _hit.collider.TryGetComponent(out IInteractable interactable))
        {       
            OnInteractWithObject?.Invoke(interactable.GetInteractObjectName(_language));

            if(Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
        else
        {
            OnStopInteractWithObject?.Invoke();
        }
    }   
}
