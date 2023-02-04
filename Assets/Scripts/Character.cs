
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    [SerializeField] float damage = 0.1f;

    float _timeSinceLastMovement = 0f;
    float _speedMove = 0.25f;

    Blocks _hitBlock;

    public bool canMove = true;

    void Start()
    {
        damage += damage * GameManager.Instance.abilities.FindAll(x => x == ItemType.Wolverine).Count / 100;
    }

    void Update()
    {
        if (!canMove)
            return;

        _timeSinceLastMovement += Time.deltaTime;

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
        else
        {
            animator.SetBool("isDigging", false);
        }
    }

    void MoveToDirection(float x, float y)
    {
        Vector2 direction = Vector2.zero;
        Vector3 raycastCenter = transform.position;

        if (x > 0)
        {
            direction = Vector2.right;
            raycastCenter.x += 0.4f / 2 + 0.4f;
            raycastCenter.y -= 0.4f / 2;

            sprite.flipX = false;

            animator.SetBool("isDiggingUp", false);
            animator.SetBool("isDiggingDown", false);
        }
        else if (x < 0)
        {
            direction = Vector2.left;
            raycastCenter.x += 0.4f / 2 - 0.4f;
            raycastCenter.y -= 0.4f / 2;

            sprite.flipX = true;
            animator.SetBool("isDiggingUp", false);
            animator.SetBool("isDiggingDown", false);
        }
        else if (y > 0)
        {
            direction = Vector2.up;
            raycastCenter.x += 0.4f / 2;
            raycastCenter.y -= 0.4f / 2 - 0.4f;

            animator.SetBool("isDiggingUp", true);
            animator.SetBool("isDiggingDown", false);
        }
        else if (y < 0)
        {
            direction = Vector2.down;
            raycastCenter.x += 0.4f / 2;
            raycastCenter.y -= 0.4f / 2 + 0.4f;


            animator.SetBool("isDiggingUp", false);
            animator.SetBool("isDiggingDown", true);
        }

        Debug.DrawRay(raycastCenter, direction, Color.cyan);

        RaycastHit2D hit = Physics2D.Raycast(raycastCenter, direction, 0.4f / 4);

        if (hit.collider != null)
        {
            //Debug.Log(hit.distance);
            //Debug.Log(hit.collider.gameObject.name);

            if (_hitBlock == null || hit.collider.gameObject != _hitBlock.gameObject)
                _hitBlock = hit.collider.GetComponent<Blocks>();

            animator.SetBool("isDigging", true);

            _hitBlock.AddDamage(damage);

            _timeSinceLastMovement = 0f; // reset to add a delay so the gravity block is well raycasted
        }
        else
        {
            if (_timeSinceLastMovement >= _speedMove)
            {
                this.transform.Translate(x, y, 0);
                _timeSinceLastMovement = 0f;
            }

        }
    }
}
