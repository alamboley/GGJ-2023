
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
        Debug.DrawRay(transform.position, Vector2.right, Color.cyan);
        timeSinceLastMovement += Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 0.4f * 2);
            if (hit.collider != null)
            {

                hit.collider.GetComponent<Blocks>().AddDamage(damage);

                Debug.Log(hit.collider.gameObject.name);

            }
            else
            {
                if (timeSinceLastMovement >= speedMove)
                {
                    this.transform.Translate(0.4f, 0, 0);
                    timeSinceLastMovement = 0f;
                }
                
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (timeSinceLastMovement >= speedMove)
            {
                this.transform.Translate(-0.4f, 0, 0);
                timeSinceLastMovement = 0f;
            }
        }
    }
}
