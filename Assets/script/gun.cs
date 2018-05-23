using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public Rigidbody2D rocket;
    public int speed = 20;
    public Rigidbody2D hero;
    public float recoil = 1000;
    public Animator anim;



    private Transform playerContral;

    void Awake()
    {
        // Setting up the reference.
        playerContral = transform.parent;

    }

    // Use this for initialization
    void Start()
    {
        //playerContral.
        hero = GameObject.Find("hero").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (playerContral.localScale.x > 0)
            {
                // ... instantiate the rocket facing right and set it's velocity to the right. 
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position + transform.forward, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
                hero.AddForce(new Vector2(-recoil, 0));

            }
            else
            {
                // Otherwise instantiate the rocket facing left and set it's velocity to the left.
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position + transform.forward, Quaternion.Euler(new Vector3(0, 0, 180f))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
                hero.AddForce(new Vector2(recoil, 0));
            }
            anim.SetTrigger("fire");


        }


    }
}
