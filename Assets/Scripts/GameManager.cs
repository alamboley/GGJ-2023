using System.Collections.Generic;


public class GameManager : PersistentSingleton<GameManager>
{
    public int totalCoin = 0;

    public List<ItemType> abilities = new List<ItemType>();

    public void AddMoneyBlockDestroyed(int coin)
    {
        totalCoin += coin + coin * abilities.FindAll(x => x == ItemType.Cresus).Count / 100;
    }
}