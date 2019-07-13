using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour {

    public GameObject ball;

    private float offset;

    private float offsety;

    private Vector3 zmianaKamery;

    void Start()
    {
        offset = transform.position.x - ball.transform.position.x;
        offsety = transform.position.y - ball.transform.position.y;
    }
    
    void LateUpdate()
    {
        zmianaKamery = new Vector3(ball.transform.position.x + offset, ball.transform.position.y + offsety, 0);
        transform.position = zmianaKamery;
    }
}
