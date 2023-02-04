using DG.Tweening;
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
            transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().color = alpha;
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
            transform.GetChild(position).GetChild(0).GetComponent<SpriteRenderer>().DOFade(1, fadeSpeed).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.GetChild(position).GetComponent<SpriteRenderer>().DOFade(1, fadeSpeed).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Vector2 direction = Vector2.right;

                    Vector3 raycastCenter = transform.GetChild(position).position;

                    if (transform.GetChild(position).rotation.eulerAngles.z > 5 && transform.GetChild(position).rotation.eulerAngles.z < 250)
                    {
                        raycastCenter.x += 0.4f / 2;
                        raycastCenter.y += 0.4f / 2;
                    }
                    else if (transform.GetChild(position).rotation.eulerAngles.z >= 250 && transform.GetChild(position).rotation.eulerAngles.z < 350)
                    {
                        direction = Vector2.left;

                        raycastCenter.x -= 0.4f / 2;
                        raycastCenter.y -= 0.4f / 2;
                    }
                    else
                    {
                        raycastCenter.x += 0.4f / 2;
                        raycastCenter.y -= 0.4f / 2;
                    }

                    Debug.DrawRay(raycastCenter, direction, Color.cyan);

                    RaycastHit2D hit = Physics2D.Raycast(raycastCenter, direction, 0.4f / 5);
                    if (hit.collider == null)
                    {
                        AnimateRoots(position + 1);
                    }
                    else
                    {
                        Blocks block = hit.collider.GetComponent<Blocks>();
                        if (block != null)
                        {
                            Debug.Log("GAME OVER roots hit block");
                        }
                    }
                });
            });
        }
    }
}
