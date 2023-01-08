using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loaderScript : MonoBehaviour
{
    public void Newgame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1f;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("level 1");
        Time.timeScale = 1f;
    }
}
