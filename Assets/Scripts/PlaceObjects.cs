﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlaceObjects : MonoBehaviour {

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;
        List<GameObject> placedObjects = gm.placedTraps;

        foreach (GameObject obj in placedObjects)
        {
            Destroy(obj.GetComponent<ObjectPlacer>());
            Destroy(obj.GetComponent<EventTrigger>());
            Destroy(obj.GetComponent<Rigidbody>());

            obj.GetComponent<Collider>().isTrigger = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
