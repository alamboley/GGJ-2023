using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] int coin = 50;
    public int Coin
    {
        get { return coin; }
    }

    [SerializeField] int gem = 1;
    public int Gem
    {
        get { return gem; }
    }

    [SerializeField] float health = 100f;

    private void Update()
    {

    }

    public void AddDamage(float damage)
    {
        health -= damage;

        if (health < 0)
        {
            Vector3 raycastCenter = transform.position;
            raycastCenter.x += 0.4f / 2;
            raycastCenter.y += 0.4f / 2;

            Debug.DrawRay(raycastCenter, Vector2.up, Color.cyan);

            RaycastHit2D hit = Physics2D.Raycast(raycastCenter, Vector2.up, 0.4f / 2);

            if (hit.collider != null)
            {
                //Debug.Log("me :" + gameObject.name);
                //Debug.Log(hit.collider.gameObject.name);
                Gravity gravityBlock = hit.collider.GetComponent<Gravity>();

                if (gravityBlock != null)
                {
                    gravityBlock.BottomBlockDestroying();
                }
            }

            GameManager.Instance.AddMoneyBlockDestroyed(coin, gem);

            Destroy(gameObject);
        }
    }
}
