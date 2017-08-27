using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour {

    public GameObject button;
    public TrapManager trapManager;

    private List<GameObject> buttons = new List<GameObject>();

	// Use this for initialization
	void Start () {
        //List<PlaceableObject> traps = trapManager.getTrapsToShow();

		for(int i = 0; i < 5; i++)
        {
            GameObject b = Instantiate(button, Vector3.zero, Quaternion.identity);
            b.transform.SetParent(transform);
            b.transform.position = new Vector3(transform.position.x + (i * 100) - 400, transform.position.y, 0);
            buttons.Add(b);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
