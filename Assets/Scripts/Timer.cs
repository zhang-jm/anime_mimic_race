using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerText;

    public float countdown = 30.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        timerText.text = "Time remaining: " + (int) countdown + "s";
        
        if(countdown <= 0.0f)
        {
            timerText.text = "Time up!";
            SceneManager.LoadScene(2);
        }
	}
}
