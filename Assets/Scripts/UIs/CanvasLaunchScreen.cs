using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLaunchScreen : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] TextMeshProUGUI playText;
    [SerializeField] TextMeshProUGUI money;
    void Start()
    {
        playText.DOFade(0.4f, 0.4f).SetLoops(-1, LoopType.Yoyo);

        money.text = GameManager.Instance.totalCoin.ToString();

        play.onClick.AddListener(GameManager.Instance.LaunchGame);
    }

    public void UpdateCoins()
    {
        int previousMoney = int.Parse(money.text);

        DOVirtual.Int(int.Parse(money.text), GameManager.Instance.totalCoin, 1, (int value) => money.text = value.ToString());
    }
}
