using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
       PauseMenu.GameISPaused = false;
        //SceneManager.LoadScene("level0"); //call by scene name
        //SceneManager.LoadScene(1);//Call by scene index (static)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Call by scene index (dynamic)
    }
    public void QuitGame() 
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
