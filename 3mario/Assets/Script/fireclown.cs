using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireclown : MonoBehaviour
{

    public Transform right_hit_pos; public Vector2 right_hit_boxSize;
    public Transform left_hit_pos; public Vector2 left_hit_boxSize;

    Animator animator;
    bool flame_left=false;
    bool flame_right=false;

    float left_atk_cooltime=3; float left_atk_cooltime_timer=0;
    float right_atk_cooltime=3; float right_atk_cooltime_timer=0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flame_left) {
            left_atk_hit();
        } else { ;}
        if (flame_right) {
            right_atk_hit();
        } else { ;}
    }

    private void OnDrawGizmos() {
        Gizmos.color=Color.blue;
        Gizmos.DrawWireCube(right_hit_pos.position, right_hit_boxSize);
        Gizmos.DrawWireCube(left_hit_pos.position, left_hit_boxSize);
    }

     private void left_atk_hit() {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(left_hit_pos.position, left_hit_boxSize, 0);
        foreach (Collider2D collider in collider2Ds) {
            if (left_atk_cooltime_timer <= 0) {
                if (collider.tag == "Player") {
                    collider.GetComponent<player>().ChangeHealth(-1);
                    left_atk_cooltime_timer=left_atk_cooltime;
                }
            } else {
                left_atk_cooltime_timer-=Time.deltaTime;
            } 
        }
    }

    private void right_atk_hit() {
        Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(right_hit_pos.position, right_hit_boxSize, 0);
        foreach (Collider2D collider in collider2Ds) {
             if (right_atk_cooltime_timer <= 0) {
                if (collider.tag == "Player") {
                    collider.GetComponent<player>().ChangeHealth(-1);
                    right_atk_cooltime_timer = right_atk_cooltime;
                }
            } else {
                right_atk_cooltime_timer-=Time.deltaTime;
            } 
        }
    }

    public void left_flame_start() {
        flame_left=true;
    }

    public void left_flame_end() {
        flame_left=false;
    }

    public void right_flame_start() {
        flame_right=true;
    }

    public void right_flame_end() {
        flame_right=false;
    }
}
