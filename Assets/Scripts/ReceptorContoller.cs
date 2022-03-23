using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorContoller : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultSprite;
    public Sprite pressedSprite;

    public KeyCode pressKey;

    



    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        buttonContorller();
    }

    void buttonContorller()
    {
        if (Input.GetKeyDown(pressKey))
        {
            theSR.sprite = pressedSprite;
        }

        if (Input.GetKeyUp(pressKey))
        {
            theSR.sprite = defaultSprite;
        }
    }
}
