using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public float speed=2.5f; // 이동속도
    public int direction;
    Vector2 position; //현재위치
    public Vector2 first_position;

    public float start_timer=2;
    public GameObject missile_range;

    // Start is called before the first frame update
    void Start()
    {
        transform.position=first_position;
    }

    // Update is called once per frame
    void Update()
    {

        if(start_timer>0) {
            position=first_position;
            start_timer-=Time.deltaTime;
        } else {
            position.x=position.x + speed*direction*Time.deltaTime;
        }

        float cur_mis_x = position.x;
        float mis_range_x  = missile_range.transform.position.x;
        if ( cur_mis_x <= mis_range_x+0.5 && cur_mis_x >= mis_range_x-0.5) { 
            reset_position(); 
        } //위치 리셋
        
        transform.position=position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player controller = other.GetComponent<player>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            reset_position();
        }
    }

    public void reset_position() {
        position=first_position;
    }
}
