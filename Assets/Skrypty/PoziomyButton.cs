using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoziomyButton : MonoBehaviour {


    // public Texture poziomButtonTexture;
    public Font myFont;
    bool czyWyswietlicKomunikatOZablokowanymPoziomie =false;
    public GameObject komunikatOZablokowaniuPoziomu;


    private GUIStyle guiStyle = new GUIStyle();

    public void buttonPowrot()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        komunikatOZablokowaniuPoziomu.SetActive(false);
    }

    private void OnGUI()
    {
        guiStyle.fontSize = Screen.width / Screen.height * 90;
        int maksymalnaLiczbaPoziomow = 10;
        int poczatkowaLiczbaPoziomu = 1;
        GUI.skin.font = myFont;
        guiStyle.normal.textColor = Color.black;

        for (int licznik = poczatkowaLiczbaPoziomu; licznik <= maksymalnaLiczbaPoziomow; licznik++)
        {
            if (licznik > maksymalnaLiczbaPoziomow / 2)
            {
                if (GUI.Button(new Rect((licznik - maksymalnaLiczbaPoziomow / 2) * Screen.width * 0.16f, Screen.height * 0.48f, Screen.width* 0.15f, Screen.height * 0.15f), licznik.ToString(), guiStyle))
                {
                    if (licznik <= Dane.DaneGry.OdczytDanych())
                    {
                        SceneManager.LoadScene(licznik);
                        Dane.DaneGry.aktualnyPoziom = licznik;
                    }
                    else
                    {
                        czyWyswietlicKomunikatOZablokowanymPoziomie = true;
                    }
                }
            }
            else
            {
                if (GUI.Button(new Rect((licznik * 0.36f) * Screen.width * 0.44f, Screen.height * 0.19f, Screen.width * 0.15f, Screen.height * 0.15f), licznik.ToString(), guiStyle))
                {
                    if (licznik <= Dane.DaneGry.OdczytDanych())
                    {
                        SceneManager.LoadScene(licznik);
                        Dane.DaneGry.aktualnyPoziom = licznik;
                    }
                    else
                    {
                        czyWyswietlicKomunikatOZablokowanymPoziomie = true;
                    }
                    print(Dane.DaneGry.OdczytDanych());
                }
            }
        }

        if (czyWyswietlicKomunikatOZablokowanymPoziomie)
        {
            komunikatOZablokowaniuPoziomu.SetActive(true);
            czyWyswietlicKomunikatOZablokowanymPoziomie = false;
        }

    }

}
