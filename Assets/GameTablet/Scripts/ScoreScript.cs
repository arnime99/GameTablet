using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    //Variables para las puntuaciones
    public static int scoreValue= 0;    // -----> Score
    private Text escore;                // -----> Texto del score

    // Use this for initialization
    void Start () {
        escore = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //Asigamos el valor al texto en pantalla
        escore.text = scoreValue.ToString("f0");
	}
}
