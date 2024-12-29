using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BedInteractVisualizer : MonoBehaviour
{
    [SerializeField] private Bed _bed;
    [SerializeField] private CanvasGroup _sleepScreen;

    private void OnEnable()
    {
        _bed.OnStartSleeping += ShowSleepScreen;
        _bed.OnSlept += HideSleepScreen;
    }

    private void OnDisable()
    {
        _bed.OnStartSleeping -= ShowSleepScreen;
        _bed.OnSlept -= HideSleepScreen;
    }

    private void ShowSleepScreen()
    {
        _sleepScreen.gameObject.SetActive(true);
        _sleepScreen.DOFade(1, 2f);
    }

    private void HideSleepScreen()
    {
        StartCoroutine(HideSleepScreenWithDelay());
        _sleepScreen.DOFade(0, 1.5f);
    }

    IEnumerator HideSleepScreenWithDelay()
    {
        yield return new WaitForSeconds(2f);
        _sleepScreen.gameObject.SetActive(false);
    }
}
