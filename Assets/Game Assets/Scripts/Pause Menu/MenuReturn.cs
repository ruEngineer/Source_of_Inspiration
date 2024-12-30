using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuReturn : MonoBehaviour
{
    [SerializeField] private Button _buttonToReturn;

    [Scene]
    [SerializeField] private string _sceneToReturn;

    private void OnEnable()
    {
        _buttonToReturn.AddEventOnClick(ReturnToMenu);
    }

    private void OnDisable()
    {
        _buttonToReturn.RemoveEventOnClick(ReturnToMenu);
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(_sceneToReturn);
    }
}
