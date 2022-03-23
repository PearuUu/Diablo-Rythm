using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHit : MonoBehaviour
{
    public bool hit;

    public KeyCode keyToPress;

    public GameManager theGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Hit")
        {
            hit = true;
        }

        if(other.tag == "Destroy")
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
            theGM.health -= theGM.missDamage;
            Destroy(gameObject);
            Instantiate(theGM.missEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Hit")
        {
            hit = false;
        }
    }

    void Score()
    {


        if (hit && Input.GetKeyDown(keyToPress))
        {
            //Good hit
            if (transform.position.y >= -4f || transform.position.y <= -5.20f)
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



                Debug.Log("Good");
                theGM.combo++;
                theGM.score += 25 * theGM.combo;
                theGM.goodHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.health += theGM.hitHeal;
                Destroy(gameObject);
                Instantiate(theGM.goodEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);

            }
            //great hit
            else if (transform.position.y >= -4.25f || transform.position.y <= -4.8f)
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



                Debug.Log("Great");
                theGM.combo++;
                theGM.score += 75 * theGM.combo;
                theGM.greatHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.health += theGM.hitHeal;
                Destroy(gameObject);
                Instantiate(theGM.greatEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
            }
            //Perfect Hit
            else
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



                Debug.Log("Perfect");
                theGM.combo++;
                theGM.score += 100 * theGM.combo;
                theGM.perfectHits++;
                theGM.comboText.text = "" + theGM.combo;
                theGM.hitSound.Play();
                theGM.health += theGM.hitHeal;
                Destroy(gameObject);
                Instantiate(theGM.perfectEffect, new Vector3(theGM.comboText.transform.position.x, theGM.comboText.transform.position.y - 0.5f, theGM.comboText.transform.position.z), theGM.comboText.transform.rotation);
            }


        }
    }
}
