using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchatLoot : MonoBehaviour
{
    public Ressources ressources;
    public float prix;
    private bool DoOnce = false;


    public void OnButtonClick()
    {
        if(ressources.SoftCurrency > prix)
        {
            if (DoOnce == false)
            {
                ressources.SoftCurrency = ressources.SoftCurrency - prix;
                print("good");
                DoOnce = true;
            }
        }
    }

  
   
}
