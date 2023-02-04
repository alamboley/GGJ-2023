using System.Collections;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float timingBeforeFirstFall = 1.2f;
    [SerializeField] float gravitySpeed = 0.6f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BottomBlockDestroying()
    {
        StartCoroutine(_BottomBlockDestroying());
        IEnumerator _BottomBlockDestroying()
        {
            yield return new WaitForSeconds(timingBeforeFirstFall);

            transform.Translate(0, -0.4f, 0);

            StartCoroutine(CheckBottomAndFall());
        }
    }

    public IEnumerator CheckBottomAndFall()
    {
        Vector3 raycastCenter = transform.position;
        raycastCenter.x += 0.4f / 2;
        raycastCenter.y -= 0.4f + 0.4f / 2;

        Debug.DrawRay(raycastCenter, Vector2.down, Color.cyan);

        RaycastHit2D hit = Physics2D.Raycast(raycastCenter, Vector2.down, 0.4f / 2);
        
        if (hit.collider == null)
        {
            yield return new WaitForSeconds(gravitySpeed);

            transform.Translate(0, -0.4f, 0);

            StartCoroutine(CheckBottomAndFall());
        }
    }
}
