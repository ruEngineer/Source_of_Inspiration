using UnityEngine;
using NaughtyAttributes;

public class ScreamerObjectThrower : MonoBehaviour
{
    [SerializeField] private GameObject _objectToThrow;

    [MinValue(-1), MaxValue(1)]
    [SerializeField] private Vector3 _throwVector;

    [SerializeField] private float _throwPower;

    [SerializeField] private AudioSource _screameSound;

    private void OnTriggerEnter(Collider other)
    {
        if(_screameSound != null)
            _screameSound.Play();
        _objectToThrow.transform.parent = null;
        _objectToThrow.SetActive(true);
        _objectToThrow.GetComponent<Rigidbody>().AddForce(_throwVector * _throwPower);
        Destroy(gameObject);
    }
}
