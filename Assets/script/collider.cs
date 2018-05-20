
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public Transform fire;
    //public Transform part_smokepuffs_0;
    public float x_interval = 5f;
    //private float next_position_x;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 5);
        //next_position_x = this.transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D object1)
    {

        if (object1.collider)
        {
            Instantiate(fire, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        //if (Mathf.Abs(next_position_x - this.transform.position.x) > x_interval)
        //{
        //    Instantiate(part_smokepuffs_0, transform.position, Quaternion.identity);
        //    next_position_x = this.transform.position.x;
        //}

    }
}
