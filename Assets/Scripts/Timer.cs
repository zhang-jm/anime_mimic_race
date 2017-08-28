using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerText;
    public Text playerText;
    public Text playerText2;

    public Canvas startPlacement;
    public Canvas trapPlacementUI;

    public float countdown = 2.0f;

    private GameManager gm;
    private bool placingTraps = false;
    public Camera placementCamera;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;
        placementCamera.transform.Translate((850f/gm.playerCount) * (gm.playerPlacingTraps - 1), 0f, 0f);
        playerText2.text = "Player " + gm.playerPlacingTraps;
        playerText.text = "Player " + gm.playerPlacingTraps + " is placing traps.";
	}

    // Update is called once per frame
    void Update()
    {
        if (placingTraps == true) { 
            countdown -= Time.deltaTime;
            timerText.text = "Time remaining: " + (int)countdown + "s";
            if(countdown < 5.0f)
            {
                timerText.color = Color.red;
            }

            if (countdown <= 0.0f)
            {
                timerText.text = "Time up!";

                if (gm.placingObject == false)
                {
                    gm.playerPlacingTraps++;
                    
                    if (gm.playerPlacingTraps > gm.playerCount)
                    {
                        SceneManager.LoadScene(2);
                    }
                    else
                    {
                        SceneManager.LoadScene(1);
                    }
                }
            }
        }
	}

    public void startCountdown()
    {
        trapPlacementUI.gameObject.SetActive(true);
        startPlacement.gameObject.SetActive(false);
        placingTraps = true;
    }
}
