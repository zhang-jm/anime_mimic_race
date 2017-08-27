﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour {
    public float yThreshold = -4.0f;

    GameManager gm;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        gm = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        //Debug.Log("clicked");
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        //Debug.Log("dragging");
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        if(curPosition.y > yThreshold)
        {
            transform.position = curPosition;
        }
    }

    private void OnMouseUp()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided");
        Collider c = GetComponent<Collider>();
        if (c != null)
        {
            c.isTrigger = true;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Destroy(this);
    }
}
