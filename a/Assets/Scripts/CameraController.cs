using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float mouseSpeed = 5f;
    public float pushForce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float heightAxis = Input.GetAxis("Height");

        //movement
        transform.Translate(Vector3.right * Time.deltaTime * horizontalAxis * moveSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * verticalAxis * moveSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * heightAxis * moveSpeed, Space.World);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //rotation
        transform.Rotate(Vector3.up * mouseX * mouseSpeed);
        transform.Rotate(Vector3.left * mouseY * mouseSpeed);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);

        //rotation limits
        if (transform.rotation.eulerAngles.x < 280 && transform.rotation.eulerAngles.x > 90)
        {
            transform.rotation = Quaternion.Euler(280, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else if(transform.rotation.eulerAngles.x > 80 && transform.rotation.eulerAngles.x < 270)
        {
            transform.rotation = Quaternion.Euler(80, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit enemyHit;
        if (Physics.Raycast(ray, out enemyHit))
        {
            //enemyHit.collider.tag == "Enemy" &&
            if (Input.GetMouseButtonDown(0) && enemyHit.collider.gameObject.GetComponent<Rigidbody>())
            {
                enemyHit.collider.gameObject.GetComponent<Rigidbody>().AddForce((enemyHit.collider.gameObject.transform.position - transform.position) * pushForce, ForceMode.Impulse);
                //enemyHit.collider.gameObject.GetComponent<EnemyController>().TakeDamage();
            }
            Debug.DrawRay(ray.origin, ray.direction * enemyHit.distance);
        }


    }
}
