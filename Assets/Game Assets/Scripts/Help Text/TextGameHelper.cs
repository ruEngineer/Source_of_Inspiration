using UnityEngine;
using TMPro;
using System.Collections;

public class TextGameHelper : MonoBehaviour
{
    [SerializeField] private TMP_Text _helpText;

    [SerializeField] private FlashlightItem _flashlight;
    [SerializeField] private GoodsButtonBought _goodsBoughtButton;

    private void OnEnable()
    {
        _flashlight.OnFlashlightTaking += OnFlashlightTakenHelp;
        _goodsBoughtButton.OnSuccesfulBought += OnGoodsBoughtHelp;
    }

    private void OnDisable()
    {
        _flashlight.OnFlashlightTaking -= OnFlashlightTakenHelp;
        _goodsBoughtButton.OnSuccesfulBought -= OnGoodsBoughtHelp;
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

    private void OnGoodsBoughtHelp()
    {
        if(GameLanguage.Instance != null && GameLanguage.Instance.GetLanguage() == "ru")
        {
            SetHelpText(" Забрать заказанные товары ты сможешь у входа в бункер, недалеко от дырки в крыше ", 5.0f);
        }

        else
        {
            SetHelpText(" You can pick up the ordered goods at the entrance to the bunker, near the hole in the roof ", 5.0f);
        }
    }

    private void SetHelpText(string text, float delay = 2.0f)
    {
        StopCoroutine(ClearTextByDelay());
        _helpText.text = $"{text}";
        StartCoroutine(ClearTextByDelay(delay));
    }

    IEnumerator ClearTextByDelay(float delay = 2.0f)
    {
        yield return new WaitForSeconds(delay);
        _helpText.text = "";
    }
}
