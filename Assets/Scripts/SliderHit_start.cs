using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHit_start : MonoBehaviour
{
    public bool hit;

    public KeyCode keyToPress;

    public GameManager theGM;

    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.position.x == -2.25f)
        {
            keyToPress = KeyCode.D;
        }
        if (this.transform.position.x == -1f)
        {
            keyToPress = KeyCode.F;
        }
        if (this.transform.position.x == 0.25f)
        {
            keyToPress = KeyCode.J;
        }
        if (this.transform.position.x == 1.5f)
        {
            keyToPress = KeyCode.K;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hit")
        {
            hit = true;
        }

        if (other.tag == "Destroy" && theGM.missSlide )
        {
            if (GameObject.Find("Perfect(Clone)") != null)
            {
                Debug.Log("Destroy Perfect");
                theGM.destroyPerfect = true;
            }


            if (GameObject.Find("Great(Clone)") != null)
            {
                Debug.Log("Destroy Great");
                theGM.destroyGreat = true;
            }


            if (GameObject.Find("Good(Clone)") != null)
            {
                Debug.Log("Destroy Good");
                theGM.destroyGood = true;
            }


            if (GameObject.Find("Miss(Clone)") != null)
            {
                Debug.Log("Destroy Miss");
                theGM.destroyMiss = true;
            }

            Debug.Log("Miss");
            theGM.combo = 0;
            theGM.missHits++;
            Destroy(gameObject);
            Instantiate(theGM.missEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
        }
        else if(other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hit")
        {
            hit = false;

            if (!Input.GetKey(keyToPress))
            {
                theGM.missSlide = true;
            }
        }
        
    }

    void Score()
    {


        if (hit && Input.GetKeyDown(keyToPress))
        {
            //Good hit
            if (transform.position.y >= -4.25f || transform.position.y <= -5.75f)
            {

                theGM.combo++;
                theGM.score += 25 * theGM.combo;
                theGM.goodHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.goodSlide = true;

            }
            //great hit
            else if (transform.position.y >= -4.75f || transform.position.y <= -5.25f)
            {

                theGM.combo++;
                theGM.score += 75 * theGM.combo;
                theGM.greatHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.greatSlide = true;
            }
            //Perfect Hit
            else
            {
                Debug.Log("Perfect");
                theGM.combo++;
                theGM.score += 100 * theGM.combo;
                theGM.perfectHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.perfectSlide = true;
            }
        }
        
        
    }
}
