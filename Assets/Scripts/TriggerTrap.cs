using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("TrapTriggered");
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("TrapTriggered");
    }
}
