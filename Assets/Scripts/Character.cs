
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] float damage = 0.1f;

    float timeSinceLastMovement = 0f;
    float speedMove = 0.25f;

    void Start()
    {
        
    }

    void Update()
    {
        
        timeSinceLastMovement += Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveToDirection(0.4f, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveToDirection(-0.4f, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveToDirection(0, 0.4f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveToDirection(0, -0.4f);
        }
    }

    void MoveToDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        Vector3 raycastCenter = transform.position;

        if (x > 0)
        {
            direction = Vector2.right;
            raycastCenter.y -= 0.4f / 2;
        }
        if (x < 0)
        {
            direction = Vector2.left;
            raycastCenter.y -= 0.4f / 2;
        }
        if (y > 0)
        {
            direction = Vector2.up;
            raycastCenter.x += 0.4f / 2;
        }
        if (y < 0)
        {
            direction = Vector2.down;
            raycastCenter.x += 0.4f / 2;
        }

        Debug.DrawRay(raycastCenter, direction, Color.cyan);

        RaycastHit2D hit = Physics2D.Raycast(raycastCenter, direction, 0.4f);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            DamageBlock(hit.collider);
        }
        else
        {
            if (timeSinceLastMovement >= speedMove)
            {
                this.transform.Translate(x, y, 0);
                timeSinceLastMovement = 0f;
            }

        }
    }

    void DamageBlock(Collider2D collider)
    {
        collider.GetComponent<Blocks>().AddDamage(damage);
    }
}
