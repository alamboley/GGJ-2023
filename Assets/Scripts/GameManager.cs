using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    public int totalCoin = 0;

    public List<ItemType> abilities = new List<ItemType>();

    CanvasInGame canvasInGame;

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

        canvasInGame = FindObjectOfType<CanvasInGame>();
    }
    public void BackToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        if (canvasInGame == null)
            canvasInGame = FindObjectOfType<CanvasInGame>();

        Debug.Log(canvasInGame);
        canvasInGame.ShowGameOver();
    }
}