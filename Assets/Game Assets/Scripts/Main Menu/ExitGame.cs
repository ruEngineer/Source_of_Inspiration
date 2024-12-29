using UnityEngine;
using UnityEngine.UI;

public class ApplicationExiter : MonoBehaviour
{
    private Button _button;

    private void OnEnable() 
    {
        _button = GetComponent<Button>();
        _button.AddEventOnClick(ExitFromGame);
    }

    private void OnDisable() 
    {
        _button.RemoveEventOnClick(ExitFromGame);    
    }

    private void ExitFromGame()
    {
        Application.Quit(1488); 
    }
}
