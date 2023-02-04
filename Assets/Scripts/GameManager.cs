using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    public int totalCoin = 0;

    public List<ItemType> abilities = new List<ItemType>();

    public void AddMoneyBlockDestroyed(int coin)
    {
        totalCoin += coin + coin * abilities.FindAll(x => x == ItemType.Cresus).Count / 100;
    }

    public void AddItemInInventory(ItemType ability)
    {
        abilities.Add(ability);
    }

    public void RemoveItemInInventory(ItemType ability)
    {
        abilities.Remove(ability);
    }

    public void MoveToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}