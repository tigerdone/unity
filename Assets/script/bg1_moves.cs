using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg1_moves : MonoBehaviour {

    public float ScaleX = 0.8f;




    public Transform player;       // Reference to the player's transform.
    private float increment = 0f; //增量
    private float per_position = 0f; //前一位置坐标


    // Use this for initialization
    void Start () {
        per_position = player.position.x;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        Trackbg();
    }


    void Trackbg()
    {
        // By default the target x and y coordinates of the camera are it's current x and y coordinates.
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        targetX = transform.position.x - (player.position.x- per_position) * ScaleX;
        //targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        per_position = player.position.x;
        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}
