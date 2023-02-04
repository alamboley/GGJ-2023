using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public ItemType itemType;
    public int cost;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
    }

    void Clicked()
    {

    }
}

public enum ItemType
{
    Dynamite,
    Claws
}