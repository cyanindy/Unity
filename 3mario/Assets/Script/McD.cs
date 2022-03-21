using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McD : MonoBehaviour
{
    Animator animator;
    bool onrange=false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onrange) { //사거리 오브젝트를 플레이어가 밟았다?
            animator.SetBool("onrange",true);
        }
    }

    public void onRange() {
        onrange=true;
        Debug.Log("Player is within range");
    }
}
