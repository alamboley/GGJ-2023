using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : PersistentSingleton<GameManager>
{
    public AudioManager audioManager;
    [SerializeField] AudioSource audioSource;

    public int totalCoin = 0;

    public List<ItemType> abilities = new List<ItemType>();

    int lastLevelReached = 1;

    CanvasInGame canvasInGame;

    public void AddMoneyBlockDestroyed(int coin)
    {
        totalCoin += coin + coin * abilities.FindAll(x => x == ItemType.Cresus).Count / 100;

        ItemInGame[] items = GetCanvasInGame().GetComponentsInChildren<ItemInGame>();

        Array.Find(items, item => item.itemType == ItemType.Coin).UpdateNumItems();
    }

    public void AddItemInInventory(ItemType ability)
    {
        abilities.Add(ability);

        ItemInGame[] items = GetCanvasInGame().GetComponentsInChildren<ItemInGame>();

        Array.Find(items, item => item.itemType == ability).UpdateNumItems();
    }

    public void RemoveItemInInventory(ItemType ability)
    {
        abilities.Remove(ability);

        ItemInGame[] items = GetCanvasInGame().GetComponentsInChildren<ItemInGame>();

        Array.Find(items, item => item.itemType == ability).UpdateNumItems();
    }
    public void LaunchGame()
    {
        audioManager.PlayClickSound();
        audioSource.Play();

        SceneManager.LoadScene(lastLevelReached);
    }

    public void MoveToNextLevel()
    {
        lastLevelReached = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(lastLevelReached);
    }
    public void BackToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver(Character character, bool kill)
    {
        if (kill)
        {
            character.fogOfWar.transform.parent = character.transform.parent; // reparrent so we keep the fog of war

            Destroy(character.gameObject);
        }
        else
            character.StopCharacter();

        GetCanvasInGame().ShowGameOver();
    }

    CanvasInGame GetCanvasInGame()
    {
        if (canvasInGame == null)
            canvasInGame = FindObjectOfType<CanvasInGame>();

        return canvasInGame;
    }
}