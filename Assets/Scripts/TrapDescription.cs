using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDescription : MonoBehaviour {

    public GameObject ui;

    private GameObject thisUi;

	// Use this for initialization
	void Start () {
        thisUi = Instantiate(ui, Vector3.zero, Quaternion.identity);
        thisUi.gameObject.SetActive(false);
        thisUi.transform.SetParent(transform);
        thisUi.transform.position = new Vector3(transform.position.x, transform.position.y - 100, 0);
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
