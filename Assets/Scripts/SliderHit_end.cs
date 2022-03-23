using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHit_end : MonoBehaviour
{
    private bool slide, add;

    public KeyCode keyToPress;

    public GameManager theGM;



    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.position.x == -2.25f)
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

        add = true;
    }

    // Update is called once per frame
    void Update()
    {
        Slide();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Hit")
        {
            if (slide && add && theGM.goodSlide)
            {
                theGM.combo++;
                theGM.score += 25 * theGM.combo;
                theGM.goodHits++;
                theGM.comboText.text = "" + theGM.combo;
                add = false;
            }

            if (slide && add && theGM.greatSlide)
            {
                theGM.combo++;
                theGM.score += 75 * theGM.combo;
                theGM.greatHits++;
                theGM.comboText.text = "" + theGM.combo;
                add = false;
            }

            if (slide && add && theGM.perfectSlide)
            {
                theGM.combo++;
                theGM.score += 100 * theGM.combo;
                theGM.perfectHits++;
                theGM.comboText.text = "" + theGM.combo;
                add = false;
            }

           if (!slide && add)
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

                theGM.combo = 0;
                theGM.missHits++;
                Instantiate(theGM.missEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
                theGM.perfectSlide = false;
                theGM.greatSlide = false;
                theGM.goodSlide = false;
                add = false;
            }
        }
    }

      public void OnTriggerEnter2D(Collider2D other)
      {

          if (other.tag == "Destroy" && theGM.missSlide)
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
        else if (other.tag == "Destroy")
        {
            Destroy(gameObject);
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Hit")
        {
            if (theGM.perfectSlide)
            {
                Instantiate(theGM.perfectEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
            }
            if (theGM.greatSlide)
            {
                Instantiate(theGM.greatEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
            }
            if (theGM.goodSlide)
            {
                Instantiate(theGM.goodEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
            }

            if (!Input.GetKey(keyToPress))
            {
                theGM.missSlide = true;
            }
        }


       
    }

    void Slide()
    {
        if (Input.GetKey(keyToPress))
        {
            slide = true;
        }
        else
        {
            slide = false;
        }
    }
}
