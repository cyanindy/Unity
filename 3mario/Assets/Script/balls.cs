using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int hit(string ballname) {
        ball=GameObject.Find(ballname);
        Destroy(ball);
        if (ballname=="ball_blue_1" || ballname=="ball_blue_2" || ballname=="ball_blue_3") {
            return 1;
        }
        else {
            return 0;
        }
    }
}
