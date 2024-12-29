using UnityEngine;
using UnityEngine.UI;

public class ButtonPageSettingsChanger : MonoBehaviour
{
    [SerializeField] private SettingsPagesManager _pagesManager;
    [SerializeField] private GameObject _page;

    private Button _button;

    private void Awake() 
    {
        _button = GetComponent<Button>();    
    }

    private void OnEnable() 
    {
        _button.AddEventOnClick(() => _pagesManager.OpenSettingsPage(_page)); 
    }

    private void OnDisable() 
    {
        _button.RemoveEventOnClick(() => _pagesManager.OpenSettingsPage(_page));    
    }
}
