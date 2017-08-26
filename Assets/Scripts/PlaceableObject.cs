using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject {

    private string name;
    private string description;
    private GameObject prefab;

    public PlaceableObject(string name, string description, GameObject prefab)
    {
        this.name = name;
        this.description = description;
        this.prefab = prefab;
    }

    public string getName()
    {
        return name;
    }

    public string getDesc()
    {
        return description;
    }

    public GameObject getPrefab()
    {
        return prefab;
    }
}
