using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour {

    Animator anim;

    private bool triggered = false;
    private float triggeredCounter = 0;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            triggeredCounter += Time.deltaTime;
            if (triggeredCounter > 2.5)
            {
                anim.SetTrigger("ResetTrap");
                triggered = false;
                triggeredCounter = 0;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.SetTrigger("TrapTriggered");
            triggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
