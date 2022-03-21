using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float player_Speed = 60f;
    public int player_max_health=3;
    int player_current_health;
    int curse_count=3;
    bool q_sw=false; public bool g_sw=false; bool w_sw=false;
    Vector3 player_first_position = new Vector3(-11,-1,0);
    Vector2 lookDirection = new Vector2(1,0);
    int int_look_Direction=1;
    Vector2 w_middle_position; //꼭지점
    Vector2 w_last_position; //w키 입력 이후 이동될 목표지점 좌표
    int w_para=0;
    float jump_height=2.0f; //점프 높이
    float jump_weith=5.0f; //점프거리

    Animator animator;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player_current_health = player_max_health;
        animator = GetComponent<Animator>();

        rigidbody2d.MovePosition(player_first_position);
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = rigidbody2d.position; //현재위치 백터
        float Speed=player_Speed;

        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }//lookDirection 을 위한 vector 랑 normalize

        if (horizontal==0) {
            animator.SetBool("isMoving", false);
        }
        else if(horizontal < 0) {
            animator.SetInteger ("direction", -1);
            animator.SetBool("isMoving", true);
            int_look_Direction=-1;
        }
        else if (horizontal > 0 ) {
            animator.SetInteger ("direction", 1);
            animator.SetBool("isMoving", true);
            int_look_Direction=1;
        }

        if (Input.GetKeyDown(KeyCode.Q)) { //q키 상호작용
            animator.SetBool("attacking",true);
            RaycastHit2D ball_hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 2.0f, LayerMask.GetMask("balls"));
            string ballN=ball_hit.collider.gameObject.name;
            if (ball_hit.collider != null) {
                Debug.Log("keydown Q : " + ball_hit.collider.gameObject);
                balls judge_ball = ball_hit.collider.GetComponent<balls>();
                if (judge_ball != null)
                {
                    if (judge_ball.hit(ballN)) {
                        curse_count = curse_count - 1;
                        Debug.Log("left curse_count : " + curse_count);
                    } else {
                        ChangeHealth(-1);
                    }
                } else { ;}
            }
        } else {
            animator.SetBool("attacking", false);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            w_last_position.x=position.x+(jump_weith*int_look_Direction); w_last_position.y=position.y;
            w_middle_position.x=position.x+((jump_weith*int_look_Direction)/2); w_middle_position.y=position.y+jump_height;
            w_sw=true;
            w_para=1;
        }

        if(w_para==1) {
            transform.position=Vector2.MoveTowards(position,w_middle_position,Speed*0.25f*Time.deltaTime);
            if (position.y==w_middle_position.y) {w_para=-1;}
        } else if (w_para==-1) {
            transform.position=Vector2.MoveTowards(position,w_last_position,Speed*0.25f*Time.deltaTime);
            if (position==w_last_position) {w_para=0; w_sw=false;}
        }
            
        if(!q_sw && !w_sw && !g_sw) { //이동이 이루어지는 곳
            position.x = position.x + (Speed * horizontal * Time.deltaTime);
        }
    
        if(w_para==0) {rigidbody2d.MovePosition(position);}
    }//update end

    public void ChangeHealth(int amount)
    {
        player_current_health = Mathf.Clamp(player_current_health + amount, 0, player_max_health);
        Debug.Log(player_current_health + "/" + player_max_health);
    }

    public void falling() {
        player_current_health=0;
        Debug.Log(player_current_health + "/" + player_max_health);
    }

    private void atk_start() {
        //player_Speed=0;
        q_sw=true;
        Debug.Log("atk_start()");
    }

    private void atk_end() {
        q_sw=false;
        Debug.Log("atk_end()");
    }

}//class end