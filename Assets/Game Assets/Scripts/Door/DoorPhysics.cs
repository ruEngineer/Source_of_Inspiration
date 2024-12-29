using UnityEngine;
using DG.Tweening;

public class DoorPhysics : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    [SerializeField] private Transform _openDoorPosition;

    [SerializeField] private float _doorOpeningLenght;

    public void OpenDoor()
    {
        _door.transform.DOMove(_openDoorPosition.position, _doorOpeningLenght);
    }
}
