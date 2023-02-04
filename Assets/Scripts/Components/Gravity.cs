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

            ChainGravityWithUp();

            Vector3 raycastCenter = transform.position;
            raycastCenter.x += 0.4f / 2;
            raycastCenter.y -= 0.4f + 0.4f / 2;

            Debug.DrawRay(raycastCenter, Vector2.down, Color.cyan);

            RaycastHit2D hit = Physics2D.Raycast(raycastCenter, Vector2.down, 0.4f / 2);

            if (hit.collider != null)
            {
                Character character = hit.collider.GetComponent<Character>();
                if (character != null)
                {
                    Debug.Log("GAME OVER crushed 1");

                    GameManager.Instance.GameOver();
                    FindObjectOfType<Character>().canMove = false;
                }
            }

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
        else
        {
            Character character = hit.collider.GetComponent<Character>();
            if (character != null)
            {
                yield return new WaitForSeconds(gravitySpeed);

                Debug.Log("GAME OVER crushed");

                GameManager.Instance.GameOver();
                FindObjectOfType<Character>().canMove = false;

                transform.Translate(0, -0.4f, 0);

                StartCoroutine(CheckBottomAndFall());
            }
        }
    }

    public void ChainGravityWithUp()
    {
        Vector3 raycastCenter = transform.position;
        raycastCenter.x += 0.4f / 2;
        raycastCenter.y += 0.4f;

        Debug.DrawRay(raycastCenter, Vector2.up, Color.cyan);

        RaycastHit2D hit = Physics2D.Raycast(raycastCenter, Vector2.up, 0.4f / 2);

        if (hit.collider != null)
        {
            //Debug.Log("me :" + gameObject.name);
            //Debug.Log("hit : " + hit.collider.gameObject.name);
            Gravity gravityBlock = hit.collider.GetComponent<Gravity>();

            if (gravityBlock != null)
            {
                gravityBlock.BottomBlockDestroying();
            }
        }
    }
}
