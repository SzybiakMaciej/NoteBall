using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Dane {

    static Dane daneGry = new Dane();

    public static Dane DaneGry
    {
        get { return daneGry; }
    }


    public int aktualnyPoziom = 1;

    public int ZresetujPoziom()
    {
        return aktualnyPoziom;
    }

    public void DodajPoziom()
    {
        aktualnyPoziom++;
    }

    public void ZdobylCheckpoint(bool _czyZdobylPoziom)
    {
        if (_czyZdobylPoziom)
        {
            if (aktualnyPoziom > PlayerPrefs.GetInt("OsiagnietyPoziom"))
            {
                PlayerPrefs.SetInt("OsiagnietyPoziom", aktualnyPoziom);
                PlayerPrefs.Save();
            }
        }
    }

    public int OdczytDanych()
    {
        if (PlayerPrefs.GetInt("OsiagnietyPoziom") == 0)
        {
            return 1;
        }
        else
        {
            return PlayerPrefs.GetInt("OsiagnietyPoziom");
        }
    }


}
