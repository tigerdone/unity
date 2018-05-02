using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public Rigidbody2D rig;
    public Transform origin;
	// Use this for initialization
	void Start () {
        mGroundCheck = transform.Find("GroundCheck");

    }
    public int MaxSpeed = 10;
    public int Moveforce = 80;

    private bool bFacerright = true;
    private bool bJump = false;
    public Transform mGroundCheck;


    void FixedUpdate()
    {
        float fInput = Input.GetAxis("Horizontal");
        //float fInput = Input.GetAxis("Vertical");

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //控制移动

        if(Input.GetKeyDown(KeyCode.Space)&& Physics2D.Raycast(origin.position,Vector2.down,0.1f))
        {
            rig.AddForce(new Vector2(0, 500));
        }
            

        if (fInput * rigidBody.velocity.x < MaxSpeed)
        {
            rigidBody.AddForce(Vector2.right * fInput * Moveforce);
        }


        //限制最大速度
        if (Mathf.Abs(rigidBody.velocity.x) > MaxSpeed)
        {
            rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * MaxSpeed, rigidBody.velocity.y);
        }
        if (fInput > 0 && !bFacerright)
        {
            flip();
        }
        if(fInput < 0 && bFacerright)
        {
            flip();

        }


        //Debug.Log(rigidBody.velocity[0]);
        //Debug.Log(fInput);

        //if (bJump)
        //{
        //    rigidBody.AddForce(new Vector2(0, jumpf))
        //    bJump = false;
        //}

    }

    // Update is called once per frame
    void Update () {
		
	}

    void flip()
    {
        bFacerright = !bFacerright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}

