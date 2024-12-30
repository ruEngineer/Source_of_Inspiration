using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private PlayerCanMoveStateController _playerMoveState;

    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.AddEventOnClick(ClosePauseMenu);
    }

    private void OnDisable()
    {
        _exitButton.RemoveEventOnClick(ClosePauseMenu);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !_pauseMenu.activeInHierarchy)
        {
            OpenPauseMenu();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && _pauseMenu.activeInHierarchy)
        {
            ClosePauseMenu();
        }
    }

    private void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _playerMoveState.FreezePlayer();
        Time.timeScale = 0;
    }

    private void ClosePauseMenu()
    {
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _playerMoveState.UnfreezePlayer();
        Time.timeScale = 1;
    }
}
