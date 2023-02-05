using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] BlockType blockType;
    [SerializeField] int coin = 50;
    public int Coin
    {
        get { return coin; }
    }

    [SerializeField] float health = 100f;

    [SerializeField] bool hasDynamite = false;
    [SerializeField] bool hasWolverine = false;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite spriteBroken;

    public void AddDamage(float damage)
    {
        health -= damage;

        if (blockType == BlockType.Stone && health < 400f)
            spriteRenderer.sprite = spriteBroken;

        if (health < 0)
            DestroyBlock();
    }

    public void DestroyBlock()
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

        GameManager.Instance.AddMoneyBlockDestroyed(coin);

        if (hasDynamite)
            GameManager.Instance.AddItemInInventory(ItemType.Dynamite);

        if (hasWolverine)
            GameManager.Instance.AddItemInInventory(ItemType.Wolverine);

        if (blockType == BlockType.Dirt)
            GameManager.Instance.audioManager.PlayDestroyDirtSound();
        else if (blockType == BlockType.Gravel)
            GameManager.Instance.audioManager.PlayDestroyGravelSound();
        else if (blockType == BlockType.Stone)
            GameManager.Instance.audioManager.PlayDestroyStoneSound();


        Destroy(gameObject);
    }
}
public enum BlockType
{
    Background,
    Dirt,
    Gravel,
    Stone,
    Obsidian,
    DirtWithResourceBlue,
    DirtWithResourceRed,
    DirtWithResourceYellow
}