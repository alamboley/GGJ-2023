
using DG.Tweening;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    [SerializeField] float damage = 0.1f;

    [SerializeField] Dynamite dynamitePrefab;

    public SpriteRenderer fogOfWar;

    float _timeSinceLastMovement = 0f;
    float _speedMove = 0.25f;

    Block _hitBlock;

    public bool canMove = true;

    bool _WolverineModeOn = false;

    void Start()
    {
        damage += damage * ((float) GameManager.Instance.abilities.FindAll(x => x == ItemType.Claws).Count) / 10;

        float numFogs = GameManager.Instance.abilities.FindAll(x => x == ItemType.Fog).Count;
        Vector3 localScale = fogOfWar.transform.localScale;
        localScale.x += numFogs * 0.15f;
        localScale.y += numFogs * 0.15f;
        localScale.z += numFogs * 0.15f;
    }

    void Update()
    {
        if (!canMove)
            return;

        _timeSinceLastMovement += Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D))
        {
            MoveToDirection(0.4f, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            MoveToDirection(-0.4f, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            MoveToDirection(0, 0.4f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveToDirection(0, -0.4f);
        }
        else
        {
            animator.SetBool("isDigging", false);
        }

        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.abilities.Contains(ItemType.Dynamite))
        {
            GameManager.Instance.RemoveItemInInventory(ItemType.Dynamite);

            Dynamite dynamite = Instantiate<Dynamite>(dynamitePrefab, transform.position, transform.rotation);

            GameManager.Instance.audioManager.PlayDynamiteSound(dynamite.TimeBeforeExplosion);
        }

        if (Input.GetKeyDown(KeyCode.R) && GameManager.Instance.abilities.Contains(ItemType.Wolverine) && !_WolverineModeOn)
        {
            GameManager.Instance.RemoveItemInInventory(ItemType.Wolverine);

            _WolverineModeOn = true;

            sprite.DOColor(Color.red, 0.2f).SetLoops(40, LoopType.Yoyo).SetEase(Ease.Linear).OnComplete(() =>
            {
                sprite.color = Color.white;

                _WolverineModeOn = false;
            });
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
                _hitBlock = hit.collider.GetComponent<Block>();

            animator.SetBool("isDigging", true);

            if (_hitBlock == null)
            {
                Debug.LogWarning("here with object : " + hit.collider.name);
            }
            else
            {
                if (_hitBlock.BlockType != BlockType.Obsidian)
                    _hitBlock.AddDamage(damage * (_WolverineModeOn ? 4 : 1));
            }

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
    public void StopCharacter()
    {
        canMove = false;
        animator.SetBool("isDigging", false);
    }
}
