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

    void Awake() {
        _instance = this;
        DontDestroyOnLoad(gameObject);
	}

    private void Start()
    {
        //what to do when game starts
    }
}
