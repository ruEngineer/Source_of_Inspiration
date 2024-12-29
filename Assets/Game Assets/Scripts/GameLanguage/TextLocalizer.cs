using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TextLocalizer : MonoBehaviour
{
    [Multiline]
    [SerializeField] private string _ruText;
    [Multiline]
    [SerializeField] private string _enText;

    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void LocalizeText(string language)
    {
        if(language == "ru")
            _text.text = _ruText;
        else if(language == "en")
            _text.text = _enText;
    }
}
