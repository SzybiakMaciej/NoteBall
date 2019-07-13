using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGlowne : MonoBehaviour {


    public void StartGry()
    {
        SceneManager.LoadScene("Poziomy");
    }

    public void Wyjdz()
    {
        Application.Quit();
    }
}
