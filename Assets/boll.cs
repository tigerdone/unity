
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boll : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("gameObject");
        if (other.collider)
        {
            Destroy(gameObject);
        }
    }
}
