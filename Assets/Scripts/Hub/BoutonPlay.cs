using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPlay : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
