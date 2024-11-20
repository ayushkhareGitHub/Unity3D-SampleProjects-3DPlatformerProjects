using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_03 : MonoBehaviour
{
    public int direction = 1;

    public float moveForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(
            moveForce*direction*Time.deltaTime,
            0,
            0
        );
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<ObstacleController_03>() != null)
        {
            GameObject.Destroy(this.gameObject);
            GameObject.Destroy(col.gameObject);
        }
    }
}
