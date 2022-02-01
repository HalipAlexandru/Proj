using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    //public GameObject healthBarUI;
    GameObject player;
    public Slider slider;
    public float health;
    public float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        slider.transform.position = transform.position + new Vector3(0, 2f, 0);
        slider.transform.LookAt(player.transform);
        slider.value = health / maxHealth;
    }

    public void TakeDamage()
    {
        if(health > 0)
            health -= 10;
    }
}
