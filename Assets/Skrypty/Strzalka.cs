using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzalka : MonoBehaviour {

    public GameObject strzalka;
    public GameObject pilka;

    Vector3 odlegloscOdPilki = new Vector3(2, 0, 0);

	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {

        strzalka.transform.position = pilka.transform.position + odlegloscOdPilki;
        	
	}
}
