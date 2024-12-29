using System;
using System.Globalization;
using System.Threading;
using UnityEngine;

public class GameLanguage : MonoBehaviour
{
    public static GameLanguage instance { get; private set; }

    public static GameLanguage Instance
    {
        get { return instance; }
    }

    private string _language;
    
    public event Action<string> OnLanguageChanged;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
        else if(instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
        if(currentCulture.TwoLetterISOLanguageName == "en")
            SetLanguage("en");
        else if(currentCulture.TwoLetterISOLanguageName == "ru")
            SetLanguage("ru");
    }

    public void SetLanguage(string language)
    {
        if(language == "ru")
            _language = language;
        else if(language == "en")
            _language = language;
        else
            Debug.Log($"Invalid language string - '{language}'");
        OnLanguageChanged?.Invoke(_language);
    }

    public string GetLanguage()
    {
        return _language;
    }
}
 