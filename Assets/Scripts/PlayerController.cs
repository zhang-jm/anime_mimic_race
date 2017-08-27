using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public List<GameObject> players;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;
        spawnPlayers();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnPlayers()
    {
        for (int i = 0; i < gm.GetPlayerCount(); i++)
        {
            players.Add(Instantiate(player));
        }

        if(gm.GetPlayerCount() == 2)
        {
            GameObject player1 = players[0];
            GameObject player2 = players[1];
            Camera p1Cam = player1.transform.Find("Main Camera").GetComponent<Camera>();
            p1Cam.rect = new Rect(0, 0, 1, 0.5f);
            Camera p2Cam = player2.transform.Find("Main Camera").GetComponent<Camera>();
            p2Cam.rect = new Rect(0, 0.5f, 1, 0.5f);
        }
        else if(gm.GetPlayerCount() == 3)
        {
            GameObject player1 = players[0];
            GameObject player2 = players[1];
            GameObject player3 = players[2];
            Camera p1Cam = player1.transform.Find("Main Camera").GetComponent<Camera>();
            p1Cam.rect = new Rect(0, 0, 1, 0.33f);
            Camera p2Cam = player2.transform.Find("Main Camera").GetComponent<Camera>();
            p2Cam.rect = new Rect(0, 0.33f, 1, 0.34f);
            Camera p3Cam = player3.transform.Find("Main Camera").GetComponent<Camera>();
            p3Cam.rect = new Rect(0, 0.67f, 1, 0.33f);
        }
        else if (gm.GetPlayerCount() == 4)
        {
            GameObject player1 = players[0];
            GameObject player2 = players[1];
            GameObject player3 = players[2];
            GameObject player4 = players[3];
            Camera p1Cam = player1.transform.Find("Main Camera").GetComponent<Camera>();
            p1Cam.rect = new Rect(0, 0, 0.5f, 0.5f);
            Camera p2Cam = player2.transform.Find("Main Camera").GetComponent<Camera>();
            p2Cam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
            Camera p3Cam = player3.transform.Find("Main Camera").GetComponent<Camera>();
            p3Cam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            Camera p4Cam = player4.transform.Find("Main Camera").GetComponent<Camera>();
            p4Cam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        }
    }
}
