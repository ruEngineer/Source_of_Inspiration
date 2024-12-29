using UnityEngine;

public class DeathScreamer : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Camera _screamerCamera;

    [SerializeField] private AudioSource _ambientSound;
    [SerializeField] private AudioSource _screamerSound;

    public void ShowScreamerCamera()
    {
        _ambientSound.Stop();
        _playerCamera.enabled = false;
        _screamerCamera.enabled = true;
        _screamerSound.Play();
    }
}
