using UnityEngine;
using DG.Tweening;

public class SpriteRotater : MonoBehaviour
{
    [SerializeField] private RectTransform _transformObject;

    private void Update()
    {
        _transformObject.DORotate(-Vector3.forward * 50f, 1f, RotateMode.WorldAxisAdd)
        .SetLoops(-1)
        .SetEase(Ease.Linear);
    }
}
 