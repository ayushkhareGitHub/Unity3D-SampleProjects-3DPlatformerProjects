using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController_03 : MonoBehaviour
{
    public float jumpForce;
    public float moveForce;

    public GameObject bulletPrefab;

    public Action onHitObstacle;
    public Action onHitOrb;

    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
            bulletObject.transform.position = new Vector3(
                this.transform.position.x+direction,
                this.transform.position.y,
                this.transform.position.z
            );

            BulletController_03 bullet = bulletObject.GetComponent<BulletController_03>();
            bullet.direction = direction;
        }

        if (Input.GetKeyDown("space"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetKeyDown("a"))
        {
            direction = -1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                -moveForce*Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }

        if (Input.GetKeyDown("d"))
        {
            direction = 1;
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                moveForce * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<ObstacleController_03>() != null)
        {
            GameObject.Destroy(this.gameObject);
            onHitObstacle();
        }

        if (col.gameObject.GetComponent<OrbController_03>() != null)
        {
            Time.timeScale = 0;
            onHitOrb();
        }
    }
}
