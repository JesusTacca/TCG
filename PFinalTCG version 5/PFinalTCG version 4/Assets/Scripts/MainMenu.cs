using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Estas en el JUEGO (right click to go back)");
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void GoTutorial()
    {
        Debug.Log("Estas en el TUTORIAL (right click to go back)");
        SceneManager.LoadScene(2);
    }
    public void GoScores()
    {
        Debug.Log("no hay :v");
        //SceneManager.LoadScene(3);
    }
    public void GoToNivel2()
    {
        SceneManager.LoadScene(3);
    }
}
