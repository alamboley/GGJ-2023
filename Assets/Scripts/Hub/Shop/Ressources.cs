using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ressources : MonoBehaviour
{
    public float SoftCurrency;
    public float HardCurrency;

    public GameObject money;
    

    public void Update()
    {
        money.GetComponent<TextMeshProUGUI>().text = SoftCurrency.ToString();
    }
}
