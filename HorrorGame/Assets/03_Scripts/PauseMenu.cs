using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused=false;
    public CanvasGroup pauseMenuUI;

    private void Start() {
        pauseMenuUI.interactable=false;
        pauseMenuUI.blocksRaycasts=false;
        pauseMenuUI.alpha=0;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void Resume (){
        pauseMenuUI.alpha=0;
        pauseMenuUI.interactable=false;
        pauseMenuUI.blocksRaycasts=false;
        Time.timeScale=1f;
        gameIsPaused=false;
    }

    void Pause(){
        Cursor.lockState=CursorLockMode.Confined;
        pauseMenuUI.alpha=1;
        pauseMenuUI.interactable=true;
        pauseMenuUI.blocksRaycasts=true;
        Time.timeScale=0f;
        gameIsPaused=true;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ExitGame() {
        Debug.Log("Dejando Juego...");
        Application.Quit();
    }

}
