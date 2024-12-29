using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private Button _button;

    [Scene] 
    [SerializeField] private string _mainGameScene;

    private void OnEnable()
    {
        _button.AddEventOnClick(GoToGame);
    }

    private void OnDisable()
    {
        _button.RemoveEventOnClick(GoToGame);
    }

    private void GoToGame()
    {
        SceneManager.LoadScene(_mainGameScene);
    }
}
