using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NaughtyAttributes;
using System.Collections;
using TMPro;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private TMP_Text _loadingPercentText;

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
        StartCoroutine(LoadingAsyncScene());
    }

    IEnumerator LoadingAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_mainGameScene);; 
        asyncLoad.allowSceneActivation = false;


        if(_loadingScreen != null)
            _loadingScreen.SetActive(true);

        while (!asyncLoad.isDone)
        {
            if(_loadingPercentText != null)
                _loadingPercentText.text = $"{asyncLoad.progress * 100}%";

            if (asyncLoad.progress >= 0.9f)
            {
                if(_loadingPercentText != null)
                {
                    if(GameLanguage.Instance.GetLanguage() == "ru")
                    {
                        _loadingPercentText.text = "Нажми любую кнопку без промаха...";
                    }

                    else
                    {
                        _loadingPercentText.text = "Press any key to continue...";
                    }
                }
                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}