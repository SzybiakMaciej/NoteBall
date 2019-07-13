using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {


    public GameObject strzalka;
    public GameObject gora;
    public GameObject dol;
    public GameObject sila;

    public GameObject pilka;
    private float miejsceX;

    private float miejsceY;


    Rigidbody2D rb;

    int wartoscPromien;
    public int limitRuchow;
    public Text limitRuchowTekst;

    Vector3 miejscePoczatkoweStrzalki = new Vector3(2, 0, 0);

    private bool czySkuty = false;
    public Texture tloMenuPorazki;
    public Texture powrotDoMenuTexture;
    public Texture resetujLevelTexture;

    private bool czyUruchomionoMenuPauzy = false;
    public Texture tloMenuPauzy;
    public Texture powrotDoGry;

    bool czyKomunikatRuchow;
    public Texture komunikatRuchow;
    public Texture ok;

    public GameObject przyspieszGre;

    private GameObject znikajacaPrzeszkoda;

    private GUIStyle guiStyle2 = new GUIStyle();

    void Start () {
        miejsceX = 1;
        miejsceY = 0;
        rb = GetComponent<Rigidbody2D>();
        print(strzalka.transform.localPosition);
        Sila.Wartosc = 5;
        czyKomunikatRuchow = true;
        gora.SetActive(false);
        dol.SetActive(false);
        sila.SetActive(false);
        znikajacaPrzeszkoda = GameObject.FindGameObjectWithTag("znikajacaPrzeszkoda");
    }

    private void Update()
    {
        if (!rb.IsSleeping())
        {
           ResetujPozycjeStrzalki();
           gora.SetActive(false);
           dol.SetActive(false);
           sila.SetActive(false);
           przyspieszGre.SetActive(true);
        }
        else if (rb.IsSleeping() && czySkuty == false && czyUruchomionoMenuPauzy == false && czyKomunikatRuchow == false)
        {
            gora.SetActive(true);
            dol.SetActive(true);
            sila.SetActive(true);
            przyspieszGre.SetActive(false);
            Time.timeScale = 1F;
        }
        if(limitRuchow == -1)
        {
            czySkuty = true;
        }
        SprawdzenieCzySpadl();
        limitRuchowTekst.text = limitRuchow.ToString();
    }
  
    public void Gora()
    {
        wartoscPromien = (int)strzalka.transform.rotation.eulerAngles.z;
        strzalka.transform.RotateAround(rb.position, new Vector3(0, 0, 1), 10);
        AktualnaPozycjaSilyGora();
        print("X"+miejsceX);
        print("Y"+miejsceY);
        strzalka.SetActive(true);

    }
    public void Dol()
    {

        wartoscPromien = (int)strzalka.transform.rotation.eulerAngles.z;
        strzalka.transform.RotateAround(rb.position, new Vector3(0,0,1),-10);
        AktualnaPozycjaSilyDol();
        print("Dol: X " + miejsceX);
        print("Dol: Y " + miejsceY);
        strzalka.SetActive(true);

    }
    public void Strzal()
    {
        Vector2 miejsceUderzenia = new Vector2(miejsceX, miejsceY);
        rb.AddForce(miejsceUderzenia * (Sila.Wartosc * 100));
        print(Sila.Wartosc);
        strzalka.SetActive(false);
        limitRuchow = limitRuchow - 1;
    }
    public void PrzyspieszGre()
    {
        Time.timeScale = 5F;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kolce"))
        {
            print("skuty");
            czySkuty = true;
            gora.SetActive(false);
            dol.SetActive(false);
            sila.SetActive(false);
        }
        if (collision.gameObject.CompareTag("checkpoint") && czySkuty==false)
        {
            Dane.DaneGry.DodajPoziom();
            Dane.DaneGry.ZdobylCheckpoint(true);
            SceneManager.LoadScene(Dane.DaneGry.aktualnyPoziom);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ostraSkrzynia"))
        {
            print("skuty");
            czySkuty = true;
            gora.SetActive(false);
            dol.SetActive(false);
            sila.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Przycisk"))
        {
            znikajacaPrzeszkoda.SetActive(false);
        }

    }

    private void OnGUI()
    {
        if (czySkuty)
        {
            GUI.DrawTexture(new Rect(Screen.width * 0.25f, Screen.height * 0.15f, Screen.width * 0.50f, Screen.height * 0.80f), tloMenuPorazki);
            if (GUI.Button(new Rect(Screen.width * 0.33f, Screen.height * 0.50f, Screen.width * 0.25f, Screen.height * 0.25f), powrotDoMenuTexture, GUIStyle.none))
            {
                SceneManager.LoadScene("Menu");
            }
            if (GUI.Button(new Rect(Screen.width * 0.53f, Screen.height * 0.50f, Screen.width * 0.25f, Screen.height * 0.25f), resetujLevelTexture, GUIStyle.none))
            {
                SceneManager.LoadScene(Dane.DaneGry.ZresetujPoziom());
            }
        }
        if (czyUruchomionoMenuPauzy)
        {
            GUI.DrawTexture(new Rect(Screen.width * 0.25f,  Screen.height * 0.15f, Screen.width * 0.50f, Screen.height * 0.80f), tloMenuPauzy);
            if (GUI.Button(new Rect(Screen.width * 0.29f, Screen.height * 0.50f, Screen.width * 0.25f , Screen.height * 0.25f), powrotDoMenuTexture, GUIStyle.none))
            {
                SceneManager.LoadScene("Menu");
            }
            if (GUI.Button(new Rect(Screen.width * 0.43f, Screen.height * 0.50f, Screen.width * 0.25f, Screen.height * 0.25f), resetujLevelTexture, GUIStyle.none))
            {
                SceneManager.LoadScene(Dane.DaneGry.ZresetujPoziom());
            }
            if (GUI.Button(new Rect(Screen.width * 0.58f, Screen.height * 0.50f, Screen.width * 0.25f, Screen.height * 0.25f), powrotDoGry, GUIStyle.none))
            {
                czyUruchomionoMenuPauzy = false;
                gora.SetActive(true);
                dol.SetActive(true);
                sila.SetActive(true);
            }
        }
        if (czyKomunikatRuchow)
        {
            przyspieszGre.SetActive(false);
            GUI.DrawTexture(new Rect(Screen.width * 0.25f, Screen.height * 0.15f, Screen.width * 0.50f, Screen.height * 0.80f), komunikatRuchow);
            guiStyle2.fontSize = Screen.width / 12;
            GUI.Label(new Rect(Screen.width * 0.45f, Screen.height * 0.50f, Screen.width * 0.25f, Screen.height * 0.25f), limitRuchowTekst.text, guiStyle2);
            if (GUI.Button(new Rect(Screen.width * 0.55f, Screen.height * 0.70f, Screen.width * 0.25f, Screen.height * 0.25f), ok, GUIStyle.none))
            {
                czyKomunikatRuchow = false;
                gora.SetActive(true);
                dol.SetActive(true);
                sila.SetActive(true);
            }
            
        }
    }

    public void WlaczenieMenuPauzy()
    {
        czyUruchomionoMenuPauzy = true;
        gora.SetActive(false);
        dol.SetActive(false);
        sila.SetActive(false);

    }

    void SprawdzenieCzySpadl()
    {
        if (rb.position.y < -15)
        {
            czySkuty = true;
        }
    }

    void AktualnaPozycjaSilyGora()
    {
        wartoscPromien = (int)strzalka.transform.rotation.eulerAngles.z;
        print("wartoscPromien: " + wartoscPromien);
        if (wartoscPromien > 0 && wartoscPromien <= 90)
        {
            miejsceX = miejsceX - 0.1f;
            miejsceY = miejsceY + 0.1f;
        }
        else if (wartoscPromien > 90 && wartoscPromien <= 180)
        {
            miejsceX = miejsceX - 0.1f;
            miejsceY = miejsceY - 0.1f;
        }
        else if (wartoscPromien > 180 && wartoscPromien <= 270)
        {
            miejsceX = miejsceX + 0.1f;
            miejsceY = miejsceY - 0.1f;
        }
        else if (wartoscPromien > 271 && wartoscPromien <= 360)
        {
            miejsceX = miejsceX + 0.1f;
            miejsceY = miejsceY + 0.1f;
        }
    }
void AktualnaPozycjaSilyDol()
    {
        wartoscPromien = (int)strzalka.transform.rotation.eulerAngles.z;
        print("wartoscPromien: " + wartoscPromien);
        if (wartoscPromien > 0 && wartoscPromien < 90)
        {
            miejsceX = miejsceX + 0.1f;
            miejsceY = miejsceY - 0.1f;
        }
        else if (wartoscPromien >= 90 && wartoscPromien < 180)
        {
            miejsceX = miejsceX + 0.1f;
            miejsceY = miejsceY + 0.1f;
        }
        else if (wartoscPromien >= 180 && wartoscPromien < 270)
        {
            miejsceX = miejsceX - 0.1f;
            miejsceY = miejsceY + 0.1f;
        }
        else if (wartoscPromien >= 270 && wartoscPromien < 360)
        {
            miejsceX = miejsceX - 0.1f;
            miejsceY = miejsceY - 0.1f;
        }
    }

    void ResetujPozycjeStrzalki()
    {
        strzalka.transform.position = pilka.transform.position + miejscePoczatkoweStrzalki;
        Quaternion rotacjaPoczatkowa = Quaternion.Euler(0, 0, 0);
        strzalka.transform.rotation = rotacjaPoczatkowa;
        miejsceX = 1;
        miejsceY = 0;
    }
}
