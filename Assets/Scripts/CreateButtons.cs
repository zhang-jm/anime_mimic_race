using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour {

    public GameObject button;

    private List<GameObject> buttons = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 5; i++)
        {
            Debug.Log("asdf");
            GameObject b = Instantiate(button, Vector3.zero, Quaternion.identity);
            b.transform.SetParent(transform);
            b.transform.position = new Vector3((i * 100) + 200, transform.position.y, 0);
            buttons.Add(b);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
