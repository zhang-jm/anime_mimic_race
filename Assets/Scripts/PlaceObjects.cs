using System.Collections;
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
            Debug.Log("init");
            Destroy(obj.GetComponent<Rigidbody>());

            Collider c = obj.GetComponent<Collider>();
            if (c != null)
            {
                c.isTrigger = true;
            }

            obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, 8.0f);
            obj.transform.localScale= new Vector3(1f, 1f, 1f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
