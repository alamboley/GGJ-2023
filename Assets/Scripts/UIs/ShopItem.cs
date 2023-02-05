using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public ItemType itemType;
    public int cost;

    [SerializeField] CanvasLaunchScreen canvasLaunchScreen;


    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);
    }

    void Clicked()
    {
        GameManager.Instance.audioManager.PlayClickSound();

        if (itemType == ItemType.Fog && GameManager.Instance.abilities.Contains(ItemType.Fog))
        {
            Debug.Log("just one fog");
            return;
        }

        if (cost <= GameManager.Instance.totalCoin)
        {
            GameManager.Instance.totalCoin -= cost;

            GameManager.Instance.abilities.Add(itemType);

            canvasLaunchScreen.UpdateCoins();
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