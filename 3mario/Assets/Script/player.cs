using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float player_Speed = 60f;
    public int player_max_health=3;
    int player_current_health;
    int q_timer;

    Animator animator;

    void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player_current_health = player_max_health;
        animator = GetComponent<Animator>();
    }

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        bool keydown_q = Input.GetKeyDown(KeyCode.Q);
        bool keydown_w = Input.GetKeyDown(KeyCode.W);
        float Speed=player_Speed;


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

        if (keydown_q) {
            attack();
        } else {
            animator.SetBool("attacking", false);
        }

        Vector2 position = rigidbody2d.position;
        position.x = position.x + (Speed * horizontal * Time.deltaTime);

        rigidbody2d.MovePosition(position);

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

    public void q_start() {
        player_Speed=0;
    }

    public void q_end() {
        player_Speed=60f;
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
