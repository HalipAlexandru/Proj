using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamePlayerController : MonoBehaviour
{
    public int hangTime = 100;
    private int timer = -1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer--;
        }

        if (timer == 0)
        {
            gameObject.transform.position = new Vector3(-9, -2, -2);
            timer = -1;
        }
        

        if(Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position = new Vector3(-9, 2, -2);
            timer = hangTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position = new Vector3(-9, -2, -2);
            timer = -1;
        }
    }

}
