using System;
using System.Collections;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionParticle;
    [SerializeField] private AudioSource _earthquakeSound;
    [SerializeField] private AudioSource _boomSound;

    public event Action OnStartingExploding;
    public event Action OnExploded;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<SodaCan>())
        {
            StartCoroutine(StartEarthquake());
            Destroy(collider.gameObject);
            Destroy(gameObject.GetComponent<Collider>());
        }
    }

    IEnumerator StartEarthquake()
    {
        _earthquakeSound.Play();
        yield return new WaitForSeconds(5f);
        OnStartingExploding?.Invoke();
        _explosionParticle.Play();
        _boomSound.Play();
        _earthquakeSound.Stop();
        yield return new WaitForSeconds(5f);
        OnExploded?.Invoke();
        Destroy(gameObject);
    }
}
