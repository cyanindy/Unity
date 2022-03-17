using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointandPotal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 updown(string pointname) {
        Vector3 position=new Vector3 (0,0,0);

        if (pointname=="point_s1_1f_u") { //s1 포탈 좌표
            position.x=19.0f; position.y=7.4f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s1_2f_d") {
            position.x=21.7f; position.y=-1.0f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s1_2f_u") {
            position.x=-8.5f; position.y=15.6f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s1_3f_d") {
            position.x=-13.0f; position.y=7.5f; position.z=0.0f;
            return position;
        }

        else if (pointname=="s1_potal") {
            position.x=59.0f; position.y=16.0f; position.z=0.0f;
            return position;
        }

        else if (pointname=="point_s2_3f_d") {
            position.x=84.2f; position.y=7.5f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s2_2f_u") {
            position.x=77.3f; position.y=16.0f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s2_2f_d") {
            position.x=50.0f; position.y=-0.7f; position.z=0.0f;
            return position;
        }
        else if (pointname=="point_s2_1f_u") {
            position.x=53.0f; position.y=7.5f; position.z=0.0f;
            return position;
        }
        else {
            return position;
        }
    }
}
