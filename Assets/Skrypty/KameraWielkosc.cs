using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraWielkosc : MonoBehaviour {

    public Camera mojaKamera;


    public void Przybliz()
    {
        mojaKamera.orthographicSize = mojaKamera.orthographicSize - 5;
        if(mojaKamera.orthographicSize < 5)
        {
            mojaKamera.orthographicSize = 5;
        }
    }

    public void Oddal()
    {
        mojaKamera.orthographicSize = mojaKamera.orthographicSize + 5;
        if (mojaKamera.orthographicSize > 45)
        {
            mojaKamera.orthographicSize = 45;
        }
    }


}
