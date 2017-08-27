using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapEffectResolver : MonoBehaviour {

    private GameManager gm;
    public PlayerController pc;
    public float showCanvasLength = 2.0f;

    private GameObject canvasToShow;
    private bool showingCanvas;
    private float showCanvasTimer;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;

        canvasToShow = pc.canvas2;

        if(gm.playerCount == 2)
        {
            canvasToShow = pc.canvas2;
        }
        else if (gm.playerCount == 3)
        {
            canvasToShow = pc.canvas3;
        }
        else if (gm.playerCount == 4)
        {
            canvasToShow = pc.canvas4;
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
        GameObject p1;
        GameObject p2;
        GameObject p3;
        GameObject p4;

        p1 = canvasToShow.transform.Find("P1").gameObject;
        p1 = canvasToShow.transform.Find("P1").gameObject;
        p1 = canvasToShow.transform.Find("P1").gameObject;
        p1 = canvasToShow.transform.Find("P1").gameObject;
    }
}
