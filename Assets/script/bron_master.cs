using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bron_master : MonoBehaviour {


    public Transform master;

    public float y = 5;


    private float startTime;
    private float getTime;
    //private Vector3 vec;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        //Destroy(gameObject, 5);
        //Random.seed = System.DateTime.Now.Second;

    }

    // Update is called once per frame
    void Update()
    {
        get_bird();

        //Debug.Log();

    }

    void get_bird()
    {
        getTime = Time.time;


        if (getTime - startTime > 2)
        {
            Instantiate(master, transform.position, Quaternion.identity);
            startTime = getTime;

        }
        //Debug.Log();
        //Debug.Log("y"+ vec);

    }
    //Invokerepeating()函数重复调用

}
