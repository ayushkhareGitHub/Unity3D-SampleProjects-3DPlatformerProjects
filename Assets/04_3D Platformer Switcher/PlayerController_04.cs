using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController_04 : MonoBehaviour
{
    public float jumpStrength;
    public float movementStrength;

    public Action onHitObstacle;
    public Action onHitOrb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpStrength, 0));
        }

        if (Input.GetKeyDown("a"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                -movementStrength*Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }

        if (Input.GetKeyDown("d"))
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(
                movementStrength * Time.deltaTime,
                this.GetComponent<Rigidbody>().velocity.y,
                this.GetComponent<Rigidbody>().velocity.z
            );
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<ObstacleController_04>() != null)
        {
            GameObject.Destroy(this.gameObject);
            onHitObstacle();
        }

        if (col.gameObject.GetComponent<OrbController_04>() != null)
        {
            onHitOrb();
        }
    }
}
