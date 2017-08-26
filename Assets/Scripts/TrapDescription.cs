using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapDescription : MonoBehaviour {

    public GameObject ui;
    public TrapManager trapManager;

    private GameObject thisUi;

	// Use this for initialization
	void Start () {
        trapManager = TrapManager.getInstance();
        PlaceableObject trap = trapManager.returnRandomTrap();

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
        thisUi.gameObject.SetActive(true);
    }

    public void hideUI()
    {
        thisUi.gameObject.SetActive(false);
    }
}
