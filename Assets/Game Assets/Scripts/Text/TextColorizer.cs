using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TextColorizer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color _colorToColorize = Color.red;
    
    private TMP_Text _textFieldInput;
    private string _startText;
    private Color _startTextColor;

    [SerializeField] private string _textOnColorized;
    

    private void Start()
    {
        _textFieldInput = GetComponent<TMP_Text>();
        _startTextColor = _textFieldInput.color;
        _startText = _textFieldInput.text;
    }

    private void OnDisable()
    {
        ReturnTextParameters();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _startText = _textFieldInput.text;
        _textFieldInput.color = _colorToColorize;
        if(String.IsNullOrEmpty(_textOnColorized) == false)
            _textFieldInput.text = $"{_textOnColorized} {_textFieldInput.text}";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ReturnTextParameters();
    }

    private void ReturnTextParameters()
    {
        _textFieldInput.text = _startText;
        _textFieldInput.color = _startTextColor;
    }
}
