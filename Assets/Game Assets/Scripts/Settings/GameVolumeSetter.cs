using UnityEngine;
using UnityEngine.UI;

public class GameVolumeSetter : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeGameVolume); 
    }

    private void Start()
    {
        _volumeSlider.value = AudioListener.volume;
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeGameVolume);
    }

    private void ChangeGameVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
