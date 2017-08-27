using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTrap : MonoBehaviour {

    public bool firstPlayerHit = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(!firstPlayerHit && other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position += new Vector3(10, 0, 0);
            firstPlayerHit = true;
        }
    }
}
