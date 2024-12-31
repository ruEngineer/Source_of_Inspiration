using System.Collections;
using UnityEngine;
using SUPERCharacter;

public class CameraDropperTrigger : MonoBehaviour
{
    [SerializeField] private CameraDropper _cameraDropper;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<SUPERCharacterAIO>())
        {
            _cameraDropper.DropCamera();
            StartCoroutine(ReturnCameraAfetrDelay(5.0f));
        }
    }

    IEnumerator ReturnCameraAfetrDelay(float delay = 5.0f)
    {
        yield return new WaitForSeconds(delay);
        _cameraDropper.ReturnCamera();
        Destroy(this);
    }
}