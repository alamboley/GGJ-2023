using DG.Tweening;
using TMPro;
using UnityEngine;

public class ItemInGame : MonoBehaviour
{
    public ItemType itemType;
    [SerializeField] TextMeshProUGUI numItems;

    void Start()
    {
        UpdateNumItems();
    }

    public void UpdateNumItems()
    {
        if (itemType == ItemType.Coin)
            DOVirtual.Int(int.Parse(numItems.text), GameManager.Instance.totalCoin, 1, (int value) => numItems.text = value.ToString());
        else
            numItems.text = "x" + GameManager.Instance.abilities.FindAll(x => x == itemType).Count;
    }

}
