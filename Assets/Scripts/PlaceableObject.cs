using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject {

    private string name;
    private string description;
    private GameObject prefab;
    private GameObject staticPrefab;
    private Sprite sprite;

    public PlaceableObject(string name, string description, GameObject prefab, GameObject staticPrefab, Sprite sprite)
    {
        this.name = name;
        this.description = description;
        this.prefab = prefab;
        this.staticPrefab = staticPrefab;
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

    public GameObject getStaticPrefab()
    {
        return staticPrefab;
    }

    public Sprite getSprite()
    {
        return sprite;
    }
}
