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
    }

    public void AddItemInInventory(ItemType ability)
    {
        abilities.Add(ability);
    }

    public void RemoveItemInInventory(ItemType ability)
    {
        abilities.Remove(ability);
    }
    public void LaunchGame()
    {
        audioManager.PlayClickSound();
        audioSource.Play();

        SceneManager.LoadScene(lastLevelReached);
        canvasInGame = FindObjectOfType<CanvasInGame>();
    }

    public void MoveToNextLevel()
    {
        lastLevelReached = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(lastLevelReached);

        canvasInGame = FindObjectOfType<CanvasInGame>();
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
            character.canMove = false;


        if (canvasInGame == null)
            canvasInGame = FindObjectOfType<CanvasInGame>();

        Debug.Log(canvasInGame);
        canvasInGame.ShowGameOver();
    }
}