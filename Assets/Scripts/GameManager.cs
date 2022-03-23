using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public AudioSource hitSound;

    public bool startPlaying;

    public NoteController theNC;

    public Text scoreText;
    public Text comboText;
    public Text songTitle, finalScore, perfectQuantity, greatQuantity, goodQuantity, missQuantity, maxComboText, accuracyScore;

    public Sprite rankSS, rankS, rankA, rankB, rankC, rankD;

    public Image rank;

    public int score, combo, maxCombo;
    public float lifeTime = 1;

    public GameObject perfectEffect, greatEffect, goodEffect, missEffect;
    public GameObject resultScreen, gameScreen, failedScreen;

    public bool destroyPerfect, destroyGreat, destroyGood, destroyMiss;

    public float totalNotes;
    public float perfectHits;
    public float greatHits;
    public float goodHits;
    public float missHits;
    public float accuracy;

    public bool perfectSlide, greatSlide, goodSlide, missSlide;

    public HealthBar healthBar;
    public float health, maxHealth,missDamage, hitHeal;

    public bool paused;
    public GameObject pauseMenu, notes;

    public Ranking ranking;

    public string songName;


    // Start is called before the first frame update
    void Start()
    {
        startPlaying = false;
        score = 0;
        combo = 0;
        scoreText.text = "0";
        comboText.text = "";
        totalNotes = FindObjectsOfType<NoteHit>().Length + FindObjectsOfType<SliderHit_start>().Length + FindObjectsOfType<SliderHit_normal>().Length + FindObjectsOfType<SliderHit_end>().Length;
        resultScreen.SetActive(false);
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
        paused = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        
        DestroyEffect();
        if(theMusic)
        scoreText.text = "" + score;
        accuracy = (((perfectHits * 100) + (greatHits * 72) + (goodHits * 25)) / (totalNotes * 100)) * 100;
        if (combo >= maxCombo)
        {
            maxCombo = combo;
        }

        if (!startPlaying)
        {
            Invoke("PlayMusic", 1);
        }

        if (!theMusic.isPlaying)
        {
            Invoke("ResultScreen", 3);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            theMusic.Pause();
        }

        healthBar.SetHealt(health);
        PauseGame();
     
    }

    void PlayMusic()
    {
        if (!startPlaying)
        {
            theNC.hasStarted = true;
            theMusic.Play();
            startPlaying = true;
        }
    }

    void ResultScreen()
    {  
        // Result Screen
        if(!theMusic.isPlaying && !resultScreen.activeInHierarchy && health > 0)
        {
            resultScreen.SetActive(true);
            gameScreen.SetActive(false);

            finalScore.text = "" + score;
            accuracyScore.text = accuracy.ToString("F1") + "%";
            perfectQuantity.text = "" + perfectHits;
            greatQuantity.text = "" + greatHits;
            goodQuantity.text = "" + goodHits;
            missQuantity.text = "" + missHits;
            maxComboText.text = "" + maxCombo;

            ranking.AddRankingEntry(score, songName);

            if(accuracy == 100)
            {
                rank.sprite = rankSS;
            }
            if(accuracy < 100 && accuracy >= 92)
            {
                rank.sprite = rankS;
            }
            if(accuracy < 92 && accuracy >= 86)
            {
                rank.sprite = rankA;
            }
            if(accuracy < 86 && accuracy >= 75)
            {
                rank.sprite = rankB;
            }
            if(accuracy < 75 && accuracy >= 65)
            {
                rank.sprite = rankC;
            }
            if(accuracy < 65)
            {
                rank.sprite = rankD;
            }
        }
    }

    void DestroyEffect()
    {
        if (destroyPerfect)
        {
            Destroy(GameObject.Find("Perfect(Clone)"));
            destroyPerfect = false;
        }

        if (destroyGreat)
        {
            Destroy(GameObject.Find("Great(Clone)"));
            destroyGreat = false;
        }

        if (destroyGood)
        {
            Destroy(GameObject.Find("Good(Clone)"));
            destroyGood = false;
        }

        if (destroyMiss)
        {
            Destroy(GameObject.Find("Miss(Clone)"));
            destroyMiss = false;
        }

        if (GameObject.Find("Perfect(Clone)") !=null)
        {
            Destroy(GameObject.Find("Perfect(Clone)"), lifeTime);
        }

        if (GameObject.Find("Great(Clone)") != null)
        {
            Destroy(GameObject.Find("Great(Clone)"), lifeTime);
        }

        if (GameObject.Find("Good(Clone)") != null)
        {
            Destroy(GameObject.Find("Good(Clone)"), lifeTime);
        }

        if (GameObject.Find("Miss(Clone)") != null)
        {
            Destroy(GameObject.Find("Miss(Clone)"), lifeTime);
        }
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            notes.SetActive(false);
            theMusic.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            notes.SetActive(true);
            theMusic.Play();
            
        }
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        notes.SetActive(true);
        theMusic.Play();
    }

    public void SwitchToRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}
