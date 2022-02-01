using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;

    private float startDelay = 2f;
    private float spawInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Vector3 position = new Vector3();

        if ((int)Random.Range(0, 2) == 0)
            position = enemy.transform.position;
        else
            position = enemy.transform.position + new Vector3(0, 4, 0);

        Instantiate(enemy, position, enemy.transform.rotation);
    }
}
