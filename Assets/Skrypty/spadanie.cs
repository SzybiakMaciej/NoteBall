using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spadanie : MonoBehaviour {

    public GameObject pilka;
	// Update is called once per frame
	void Update () {
        if (pilka.transform.position.y < -15)
        {
            print("Koniec");
        }
	}
}
