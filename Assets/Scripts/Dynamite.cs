using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] float timeBeforeExplosion = 2f;
    public float TimeBeforeExplosion
    {
        get { return timeBeforeExplosion; }
    }

    float _timeElapsed = 0;

    private void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= timeBeforeExplosion)
        {
            RaycastAround();
            Destroy(gameObject);
        }
    }
    void RaycastAround()
    {
        Vector2 direction = Vector2.zero;
        Vector3 raycastCenter = transform.position;

        direction = Vector2.right;
        Vector3 raycastRight = transform.position;
        raycastRight.x += 0.4f / 2 + 0.4f;
        raycastRight.y -= 0.4f / 2;
        Debug.DrawRay(raycastRight, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastRight, direction, 0.4f / 2));

        direction = new Vector2(1, 1);
        Vector3 raycastUpRight = transform.position;
        raycastUpRight.x += 0.4f / 2 + 0.4f;
        raycastUpRight.y += 0.4f / 2;
        Debug.DrawRay(raycastUpRight, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastUpRight, direction, 0.4f / 2));

        direction = Vector2.left;
        Vector3 raycastLeft = transform.position;
        raycastLeft.x += 0.4f / 2 - 0.4f;
        raycastLeft.y -= 0.4f / 2;
        Debug.DrawRay(raycastLeft, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastLeft, direction, 0.4f / 2));

        direction = new Vector2(-1, 1);
        Vector3 raycastUpLeft = transform.position;
        raycastUpLeft.x += 0.4f / 2 - 0.4f;
        raycastUpLeft.y += 0.4f / 2;
        Debug.DrawRay(raycastUpLeft, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastUpLeft, direction, 0.4f / 2));

        direction = Vector2.up;
        Vector3 raycastUp = transform.position;
        raycastUp.x += 0.4f / 2;
        raycastUp.y -= 0.4f / 2 - 0.4f;
        Debug.DrawRay(raycastUp, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastUp, direction, 0.4f / 2));

        direction = new Vector2(1, -1);
        Vector3 raycastDownRight = transform.position;
        raycastDownRight.x += 0.4f / 2 + 0.4f;
        raycastDownRight.y -= 0.4f / 2 + 0.4f;
        Debug.DrawRay(raycastDownRight, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastDownRight, direction, 0.4f / 2));

        direction = Vector2.down;
        Vector3 raycastDown = transform.position;
        raycastDown.x += 0.4f / 2;
        raycastDown.y -= 0.4f / 2 + 0.4f;
        Debug.DrawRay(raycastDown, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastDown, direction, 0.4f / 2));

        direction = new Vector2(-1, -1);
        Vector3 raycastDownLeft = transform.position;
        raycastDownLeft.x += 0.4f / 2 - 0.4f;
        raycastDownLeft.y -= 0.4f / 2 + 0.4f;
        Debug.DrawRay(raycastDownLeft, direction, Color.cyan);
        RaycastResult(Physics2D.Raycast(raycastDownLeft, direction, 0.4f / 2));
    }

    void RaycastResult(RaycastHit2D hit)
    {
        if (hit.collider != null)
        {
            Blocks block = hit.collider.GetComponent<Blocks>();
            if (block != null)
                block.DestroyBlock();

            Character character = hit.collider.GetComponent<Character>();
            if (character != null)
            {
                Debug.Log("DYNAMITE KILLS PLAYERS");
                Destroy(hit.collider.gameObject);

                GameManager.Instance.GameOver();
                FindObjectOfType<Character>().canMove = false;
            }
        }
    }
}
