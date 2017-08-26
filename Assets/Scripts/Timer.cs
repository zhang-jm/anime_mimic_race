using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;

    private float countdown;

	// Use this for initialization
	void Start () {
        countdown = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        timerText.text = "Time remaining: " + (int) countdown + "s";
        
        if(countdown <= 0.0f)
        {
            timerText.text = "Time up!";
        }
	}
}
