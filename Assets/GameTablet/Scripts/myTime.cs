using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myTime : MonoBehaviour {
    //Variables para el tiempo
    public float meTime;       // -----> Tiempo que dura el juego
    private Text timerText;         // -----> Texto donde se guarda el tiempo
    public GameObject gameOver;

	// Use this for initialization
	void Start () {
        meTime = 60.0f;
        timerText = GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Niveles.gameOver==false)
        {
            if (!Settings.gamePause)
            {
                meTime -= Time.deltaTime;
                timerText.text = meTime.ToString("f0");
                if (meTime <= 0)
                {
                    gameOver.gameObject.SetActive(true);
                    Niveles.gameOver = true;
                }

            }
        }  
	}
}
