using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Song_Select_Buttons : MonoBehaviour
{

    
    public GameObject song_Tile;
    public GameObject songs;

    

    private void Update()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadBeatMap()
    {
        SceneManager.LoadScene("Black or white");
    }

    

    

}
