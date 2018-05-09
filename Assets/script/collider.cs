
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public Transform fire;


    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider)
        {
            Instantiate(fire, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        //Debug
    }
}
