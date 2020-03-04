using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class NivelesNum : MonoBehaviour
{
    public GameObject prefabNumeros, prefabAdivinar, gameController;
    private movimientoPreFabNumLetras _letrasScript;
    private GameController _gameController;
    public Sprite[] spritesNumeros;
    public Sprite[] spritesLetrasNum;
    public float spwanLetrasNumros = 1;
    public int numeroRandom, spawnNum, contador,max;
    public string tagAdivinar, currentLevel;
    public static bool gameOver;
    public float nextTimeToSpawn;
    public float timeToSpawn = 1.5f;
    public Sprite find, numSuma1, numSuma2;
    private movimientoPreFabNumLetras movPrefNum;
    
    public void Awake()
    {
        prefabNumeros = Resources.Load("prefabNum") as GameObject;
        prefabAdivinar = Resources.Load("prefabAdivinarNum") as GameObject;
        spritesNumeros = Resources.LoadAll<Sprite>("numeros");
        spritesLetrasNum = Resources.LoadAll<Sprite>("numeros");
        gameController = GameObject.Find("GameController");
        _gameController = GetComponent<GameController>();
        movPrefNum = GetComponent<movimientoPreFabNumLetras>();
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
        GameObject p = Instantiate(prefabNumeros, new Vector3(Random.Range(-3.0f, 2.0f), 5, 0), Quaternion.identity) as GameObject;
        p.GetComponent<SpriteRenderer>().sprite = spritesLetrasNum[spawnNum];
        p.gameObject.tag = spritesLetrasNum[spawnNum].name;
        _letrasScript = p.GetComponent<movimientoPreFabNumLetras>();
        //_letrasScript.SetVocal(CheckVocal(p.gameObject.tag));
    }


    public void SpawnTest(){
        GameObject p = Instantiate(prefabNumeros, new Vector3(Random.Range(-3.0f, 2.0f), 5, 0), Quaternion.identity) as GameObject;
        int randomNum = Random.Range(0, (spritesLetrasNum.Length));
        p.GetComponent<SpriteRenderer>().sprite = spritesLetrasNum[randomNum];
        p.gameObject.tag = spritesLetrasNum[randomNum].name;
        Debug.Log("TAG: " + p.tag);
       
        if (p.gameObject.tag != tagAdivinar)
        {
            contador++;
            //print("Contador: " + contador);
        }
        else contador = 0;
        if (contador > max){            
            p.GetComponent<SpriteRenderer>().sprite = spritesLetrasNum[numeroRandom];
            p.gameObject.tag = tagAdivinar;
            contador = 0;           
        }
        
        //print("Numero: " + p.gameObject.tag);
        //print("Numero Adivinar: " + tagAdivinar);
        _letrasScript = p.GetComponent<movimientoPreFabNumLetras>();
        //_letrasScript.SetVocal(CheckVocal(p.gameObject.tag));
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
        if (auxMax > spritesLetrasNum.Length)
        {
            auxMax = spritesLetrasNum.Length - 1;
        }
        auxMin = numeroRandom - 2;
        if (auxMin < 0)
        {
            auxMin = 0;
        }
        spawnNum = Random.Range(auxMin, (auxMax + 1));
    }

    //Comprueba si la letra es vocal
    //private bool CheckVocal(string tag)
    //{
    //    bool vocal = false;
    //    if (tag == "abecedario_0" || tag == "abecedario_4" || tag == "abecedario_8" || tag == "abecedario_14" || tag == "abecedario_20")
    //    {
    //        vocal = true;
    //    }
    //    return vocal;
    //}

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
        //numeroRandom = Random.Range(0, (spritesLetrasNum.Length));
        //GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetrasNum[numeroRandom];
        //tagAdivinar = spritesNumeros[numeroRandom].name;
        ////print("Número random nivel 1: " + numeroRandom);
        numeroRandom = Random.Range(0, (spritesLetrasNum.Length));        
        GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetrasNum[numeroRandom];
        GameObject.Find("valorSuma1").GetComponent<Image>().sprite = numSuma1;
        GameObject.Find("valorSuma2").GetComponent<Image>().sprite = numSuma2;
        tagAdivinar = spritesNumeros[numeroRandom].name;
    }

    public void Level2()
    {
        GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetrasNum[numeroRandom];
        GameObject.Find("valorSuma1").GetComponent<Image>().sprite = numSuma1;
        GameObject.Find("valorSuma2").GetComponent<Image>().sprite = numSuma2;
    }

    public void Level3(){
        numeroRandom = Random.Range(0, (spritesLetrasNum.Length));        
        GameObject.Find("valorAdivinar").GetComponent<Image>().sprite = spritesLetrasNum[numeroRandom];
        GameObject.Find("valorSuma1").GetComponent<Image>().sprite = spritesLetrasNum[numeroRandom];
        GameObject.Find("valorSuma2").GetComponent<Image>().sprite = numSuma2;
        tagAdivinar = spritesNumeros[numeroRandom].name;
    }
}
