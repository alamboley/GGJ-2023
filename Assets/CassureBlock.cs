using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassureBlock : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public Sprite SpriteBroken;
    public Block block;
    private bool once = true;

    void Update()
    {
        if(once)
        {
            if(block.health < 400f)
            {
                Sprite.sprite = SpriteBroken;
            }
        }
    }
}
