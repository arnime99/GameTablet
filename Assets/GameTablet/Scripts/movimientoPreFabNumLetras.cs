﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPreFabNumLetras : MonoBehaviour
{
    public AudioClip _audioSource;
    private GameObject gameController;
    private GameController _gameController;
    private Niveles _niveles;
    private bool vocal = false;
    private string currentLevel;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController");
        _gameController = gameController.GetComponent<GameController>();
        currentLevel = _gameController.GetLevel();
        _niveles = gameController.GetComponent<Niveles>();
    }

    // Update is called once per frame
    void Update()
    {
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
            case "Nivel1":
                Level1();
                break;
            case "Nivel2":
                Level2();
                break;
        }
    }

    private void Level1()
    {
        if (this.tag == _niveles.tagAdivinar)
        {
            ScoreScript.scoreValue += 100;
            _niveles.valorAdivinar();
        }
        //Si no restamos 20 puntos
        else
        {
            ScoreScript.scoreValue -= 20;
        }
    }

    private void Level2()
    {
        if (this.vocal == true)
        {
            ScoreScript.scoreValue += 100;
            _niveles.valorAdivinar();
        }
        else
        {
            ScoreScript.scoreValue -= 20;
        }
    }

    public bool GetVocal()
    {
        return vocal;
    }

    public void SetVocal(bool _setvocal)
    {
        vocal = _setvocal;
    }
}
