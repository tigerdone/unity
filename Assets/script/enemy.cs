﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

    public float speed = 10f;
    //public float v = 1f;
    public Collider2D coll;


    private Rigidbody2D rigidBody;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update () {

        //v = rigidBody.velocity.x;
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        if(transform.position.y < -8)
        {
            Destroy(gameObject);

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "town")
        {
            speed *= -1;
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);

        }
        if (col.gameObject.tag == "boll")
        {
            //Destroy(gameObject);
            //rigidBody.velocity = new Vector2(0f, 0f);
            speed = 2f;
            //Debug.Log(rigidBody.velocity);

            coll.isTrigger = true;
        }

    }


}
