using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die_bird : MonoBehaviour {

    public float step = 0.1f;

    // Use this for initialization
	void Start () {
        Destroy(gameObject, 11);
    }
    
    // Update is called once per frame
    void Update () {
        move();

    }
    void move()
    {
        Vector3 position = transform.position;
        position.x -= step;
        transform.position = position;

    }
}
