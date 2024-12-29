using System;
using UnityEngine;

public class FlashlightItem : MonoBehaviour, IInteractable
{
    [SerializeField] private FlashlightLightStateChanger _flashlightStateChanger;
    [SerializeField] private AudioSource _takeSound;

    [SerializeField] private string _ruText;
    [SerializeField] private string _enText;

    public event Action OnFlashlightTaking;

    public string GetInteractObjectName(string language)
    {
        if(language == "ru")
            return _ruText;
        else
            return _enText; 
    }

    public void Interact()
    {
        OnFlashlightTaking?.Invoke();
        _flashlightStateChanger.PickUpFlashlight();
        _takeSound.PlayOneShot(_takeSound.clip);
        Destroy(gameObject);
    }
}
