using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject {

    private string name;
    private string description;
    private GameObject prefab;
    private Sprite sprite;

    public PlaceableObject(string name, string description, GameObject prefab, Sprite sprite)
    {
        this.name = name;
        this.description = description;
        this.prefab = prefab;
        this.sprite = sprite;
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

    public Sprite getSprite()
    {
        return sprite;
    }
}
