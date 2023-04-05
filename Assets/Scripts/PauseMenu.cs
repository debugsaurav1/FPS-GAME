using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameISPaused = false;
    public GameObject PauseMenuUI;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            print("ESC press");
            Debug.Log("" + GameISPaused);
            if (GameISPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }

   public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameISPaused = false;
    }

   void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f; 
        GameISPaused = true;    
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()

    {
        Debug.Log("Quitting game...");
        Application.Quit();

    }

}
