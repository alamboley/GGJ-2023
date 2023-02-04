using DG.Tweening;
using System.Collections;
using UnityEngine;

public class RootsAnimation : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1;

    void Awake()
    {
        Color alpha = new Color(1, 1, 1, 0);
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().color = alpha;
        }
    }

    void Start()
    {
        AnimateRoots(0);
    }

    void AnimateRoots(int position)
    {
        if (position == transform.childCount)
        {
            Debug.Log("roots completed");
        }
        else
        {
            transform.GetChild(position).GetComponent<SpriteRenderer>().DOFade(1, fadeSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                DOVirtual.DelayedCall(fadeSpeed, () => AnimateRoots(position + 1));
            });
        }
    }
}
