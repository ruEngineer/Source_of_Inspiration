using UnityEngine;
using TMPro;
using System.Collections;

public class TextGameHelper : MonoBehaviour
{
    [SerializeField] private TMP_Text _helpText;

    [SerializeField] private FlashlightItem _flashlight;

    private void OnEnable()
    {
        _flashlight.OnFlashlightTaking += OnFlashlightTakenHelp;
    }

    private void OnDisable()
    {
        _flashlight.OnFlashlightTaking -= OnFlashlightTakenHelp;
    }

    private void OnFlashlightTakenHelp()
    {
        if(GameLanguage.Instance != null && GameLanguage.Instance.GetLanguage() == "ru")
        {
            SetHelpText(" Для того чтобы включить фонарик нажми <color=red>'F'</color> ");
        }

        else
        {
            SetHelpText(" To turn on the flashlight press <color=red>'F'</color> ");
        }
    }

    private void SetHelpText(string text)
    {
        _helpText.text = $"{text}";
        StartCoroutine(ClearTextByDelay());
    }

    IEnumerator ClearTextByDelay()
    {
        yield return new WaitForSeconds(2f);
        _helpText.text = "";
    }
}
