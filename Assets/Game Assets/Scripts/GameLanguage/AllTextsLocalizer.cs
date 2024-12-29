using System.Collections.Generic;
using UnityEngine;

public class AllTextsLocalizer : MonoBehaviour
{
    [SerializeField] private GameLanguage _gameLanguage;
    private List<TextLocalizer> _textsWithLocalize;

    private void Start()
    {
        _textsWithLocalize = new List<TextLocalizer>();
        _gameLanguage = FindObjectOfType<GameLanguage>();
        _gameLanguage.OnLanguageChanged += LocalizeAllTextOnScene;
        LocalizeAllTextOnScene(_gameLanguage.GetLanguage());
    }

    private void OnDisable()
    {
        _gameLanguage.OnLanguageChanged -= LocalizeAllTextOnScene;
    }

    public void LocalizeAllTextOnScene(string language)
    {
       GetAllTextsWithLocalize();
        foreach(TextLocalizer text in _textsWithLocalize)
            text.LocalizeText(language);
    }

    private void GetAllTextsWithLocalize()
    {
        _textsWithLocalize = new List<TextLocalizer>();
        _textsWithLocalize.AddRange(FindObjectsOfType<TextLocalizer>(true));
    }
}