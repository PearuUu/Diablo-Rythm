using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void SongSelect()
    {
        SceneManager.LoadScene("Song Select");
    }

    public void DoExitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }

}
