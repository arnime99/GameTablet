using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Niveles : MonoBehaviour
{
    public GameObject prefabNumerosLetras, prefabAdivinar, gameController;
    private movimientoPreFabNumLetras _letrasScript;
    private GameController _gameController;
    public Sprite[] spritesNumerosLetras;
    public Sprite[] spritesLetras;
    public float spwanLetrasNumros = 1;
    public int numeroRandom, spawnNum, contador,max;
    public string tagAdivinar, currentLevel;
    public static bool gameOver;
    public float nextTimeToSpawn;
    public float timeToSpawn = 1.5f;
    
    public void Awake()
    {
        prefabNumerosLetras = Resources.Load("prefabNumLetras") as GameObject;
        prefabAdivinar = Resources.Load("prefabAdivinar") as GameObject;
        spritesNumerosLetras = Resources.LoadAll<Sprite>("LetrasNumeros");
        spritesLetras = Resources.LoadAll<Sprite>("LetrasNumeros/Letras");
        gameController = GameObject.Find("GameController");
        _gameController = GetComponent<GameController>();
        //valorAdivinar();
        gameOver = false;
        Settings.gamePause = false;
    }

    public void Start()
    {
        currentLevel = _gameController.GetLevel();
        valorAdivinar();
        contador = 0;
        max = 6;
    }

    public void Update()
    {
        if (gameOver == false)
        {
            if (!Settings.gamePause)
            {
                if (nextTimeToSpawn < Time.timeSinceLevelLoad)
                {
                    GetRandomNum();
                    //spawn();
                    SpawnTest();
                    nextTimeToSpawn = Time.timeSinceLevelLoad + timeToSpawn;
                }

            }
        }
    }

    //public void configuration()

    //Instancia una letra aleatoria
    public void spawn()
    {
        GameObject p = Instantiate(prefabNumerosLetras, new Vector3(Random.Range(-3.0f, 2.0f), 5, 0), Quaternion.identity) as GameObject;
        p.GetComponent<SpriteRenderer>().sprite = spritesLetras[spawnNum];
        p.gameObject.tag = spritesLetras[spawnNum].name;
        _letrasScript = p.GetComponent<movimientoPreFabNumLetras>();
        _letrasScript.SetVocal(CheckVocal(p.gameObject.tag));
    }


    public void SpawnTest()
    {
        GameObject p = Instantiate(prefabNumerosLetras, new Vector3(Random.Range(-3.0f, 2.0f), 5, 0), Quaternion.identity) as GameObject;
        int randomNum = Random.Range(0, (spritesLetras.Length));
        p.GetComponent<SpriteRenderer>().sprite = spritesLetras[randomNum];
        p.gameObject.tag = spritesLetras[randomNum].name;
        if (p.gameObject.tag != tagAdivinar)
        {
            contador++;
            print("Contador: " + contador);
        }
        else contador = 0;
        if (contador > max)
        {
            p.GetComponent<SpriteRenderer>().sprite = spritesLetras[numeroRandom];
            p.gameObject.tag = tagAdivinar;
            contador = 0;
        }
        print(p.gameObject.tag);
        print(tagAdivinar);
        _letrasScript = p.GetComponent<movimientoPreFabNumLetras>();
        _letrasScript.SetVocal(CheckVocal(p.gameObject.tag));
    }

    //Determina la letra que se debe encontrar
    public void valorAdivinar()
    {
        CheckLevel();
    }

    //Genera un número aleatorio para poder instanciar una letra
    public void GetRandomNum()
    {
        int auxMax, auxMin;
        auxMax = numeroRandom + 2;
        if (auxMax > spritesLetras.Length)
        {
            auxMax = spritesLetras.Length - 1;
        }
        auxMin = numeroRandom - 2;
        if (auxMin < 0)
        {
            auxMin = 0;
        }
        spawnNum = Random.Range(auxMin, (auxMax + 1));
    }

    //Comprueba si la letra es vocal
    private bool CheckVocal(string tag)
    {
        bool vocal = false;
        if (tag == "abecedario_0" || tag == "abecedario_4" || tag == "abecedario_8" || tag == "abecedario_14" || tag == "abecedario_20")
        {
            vocal = true;
        }
        return vocal;
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

    public void Level1()
    {
        numeroRandom = Random.Range(0, (spritesLetras.Length));
        GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetras[numeroRandom];
        tagAdivinar = spritesNumerosLetras[numeroRandom].name;
        print("Número random nivel 1: " + numeroRandom);
    }

    public void Level2()
    {
        numeroRandom = Random.Range(0, (spritesLetras.Length));
        GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetras[numeroRandom];
        tagAdivinar = spritesNumerosLetras[numeroRandom].name;
    }
}
