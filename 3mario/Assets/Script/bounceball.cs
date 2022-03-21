using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceball : MonoBehaviour
{
    
    public float bounceball_speed=2.5f; // 이동속도
    Vector3 pos; //현재위치
    float delta = 5.0f; // 좌(우)로 이동가능한 (x)최대값

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = pos;
        float acceleration = delta * Mathf.Abs(Mathf.Sin(Time.time * bounceball_speed));
        // 좌우 이동의 최대치 및 반전 처리를 이렇게 한줄에 멋있게 하네요.
        v.y += acceleration;

        transform.position = v;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player controller = other.GetComponent<player>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}
