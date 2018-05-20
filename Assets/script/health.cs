using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour {


    public float healths = 100f;
    public float hurtForce = 100f;
    public float repeatDamagePeriod = 1f;
    public float damageAmount = 20f;


    private SpriteRenderer healthBar;
    private float lastHitTime;
    private Vector3 healthScale;
    private move playerControl;
    private Animator anim;

    //public float[] gat;


    void Awake()
    {
        playerControl = GetComponent<move>();
        healthBar = GameObject.Find("HealthBar").
                GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();//
        healthScale = healthBar.transform.localScale;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHitTime + repeatDamagePeriod)
            {
                if (healths > 0f)
                {
                    TakeDamage(col.transform);
                    lastHitTime = Time.time;
                }
                else
                {
                    Collider2D[] cols = GetComponents<Collider2D>();
                    foreach (Collider2D c in cols)
                    {
                        c.isTrigger = true;
                    }
                    SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer s in spr)
                    {
                        s.sortingLayerName = "UI";
                    }
                    //GetComponent<PlayerControl>().enabled = false;
                    //GetComponentInChildren<Gun>().enabled = false;
                    //anim.SetTrigger("Die");
                }
            }
        }
    }

    void TakeDamage(Transform enemy)
    {
        //playerControl.jump = false;
        Vector3 hurtVector = transform.position
                - enemy.position + Vector3.up * 5f;
        GetComponent<Rigidbody2D>().AddForce
                (hurtVector * hurtForce);
        healths -= damageAmount;
        UpdateHealthBar();
        //int i = Random.Range(0, ouchClips.Length);
        //AudioSource.PlayClipAtPoint(ouchClips[i],
        //                 transform.position);
    }

    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp (Color.green, Color.red, 1 - healths * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * healths * 0.01f, 1, 1);
    }

}
