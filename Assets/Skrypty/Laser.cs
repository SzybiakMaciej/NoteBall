using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    // Update is called once per frame
    public GameObject laser;
    float timer = 0;

    void Update ()
    {
        if (OdliczCzas() % 4 == 0)
        {
            laser.GetComponent<Renderer>().enabled = true;
            laser.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            laser.GetComponent<Renderer>().enabled = false;
            laser.GetComponent<Collider2D>().enabled = false;
        }
        
    }

    private int OdliczCzas()
    {
        timer += Time.deltaTime;
        return (int)timer;
    }

}
