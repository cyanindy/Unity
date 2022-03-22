using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_range : MonoBehaviour
{
    public GameObject bomb;
    string bombname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player controller = other.GetComponent<player>();
        bombname=this.gameObject.name;
        
        if (controller != null)
        {
            bomb.GetComponent<bomb>().onRange();
            bomb.GetComponent<bomb>().bombsGannaExp(bombname);
            //Debug.Log("bomb_range script : " + bombname);
        }
    }
}
