using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxVelocity = 10.0f;
    public float acceleration = 1.5f;
    public float gravity = 10.0f;
    public float jumpHeight = 3.0f;
    public float floatTime = 1.0f;

    private float velocityX = 0;
    private float velocityY = 0;
    private float startingHeight = 0;
    private float timeFloated = 0;

    private bool jumping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if(velocityX < maxVelocity) //set max running speed
        {
            //v1 = v0 + at
            velocityX += acceleration * Time.deltaTime;
        }

        //p1 = p0 + vt
        transform.position += Vector3.right * velocityX * Time.deltaTime;

        //jump
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!jumping)
            {
                jumping = true;
                velocityY = -5.0f;
                startingHeight = transform.position.y;
            }
        }

        if (jumping)
        {
            velocityY += gravity * Time.deltaTime;
            transform.position -= Vector3.up * velocityY * Time.deltaTime;

            if(transform.position.y < startingHeight)
            {
                transform.position = new Vector3(transform.position.x, startingHeight, transform.position.z);
                jumping = false;
            }
        }

        //Debug.Log("Y velocity: " + velocityY);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision detected!");

        if (other.gameObject.tag == "platform")
        {
            if (jumping)
            {
                jumping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger detected!");

        if (other.gameObject.tag == "platform")
        {
            if (jumping)
            {
                jumping = false;
            }
        }
    }
}
