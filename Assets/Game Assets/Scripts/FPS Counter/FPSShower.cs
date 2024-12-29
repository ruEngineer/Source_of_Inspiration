using System.Collections;
using UnityEngine;
using TMPro;

public class FPSShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _fpsText;

    private void Start()
    {
        StartCoroutine(ShowFPS());
    }

    IEnumerator ShowFPS()
    {
        while (true)
        {
            _fpsText.text = $"{(int) (1f / Time.deltaTime)}";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
