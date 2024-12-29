using UnityEngine;

public class SettingsPagesManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _settingsPages;

    public void OpenSettingsPage(GameObject page)
    {
        foreach(GameObject settingsPage in _settingsPages)
        {
            settingsPage.SetActive(false);
            if(settingsPage == page)
                settingsPage.SetActive(true);
        }
    }

    public void CloseAllSettingsPage()
    {
        foreach(GameObject settingsPage in _settingsPages)
            settingsPage.SetActive(false);
    }
}
