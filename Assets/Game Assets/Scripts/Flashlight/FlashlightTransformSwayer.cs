using UnityEngine;

public class FlashlightTransformSwayer : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Transform _camera;
    private Vector3 _offset; 

    private void Start()
    {
        _offset = transform.position - _camera.position;
    }

    private void Update()
    {
        Vector3 targetPosition = _camera.position + _offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, _rotationSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, _camera.rotation, _rotationSpeed * Time.deltaTime);
    }
}
