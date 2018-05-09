using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
        Destroy(gameObject, 5);

    }

    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
        {
            Destroy(gameObject);

            //播放完毕，要执行的内容
        }
    }
}
