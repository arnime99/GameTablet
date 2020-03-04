using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {


    public GameObject panel;
    public GameObject buttonRight;
    public GameObject buttonLeft;
    public static bool gamePause = false;
    bool state;

    public  void panelShowHide()
    {
        gamePause = !gamePause;
        state = !state;
        panel.gameObject.SetActive(state);
        
    }

    public void salirMenu()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene(0);
    }
    public void salirJuego()
    {
        
        Application.Quit();
    }
    public void replayGame()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
