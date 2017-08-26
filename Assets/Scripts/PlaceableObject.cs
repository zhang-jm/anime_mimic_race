using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject {

    private string name;
    private string description;

    public PlaceableObject(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public string getName()
    {
        return name;
    }

    public string getDesc()
    {
        return description;
    }
}
