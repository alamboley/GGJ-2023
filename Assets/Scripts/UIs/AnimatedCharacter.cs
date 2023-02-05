using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedCharacter : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Sprite[] sprites;

    Tween tween;
    void Start()
    {
        ShowFrame1();
    }

    private void OnDestroy()
    {
        tween.Kill();
    }

    void ShowFrame1()
    {
        image.sprite = sprites[0];

        tween = DOVirtual.DelayedCall(0.4f, ShowFrame2);
    }

    void ShowFrame2()
    {
        image.sprite = sprites[1];

        tween = DOVirtual.DelayedCall(0.4f, ShowFrame1);
    }
}
