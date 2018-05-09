using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public Rigidbody2D rig;
    public Transform origin;
    public Transform bg1;
    public Transform bg2;
    public Transform bg3;
    public Transform bg4;
    public Transform mGroundCheck;
    public int MaxSpeed = 10;
    public int Moveforce = 80;
    public int force = 500;
    //public float bgchangetimes = 1f;

    [HideInInspector]
    public int dirc = 1;
    //private float bgchange = 1f;

    private bool bFacerright = true;
    //private bool bJump = false;


    // Use this for initialization
    void Start () {
        //mGroundCheck = transform.Find("GroundCheck");
        //Debug.Log("Vector2.down:" + Vector2.down);
        //Debug.Log("Vector2.right:" + Vector2.right);
    }

   

    void FixedUpdate()
    {
        float fInput = Input.GetAxis("Horizontal");
        //float fInput = Input.GetAxis("Vertical");

        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        //控制移动

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


    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(origin.position, Vector2.down, 0.1f))
        {
            rig.AddForce(new Vector2(0, force));
            //rig.AddForce(Vector2.right* force);

        }

        //瞬间移动
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //判断方向
            if (transform.localScale.x > 0)
            {
                dirc = 1;
            }
            else
            {
                dirc = -1;
            }
            rig.AddForce(new Vector2(force * 5 * dirc, 0));
            //rig.AddForce(Vector2.right * force*3* dirc);

        }


    }

    void flip()
    {
        bFacerright = !bFacerright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("开始碰撞" + col.collider.gameObject.name);
    }
    void OnCollisionStay(Collision col)
    {
        Debug.Log("持续碰撞中" + col.collider.gameObject.name);
    }
    void OnCollisionExit(Collision col)
    {
        Debug.Log("碰撞结束" + col.collider.gameObject.name);
    }
}

