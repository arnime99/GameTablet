using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceLevel : MonoBehaviour {

    public void loadPlaneta()
    {
        SceneManager.LoadScene(2);
    }
    public void loadNivel(string nivel)
    {
        PlayerPrefs.SetString("Nivel", nivel);
        SceneManager.LoadScene(1);
    }
}
