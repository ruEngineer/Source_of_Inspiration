using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameLanguageChanger : MonoBehaviour
{
    [SerializeField] private string _language;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.AddEventOnClick(ChangeLanguage);
    }

    private void OnDisable()
    {
        _button.RemoveEventOnClick(ChangeLanguage);
    }

    private void ChangeLanguage()
    {
        GameLanguage.Instance.SetLanguage(_language);
    }
}
