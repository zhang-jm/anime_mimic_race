using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameMaster");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public int playerCount;
    public GameObject player;
    public List<GameObject> placedTraps;
    public List<GameObject> players;
    public int playerPlacingTraps = 1;
    public bool placingObject = false;

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        //what to do when game starts
    }

    public void SetPlayerCount(int players)
    {
        playerCount = players;
        Debug.Log("There are " + playerCount + " active players");
    }

    public int GetPlayerCount() {
        return playerCount;
    }

    public void addTrap(GameObject trap)
    {
        placedTraps.Add(trap);
        DontDestroyOnLoad(trap);
    }

   
}
