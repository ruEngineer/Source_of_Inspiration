using UnityEngine;

public class CameraDropper : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _ragdolledCamera;
    [SerializeField] private Rigidbody _cameraRigidbody;
    [SerializeField] private PlayerCanMoveStateController _character;
    [SerializeField] private ExplosionEffect _explosionEffect;

    private void OnEnable()
    {
        _explosionEffect.OnStartingExploding += DropCamera;
        _explosionEffect.OnExploded += ReturnCamera;
    }

    private void OnDisable()
    {
        _explosionEffect.OnStartingExploding -= DropCamera;
        _explosionEffect.OnExploded -= ReturnCamera;
    }

    public void DropCamera()
    {
        _ragdolledCamera.transform.position = _playerCamera.transform.position;
        _playerCamera.enabled = false;
        _ragdolledCamera.SetActive(true);
        _cameraRigidbody.AddForce(Vector3.up * 250.0f, ForceMode.Force);
        _cameraRigidbody.AddForce(Vector3.left * 250.0f, ForceMode.Force);
        _character.FreezePlayer();
    }

    public void ReturnCamera()
    {
        _playerCamera.enabled = true;
        _ragdolledCamera.SetActive(false);
        _character.UnfreezePlayer();
    }
}
