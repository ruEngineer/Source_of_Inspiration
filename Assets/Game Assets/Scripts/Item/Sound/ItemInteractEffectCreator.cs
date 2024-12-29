using UnityEngine;

public class ItemInteractEffectCreator : MonoBehaviour
{
    [SerializeField] private AudioSource _sourceToPlay;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude >= 5.0f)
        {
            _sourceToPlay.PlayOneShot(_sourceToPlay.clip);
        }
    }
}