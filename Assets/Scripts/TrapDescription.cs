﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapDescription : MonoBehaviour {
    private GameManager gm;

    public GameObject ui;
    public TrapManager trapManager;

    private GameObject thisUi;
    private PlaceableObject trap;
    private GameObject spawnedObj;

    Vector3 screenPoint;
    Vector3 offset;

    // Use this for initialization
    void Start () {
        gm = GameManager.Instance;
        trapManager = TrapManager.getInstance();
        trap = trapManager.returnRandomTrap();

        Image i = GetComponent<Image>();
        i.sprite = trap.getSprite();

        thisUi = Instantiate(ui, Vector3.zero, Quaternion.identity);
        thisUi.gameObject.SetActive(false);
        thisUi.transform.SetParent(transform);
        thisUi.transform.position = new Vector3(transform.position.x, transform.position.y - 100, 0);

        Text name = thisUi.transform.GetChild(0).GetComponent<Text>();
        name.text = trap.getName();

        Text desc = thisUi.transform.GetChild(1).GetComponent<Text>();
        desc.text = trap.getDesc();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showUI()
    {
        thisUi.transform.position = new Vector3(transform.position.x, transform.position.y - 150, 0);
        thisUi.gameObject.SetActive(true);
    }

    public void hideUI()
    {
        thisUi.gameObject.SetActive(false);
    }

    public void spawnObject()
    {
        if (!gm.placingObject)
        {
            spawnedObj = Instantiate(trap.getPrefab(), Vector3.zero, Quaternion.identity);
            spawnedObj.transform.localScale = new Vector3(1, 1, 1);
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            spawnedObj.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            spawnedObj.transform.position = new Vector3(Camera.main.transform.position.x, curPosition.y - 30, 8);

            gm.placingObject = true;
            gm.addTrap(spawnedObj);
        }
    }

    public void dragObject()
    {
    }
}
