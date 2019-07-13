using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegulacjaSily : MonoBehaviour {


    public GameObject silaStrzalu;

    public GameObject dodajSile;
    public GameObject odejmijSile;

    private Vector3 miejscePunktuSily = new Vector3(130, 0, 0);

    
    
        
    public void DodajSile()
    {
        if (silaStrzalu.transform.localPosition.x != 202)
        {
            silaStrzalu.transform.localPosition = silaStrzalu.transform.localPosition + miejscePunktuSily;
            Sila.Wartosc++;
        }

    }

    public void OdejmijSile()
    {
        if (silaStrzalu.transform.localPosition.x != -188)
        {
            silaStrzalu.transform.localPosition = silaStrzalu.transform.localPosition - miejscePunktuSily;
            Sila.Wartosc--;
        }
    }
    

    
}
static class Sila {

    static Sila()
    {
        Wartosc = 5;

    }
    public static int Wartosc
    {
        get;
        set;
    }


}
