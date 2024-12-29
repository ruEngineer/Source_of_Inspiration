using UnityEngine;
using TMPro;

public class DeathVisualizer : MonoBehaviour
{
    [SerializeField] private DeathHandler _deathHandler;
    [SerializeField] private GamethroughTimer _timer;

    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private TMP_Text _gamethroughTimer;

    private void OnEnable()
    {
        _deathHandler.PlayersDied += ShowDeathUI;
    }

    private void OnDisable()
    {
        _deathHandler.PlayersDied -= ShowDeathUI;
    }

    private void ShowDeathUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _deathPanel.SetActive(true);
        UpdateUITexts();
    }

    private void UpdateUITexts()
    {
        if(GameLanguage.Instance.GetLanguage() == "en")
            _gamethroughTimer.text = $"Record: {_timer.GetGamethroughTime()}";
        else if(GameLanguage.Instance.GetLanguage() == "ru")
            _gamethroughTimer.text = $"Запись: {_timer.GetGamethroughTime()}";

    }
}
