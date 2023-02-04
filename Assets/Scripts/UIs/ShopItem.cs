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
        if (cost <= GameManager.Instance.totalCoin)
        {
            GameManager.Instance.totalCoin -= cost;

            GameManager.Instance.abilities.Add(itemType);
        }
    }
}

public enum ItemType
{
    Dynamite,
    Claws,
    Cresus,
    Wolverine,
    Fog
}