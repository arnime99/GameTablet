using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovimiento : MonoBehaviour {
    
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;
    // Use this for initialization
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Niveles.gameOver==false)
        {
            if (!Settings.gamePause)
            {
                int i = 0;
                //loop over every touch found
                while (i < Input.touchCount)
                {
                    if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                    {
                        //move right
                        RunCharacter(0.5f);
                    }
                    if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                    {
                        //move left
                        RunCharacter(-0.5f);
                    }
                    ++i;
                }
            }
        }
        
    }

    void FixedUpdate()
    {
#if UNITY_EDITOR
        RunCharacter(Input.GetAxis("Horizontal"));
#endif
    }
    private void RunCharacter(float horizontalInput)
    {
        Vector3 posaux = characterBody.transform.position;
        Vector3 pos = posaux;

        pos.x += 10.0f * Time.deltaTime * horizontalInput;

        Vector3 aux = Camera.main.WorldToViewportPoint(pos);

        if (aux.x <= 0.1f || aux.x >= 0.9f)
        {
            characterBody.transform.position = posaux;
        }
        else
        {
            characterBody.transform.position = pos;
        }


    }
}
