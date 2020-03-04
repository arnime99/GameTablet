using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceLevelNum : MonoBehaviour {

    public void loadPlaneta()
    {
        SceneManager.LoadScene("SceneNum");
    }
    public void loadNivel(string nivel)
    {
        //PlayerPrefs.SetString("Nivel", nivel);
        SceneManager.LoadScene("Scene Num");
    }
}
