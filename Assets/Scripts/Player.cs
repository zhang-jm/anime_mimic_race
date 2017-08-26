using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Vector3 startingPosition = new Vector3(-10f, -2.5f);

    public float maxVelocity = 10.0f;
    public float acceleration = 1.5f;
    public float gravity = 10.0f;

    public float trapStopAmtTime = 3.0f;

    public KeyCode jumpKey = KeyCode.Space;

    private float velocityX = 0;
    private float velocityY = 0;
    private float startingHeight = 0;
    private float timeFloated = 0;
    private float statusCounter = 0;

    private bool jumping = false;
    private Status status = Status.normal;

    public enum Status
    {
        normal,
        slowed,
        stopped
    }

	// Use this for initialization
	void Start () {
        transform.position = startingPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if(status == Status.stopped)
        {
            statusCounter += Time.deltaTime;
            if(statusCounter >= trapStopAmtTime)
            {
                statusCounter = 0;
                status = Status.normal;
            }

            return;
        }

        if(velocityX < maxVelocity) //set max running speed
        {
            //v1 = v0 + at
            velocityX += acceleration * Time.deltaTime;
        }

        //p1 = p0 + vt
        transform.position += Vector3.right * velocityX * Time.deltaTime;

        //jump
        if(Input.GetKeyDown(jumpKey))
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

            if(transform.position.y < startingPosition.y)
            {
                transform.position = new Vector3(transform.position.x, startingPosition.y, transform.position.z);
                jumping = false;
            }
        }

        //Debug.Log("Y velocity: " + velocityY);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("collision detected!");

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
        //Debug.Log("trigger detected!");

        if (other.gameObject.tag == "platform")
        {
            if (jumping)
            {
                jumping = false;
            }
        } else if (other.gameObject.tag == "stopping_trap")
        {
            transform.position = new Vector3(other.gameObject.transform.position.x, transform.position.y, transform.position.z);
            status = Status.stopped;
            velocityX = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       // Debug.Log("collision exit!");

        if (collision.gameObject.tag == "platform")
        {
            if (transform.position.y > startingPosition.y && !jumping)
            {
                velocityY = 5.0f;
                jumping = true;
                //Debug.Log("Y velocity: " + velocityY);
            }
        }
    }
}
