using UnityEngine;
using DG.Tweening;

public class LightFlicker : MonoBehaviour
{
    [Range(0.1f, 2.0f)]
    [SerializeField] private float _delayToFlick;

    [Range(0, 0.5f)]
    [SerializeField] private float _minTimeToFlick;
    
    [Range(0, 0.5f)]
    [SerializeField] private float _maxTimeToFlick;

    [Range(0, 2)]
    [SerializeField] private float _minIntensityLight;

    [Range(0, 2)]
    [SerializeField] private float _maxIntensityLight;

    [SerializeField] private Renderer _materialLight;

    private Light _light;
    
    private float _timeToNextFlick;

    private void Start() 
    {
        _light = GetComponent<Light>();    
    }

    private void Update() 
    {
        if(Time.time >= _timeToNextFlick)
        {
            float intensityForLight = Random.Range(_minIntensityLight, _maxIntensityLight);
            float timeToFlick = Random.Range(_minTimeToFlick, _maxTimeToFlick);

            _light.DOIntensity(intensityForLight, timeToFlick);

            _timeToNextFlick = Time.time + _delayToFlick;
        }
    }

    private void OnValidate() 
    {
        if(_minTimeToFlick > _maxTimeToFlick)
            _minTimeToFlick = _maxTimeToFlick - 0.01f;
        if(_minIntensityLight > _maxIntensityLight)
            _minIntensityLight = _maxIntensityLight - 0.01f;
    }
}
