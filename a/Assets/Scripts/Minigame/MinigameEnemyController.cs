using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameEnemyController : MonoBehaviour
{
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);

        if (gameObject.transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
