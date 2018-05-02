using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour {
    public Transform hero;

    public float Xdist = 3f;
    public float Ydist = 3f;
    public Vector2 minxy;
    public Vector2 maxxy;
    public float xsmooth = 5f;
    public float ysmooth = 5f;


    bool IsMoveX()
    {
        if(Mathf.Abs(transform.position.x - hero.position.x) > Xdist)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void trackCam()
    {
        float newx = transform.position.x;
        float newy = transform.position.x;
        if (IsMoveX())
        {
            newx = Mathf.Lerp(transform.position.x, hero.position.x,xsmooth*Time.deltaTime);
        }

        newx = Mathf.Clamp(newx, minxy.x, maxxy.x);
        newy = Mathf.Clamp(newy, minxy.y, maxxy.y);


        transform.position = new Vector3(newx, newx, newx);
    }


    private float x = 0f;
    private float y = 0f;
    private float z = -24.14f;
    

    void position()
    {
        x = hero.position.x;
        y = hero.position.y;
        
    }

    // Use this for initialization
    void Start () {
        hero = GameObject.Find("hero").transform;
        //hero = GameObject.FindGameObjectsWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector3(hero.position.x, hero.position.y, z);
        Debug.Log(hero.position.x);
        Debug.Log(hero.position.y);


    }


}




