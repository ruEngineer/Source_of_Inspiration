using UnityEngine;
using UnityEngine.UI;
using SUPERCharacter;

public class SensivitySlider : MonoBehaviour
{
    [SerializeField] private SUPERCharacterAIO _character;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _slider.value = _character.Sensitivity;
    }

    private void Update()
    {
        _character.Sensitivity = _slider.value;
    } 
}
