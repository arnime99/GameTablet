using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private ConfigurationLevels cgl;
    public static GameController instance;
    public Niveles niveles;
    public NivelesNum nivelesNum;
    private string level;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        level = (PlayerPrefs.GetString("Nivel"));
        //instance.cgl.init();
    }

    public string GetLevel()
    {
        return level;
    }
}

