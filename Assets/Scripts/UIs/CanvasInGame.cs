using TMPro;
using UnityEngine;
using DG.Tweening;

public class CanvasInGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI GameOver;

    public void ShowGameOver()
    {
        GameOver.gameObject.SetActive(true);

        GameOver.DOFade(0.1f, 0.5f).SetLoops(8, LoopType.Yoyo).OnComplete(GameManager.Instance.BackToHomeScreen);
    }

}
