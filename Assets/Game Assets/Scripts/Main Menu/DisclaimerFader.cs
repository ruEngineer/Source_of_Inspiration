using System.Collections;
using UnityEngine;
using DG.Tweening;

public class DisclaimerFader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start() 
    {
        StartCoroutine(FadeDisclaimer());
    }

    IEnumerator FadeDisclaimer()
    {
        yield return new WaitForSeconds(1);
        _canvasGroup.DOFade(0, 1.0f);
        yield return new WaitForSeconds(1);
        Destroy(_canvasGroup.gameObject);
    }
}
