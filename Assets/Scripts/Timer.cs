using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerText;
    public Text playerText;

    public Canvas startPlacement;
    public Canvas trapPlacementUI;

    public float countdown = 30.0f;

    private GameManager gm;
    private bool placingTraps = false;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;
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

    public void startCountdown()
    {
        trapPlacementUI.gameObject.SetActive(true);
        startPlacement.gameObject.SetActive(false);
        placingTraps = true;
    }
}
