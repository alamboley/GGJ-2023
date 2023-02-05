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
        numItems.text = "x" + GameManager.Instance.abilities.FindAll(x => x == itemType).Count;
    }

}
