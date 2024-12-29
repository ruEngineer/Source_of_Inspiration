using UnityEngine;

public class KeycardReader : MonoBehaviour
{
    [SerializeField] private DoorPhysics _door;

    [SerializeField] private AudioSource _accessGrantedSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Keycard keycard))
        {
            ReadKeycard(keycard);
            _accessGrantedSound.Play();
            Destroy(this);
        }
    }

    private void ReadKeycard(Keycard keycard)
    {
        if(keycard != null)
            _door.OpenDoor();
    }
}
