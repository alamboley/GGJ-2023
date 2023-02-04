using UnityEngine;
using UnityEngine.UI;

public class CanvasLaunchScreen : MonoBehaviour
{
    [SerializeField] Button Play;

    void Start()
    {
        Play.onClick.AddListener(GameManager.Instance.MoveToNextLevel);
    }
}
