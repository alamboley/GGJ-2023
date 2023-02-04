using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RessourcesSeve : MonoBehaviour
{
    public float SoftCurrency;
    public float HardCurrency;

    public GameObject moneySeve;


    public void Update()
    {
        moneySeve.GetComponent<TextMeshProUGUI>().text = SoftCurrency.ToString();
    }
}
