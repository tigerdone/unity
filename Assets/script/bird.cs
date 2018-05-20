using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour {

    public Transform a_bird;

    public float y = 5;


    private float startTime;
    private float getTime;
    private Vector3 vec;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
        //Destroy(gameObject, 5);
        //Random.seed = System.DateTime.Now.Second;

    }

    // Update is called once per frame
    void Update () {
        get_bird();
    
        //Debug.Log();

    }

    void get_bird()
    {
        getTime = Time.time;


        y = Random.value * 26;
        vec.y = y;
        vec.x = 35;
        if (getTime - startTime > 4)
        {
            Instantiate(a_bird, vec, Quaternion.identity);
            startTime = getTime;

        }
        //Debug.Log();
        //Debug.Log("y"+ vec);

    }

}
