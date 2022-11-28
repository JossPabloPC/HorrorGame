using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text btn_txt;
    public void Jugar()
    {
        //SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
