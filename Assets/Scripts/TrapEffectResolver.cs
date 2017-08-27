using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrapEffectResolver : MonoBehaviour {

    private GameManager gm;
    public PlayerController pc;
    public float showCanvasLength = 2.0f;

    private GameObject canvasToShow;
    private bool showingCanvas = false;
    private float showCanvasTimer;

    private GameObject player;
    private GameObject temp;

    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;

    // Use this for initialization
    void Start () {
        gm = GameManager.Instance;

        canvasToShow = canvas2;

        if(gm.playerCount == 2)
        {
            canvasToShow = canvas2;
        }
        else if (gm.playerCount == 3)
        {
            canvasToShow = canvas3;
        }
        else if (gm.playerCount == 4)
        {
            canvasToShow = canvas4;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(showingCanvas)
        {
            showCanvasTimer += Time.deltaTime;

            if(showCanvasTimer >= showCanvasLength)
            {
                canvasToShow.SetActive(false);
                showingCanvas = false;
            }
        }
	}

    public void resolveEffect(GameObject player, GameObject trap)
    {
        Trap t = trap.gameObject.GetComponent<Trap>();
        if(t ==  null)
        {
            return;
        }

        Player thisPlayer = player.GetComponent<Player>();

        canvasToShow.SetActive(false);
        showingCanvas = false;

        Debug.Log(t.trapType);
        switch (t.trapType)
        {
            case Trap.TrapType.stop_player:
                thisPlayer.resetStatusCounter();
                player.transform.position = new Vector3(trap.transform.position.x, player.transform.position.y, player.transform.position.z);
                thisPlayer.status = Player.Status.stopped;
                thisPlayer.controller.SetTrigger("tripped");
                break;

            case Trap.TrapType.speed_up:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.speedy;
                break;

            case Trap.TrapType.slow_player_dynamic:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.slowed;
                break;

            case Trap.TrapType.slow_player_fixed:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.slowedForTime;
                break;

            case Trap.TrapType.tentacle:
                if(t.wasHit == false)
                {
                    player.transform.position += new Vector3(10, 0, 0);
                } else
                {
                    thisPlayer.resetStatusCounter();
                    thisPlayer.status = Player.Status.slowed;
                }
                break;

            case Trap.TrapType.fight_for_mouse:
                showingCanvas = true;
                canvasToShow.SetActive(true);
                setUpCanvas(Trap.TrapType.fight_for_mouse);
                break;

            case Trap.TrapType.finish:
                thisPlayer.status = Player.Status.finished;
                thisPlayer.setVelocityX(0);
                break;
        }

        t.wasHit = true;
    }

    public void resolveEffectOnExit(GameObject player, GameObject trap)
    {
        Trap t = trap.gameObject.GetComponent<Trap>();
        if (t == null)
        {
            return;
        }

        Player thisPlayer = player.GetComponent<Player>();

        switch (t.trapType)
        {
            case Trap.TrapType.slow_player_dynamic:
                thisPlayer.status = Player.Status.normal;
                break;

            case Trap.TrapType.tentacle:
                thisPlayer.status = Player.Status.normal;
                break;
        }

        t.wasHit = true;
    }

    private void setUpCanvas(Trap.TrapType trapType)
    {
        canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = "Player 1";
        canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = "Player 2";

        if (canvasToShow.transform.Find("P3") != null)
        {
           canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = "Player 3";
        }

        if(canvasToShow.transform.Find("P4") != null)
        {
            canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = "Player 4";
        }

        temp = new GameObject();
        temp.AddComponent<Trap>();

        switch (trapType)
        {
            case Trap.TrapType.fight_for_mouse:
                canvasToShow.transform.Find("Button").gameObject.SetActive(false);
                canvasToShow.transform.Find("Instructions").gameObject.SetActive(true);

                float val = Random.value;
                Debug.Log(val);

                if(val < 0.5)
                {
                    temp.GetComponent<Trap>().trapType = Trap.TrapType.speed_up;
                    canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Quick! Click the player you want to speed up!";
                }
                else
                {
                    temp.GetComponent<Trap>().trapType = Trap.TrapType.slow_player_fixed;
                    canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Quick! Click the player you want to slow down!";
                }
                break;
        }
    }

    public void onClick(int player)
    {
        Debug.Log(player + " click");
        resolveEffect(pc.players[player], temp);
    }
}