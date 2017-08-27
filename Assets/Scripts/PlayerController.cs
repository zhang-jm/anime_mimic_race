using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject player;
    public List<GameObject> players;
    public Color[] playerColors;
    public KeyCode[] jumpCodes;

    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = GameManager.Instance;
        spawnPlayers();
        playerColors = new Color[4];
        jumpCodes = new KeyCode[4];
        AssignColors();
        AssignJump();
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

            canvas2.SetActive(true);
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

            canvas3.SetActive(true);
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

            canvas4.SetActive(true);
        }
    }
    public void AssignColors() {
        //colors
        playerColors[0] = new Color(206/255f, 34/255f, 129/255f);
        playerColors[1] = new Color(72/255f, 209/255f, 204/255f);
        playerColors[2] = new Color(144/255f, 197/255f, 127/255f);
        playerColors[3] = new Color(212/225f, 201/255f, 87/255f);

        for (int x = 0; x < players.Count; x++)
        {
            players[x].GetComponent<Player>().hairs[0].GetComponent<SkinnedMeshRenderer>().material.color = playerColors[x];
            players[x].GetComponent<Player>().hairs[1].GetComponent<SkinnedMeshRenderer>().material.color = playerColors[x];

        }
    }

    public void AssignJump()
    {
        //controls
        jumpCodes[0] = KeyCode.Space;
        jumpCodes[1] = KeyCode.LeftControl;
        jumpCodes[2] = KeyCode.RightControl;
        jumpCodes[3] = KeyCode.UpArrow;

        for (int x = 0; x < players.Count; x++)
        {
            players[x].GetComponent<Player>().jumpKey = jumpCodes[x];
       
        }
    }

    public void start()
    {
        for (int x = 0; x < players.Count; x++)
        {
            players[x].GetComponent<Player>().startMoving();

        }
    }

}
