using DG.Tweening;
using UnityEngine;

public class ItemGrabber : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _offsetPosition;
    private float _magnitPower = 18.0f;
    private float _throwPower = 5.0f;   
    [SerializeField] private float _rayDistance = 2.5f;  
    private bool _isGrabbed = false;    
    private RaycastHit _hit;

    private Rigidbody _rigidbodyTakenObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out _hit, _rayDistance);

            if(_hit.rigidbody)
            {
                if(_isGrabbed == false)
                {
                    _rigidbodyTakenObject = _hit.rigidbody;
                    Grab();
                }

                else if(_isGrabbed == true || _rigidbodyTakenObject != null)
                {
                    PutItem();
                }
            }
            Debug.Log($"{_isGrabbed}: grabbed status");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (_isGrabbed == true)
            {
                Throw();
            }
        }  

        if(_isGrabbed == true && _rigidbodyTakenObject != null)
            TransformObjectToGrabPoint();
    }

    private void Grab()
    {
        TransformObjectToGrabPoint();
        _isGrabbed = true;
    }

    private void TransformObjectToGrabPoint()
    {
        _rigidbodyTakenObject.velocity = (_offsetPosition.position - (_hit.transform.position + _hit.rigidbody.centerOfMass)) * _magnitPower;
        _rigidbodyTakenObject.angularVelocity = Vector3.zero;
        //_rigidbodyTakenObject.transform.DORotate(Vector3.zero, 0.25f);
        _rigidbodyTakenObject.transform.DOLookAt(_camera.transform.position, 0.1f);
    }

    private void Throw()
    {
        _isGrabbed = false;
        _rigidbodyTakenObject.velocity = _camera.ScreenPointToRay(Input.mousePosition).direction * _throwPower;
        _rigidbodyTakenObject = null;
    }

    private void PutItem()
    {
        _isGrabbed = false;
        _rigidbodyTakenObject = null;
    }
}
