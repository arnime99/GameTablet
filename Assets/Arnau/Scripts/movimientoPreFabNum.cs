using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimientoPreFabNum : MonoBehaviour {
    public AudioClip _audioSource;
    private GameObject gameController;
    private GameController _gameController;
    private Niveles _niveles;
    private NivelesNum _nivelesNum;
    private bool vocal = false;
    private string currentLevel;
    public Sprite[] spritesLetrasNum;
    public Sprite num1, num2;
    public int num;
    // Use this for initialization
    void Start ()
    {
        gameController = GameObject.Find("GameController");
        _gameController = gameController.GetComponent<GameController>();
        currentLevel = _gameController.GetLevel();
        _niveles = gameController.GetComponent<Niveles>();
        _nivelesNum = gameController.GetComponent<NivelesNum>();
        spritesLetrasNum = Resources.LoadAll<Sprite>("numeros");
    }
	
	// Update is called once per frame
	void Update () {
        if (Niveles.gameOver == false)
        {
            if (!Settings.gamePause)
            {
                transform.Translate(Vector3.down * 2.0f * Time.deltaTime);

                //Si el objeto supera el valor de la y, lo destruimos
                if (transform.position.y < -6.0f)
                {
                    Destroy(this.gameObject);
                }
            }
        }           
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si los objetos que bajan, han colisionado con el jugador accedemos al if
        if (other.tag == "Player")
        {
            /*if (this.tag == _niveles.tagAdivinar)
            {
                ScoreScript.scoreValue += 100;
                _niveles.valorAdivinar();
            }
            //Si no restamos 20 puntos
            else
            {
                ScoreScript.scoreValue -= 20;
            }*/
            CheckLevel();
            AudioSource.PlayClipAtPoint(_audioSource, transform.position);
            //Destruimos el objeto que ha colisionado con el jugador
            Destroy(this.gameObject);
        }
    }

    private void CheckLevel()
    {
        switch (currentLevel)
        {
            case "Nivel1": Level1();
                break;
            case "Nivel2": Level2();
                break;
        }
    }

    private void Level1()
    {
        if(this.tag == _nivelesNum.tagAdivinar){
            ScoreScript.scoreValue += 100;
            _niveles.valorAdivinar();
        }
        //Si no restamos 20 puntos
        else{
            GetValue();
            
            //ScoreScript.scoreValue -= 20;
        }
    }

    private void Level2()
    {
        if(this.vocal == true)
        {
            ScoreScript.scoreValue += 100;
            _niveles.valorAdivinar();
        }
        else
        {
            GetValue();
            ScoreScript.scoreValue -= 20;
        }
    }

    public bool GetVocal()
    {
        return vocal;
    }
    void GetValue()
    {
        Debug.Log(this.tag);
        switch (this.tag)
        {
            case "numeros_0":
                num = 0;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_1":
                num = 1;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_2":
                num = 2;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_3":
                num = 3;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_4":
                num = 4;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_5":
                num = 5;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_6":
                num = 6;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_7":
                num = 7;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_8":
                num = 8;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
            case "numeros_9":
                num = 9;
                _nivelesNum.numSuma1 = spritesLetrasNum[0];
                break;
        }
        //GameObject.Find("valorSuma1").GetComponent<Image>().sprite = spritesLetrasNum[this.name];
    }

    public void SetVocal(bool _setvocal)
    {
        vocal = _setvocal;
    }
}
