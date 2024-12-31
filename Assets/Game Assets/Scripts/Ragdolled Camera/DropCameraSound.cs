using UnityEngine;

public class DropCameraSound : MonoBehaviour
{
    [SerializeField] private AudioSource _dropSound;

    private void OnCollisionEnter(Collision other)
    {
        _dropSound.Play();
    }
}
