using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    public ItemType itemType;
    public int cost;

    [SerializeField] CanvasLaunchScreen canvasLaunchScreen;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI numItems;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Clicked);

        text.text += "\n" + cost.ToString();

        UpdateNumItems();
    }

    void Clicked()
    {
        GameManager.Instance.audioManager.PlayClickSound();

        if (cost <= GameManager.Instance.totalCoin)
        {
            GameManager.Instance.totalCoin -= cost;

            GameManager.Instance.abilities.Add(itemType);

            UpdateNumItems();

            canvasLaunchScreen.UpdateCoins();
        }
    }

    void UpdateNumItems()
    {
        numItems.text = "x" + GameManager.Instance.abilities.FindAll(x => x == itemType).Count;

    }
}

public enum ItemType
{
    Dynamite,
    Claws,
    Cresus,
    Wolverine,
    Fog,
    Coin
}