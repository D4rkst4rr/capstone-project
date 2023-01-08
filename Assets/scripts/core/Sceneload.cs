using UnityEngine;
using UnityEngine.SceneManagement;
public class Sceneload : MonoBehaviour
{
    SavePlayer saveplayerdata;
    public void playgame()   // startgame button
    {
        SceneManager.LoadScene("character select");
    }
    public void quit()   // quit application button
    {
        Application.Quit();
    }
    public void mainmenu()   // for main menu scene
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void cutscenes()   // for the cutscenes
    {
        Debug.Log("loading here");
        LoadingScript.Instance.LoadScenes("cutscenes");

    }
    public void restart()    // for restarting the game
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void level1()   // for level 1 scene
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("level 1");

    }
    public void level2()   // for level 2 scene
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("level 2");

    }

    public void Quiz()   // for quiz after the act 1
    {
        SceneManager.LoadScene("QandA");
    }

}

