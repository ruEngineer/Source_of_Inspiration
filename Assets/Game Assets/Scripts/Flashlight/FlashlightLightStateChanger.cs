using UnityEngine;

public class FlashlightLightStateChanger : MonoBehaviour
{
    [SerializeField] private bool _isFlashlightPickedUp;
    [SerializeField] private Light _flashlight;

    [SerializeField] private AudioSource _flashlightChangeStateSound;

    private bool _isEnabled;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && _isFlashlightPickedUp == true)
        {
            if(_isEnabled == false)
            {
                _isEnabled = true;
                _flashlight.enabled = true;
                _flashlightChangeStateSound.PlayOneShot(_flashlightChangeStateSound.clip);
            }

            else
            {
                _isEnabled = false;
                _flashlight.enabled = false;
                _flashlightChangeStateSound.PlayOneShot(_flashlightChangeStateSound.clip);
            }
        }   
    }

    public void PickUpFlashlight()
    {
        _isFlashlightPickedUp = true;
    }
}
