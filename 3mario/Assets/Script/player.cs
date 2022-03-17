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
    bool isAttacking=false;
    Vector3 player_first_position = new Vector3(-11,-1,0);
    Vector2 lookDirection = new Vector2(1,0);

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
        bool keydown_w = Input.GetKeyDown(KeyCode.W);
        float Speed=player_Speed;
        Vector3 potal_coordinate;

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
        }
        else if (horizontal > 0 ) {
            animator.SetInteger ("direction", 1);
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.Q)) { //q키 상호작용
            attack();
            RaycastHit2D ball_hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 2.0f, LayerMask.GetMask("balls"));
            string ballN=ball_hit.collider.gameObject.name;
            if (ball_hit.collider != null) {
                Debug.Log("keydown Q : " + ball_hit.collider.gameObject);
                balls character = ball_hit.collider.GetComponent<balls>();
                if (character != null)
                {
                    curse_count = curse_count - character.hit(ballN);
                    Debug.Log("left curse_count : " + curse_count);
                }
            }

        } else {
            animator.SetBool("attacking", false);
        }


        Vector2 position = rigidbody2d.position; //현재위치 백터

        if (Input.GetKeyDown(KeyCode.G)) //g키 상호작용
        {
            RaycastHit2D potal_hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.0f, LayerMask.GetMask("potal"));
            string pointN= potal_hit.collider.gameObject.name;
            if (potal_hit.collider != null)
            {
                Debug.Log("keydown G : " + potal_hit.collider.gameObject);
                PointandPotal character = potal_hit.collider.GetComponent<PointandPotal>();
                if (character != null)
                {
                    potal_coordinate=character.updown(pointN);
                    rigidbody2d.MovePosition(potal_coordinate);
                }
            }
        } else {
            if(!isAttacking) { //이동이 이루어지는 곳
                position.x = position.x + (Speed * horizontal * Time.deltaTime);
                rigidbody2d.MovePosition(position);
            } else {
                rigidbody2d.MovePosition(position);
            }
        }


    }

    public void ChangeHealth(int amount)
    {
        player_current_health = Mathf.Clamp(player_current_health + amount, 0, player_max_health);
        Debug.Log(player_current_health + "/" + player_max_health);
    }

    public void falling() {
        player_current_health=0;
        Debug.Log(player_current_health + "/" + player_max_health);
    }

    public void attack() {
        animator.SetBool("attacking",true);
    }

    private void atk_start() {
        //player_Speed=0;
        isAttacking=true;
        Debug.Log("atk_start()");
    }

    private void atk_end() {
        isAttacking=false;
        Debug.Log("atk_end()");
    }

}//class end




/*
public class player : MonoBehaviour
{

    public float maxSpeed = 100f;
    public float Speed = 50f;
    private Rigidbody2D rigidBody;
    private Animator animator;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool isMoving = false;

    // Use this for initialization
    void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            moveRight = false;
            moveLeft = false;
            isMoving = false;
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            moveRight = false;

            if (!isMoving)
            {
                isMoving = true;
                animator.SetFloat("Direction", -1);
                animator.SetTrigger("Move");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            moveLeft = false;

            if (!isMoving)
            {
                isMoving = true;
                animator.SetFloat("Direction", 1);
                animator.SetTrigger("Move");
            }
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
            moveRight = false;
            moveLeft = false;
            animator.SetTrigger("Stand");
        }
    }

    void FixedUpdate()
    {
        float move = 0;

        if (moveLeft)
            move = -1;
        else if (moveRight)
            move = 1;
        

        if (move != 0)
        {
            if (Mathf.Abs(rigidBody.velocity.x) < maxSpeed)
            {
                Vector2 toMove = new Vector2(move * Speed, rigidBody.velocity.y);
                rigidBody.AddForce(toMove);
            }
            
        }
        else if(move == 0)
        {
            rigidBody.velocity = new Vector2(0, 0);
        }
    }
}
*/
