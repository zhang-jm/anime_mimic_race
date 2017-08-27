using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject bearTrap;
    public GameObject staticBearTrap;
    public Sprite bearTrapSprite;

    private static TrapManager instance = null;

    List<PlaceableObject> possibleTrapList;

    // Use this for initialization
    void Start()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        possibleTrapList = new List<PlaceableObject>();
        addTraps();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static TrapManager getInstance()
    {
        return instance;
    }

    private void addTraps()
    {
        possibleTrapList.Add(new PlaceableObject("Bear Trap", "Stops any player who steps on this trap for 3 seconds.", bearTrap, bearTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Toast", "Gives a 1 second speed boost for the first player to pick it up.", bearTrap, bearTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Poison Toast", "Slows down any player who steps on this trap for 3 seconds.", bearTrap, bearTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Bear Trap", "Stops any player who steps on this trap for 3 seconds.", bearTrap, bearTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Bear Trap", "Stops any player who steps on this trap for 3 seconds.", bearTrap, bearTrapSprite));
    }

    public List<PlaceableObject> getTrapsToShow()
    {
        List<PlaceableObject> trapsToShow = new List<PlaceableObject>();
        trapsToShow.Add(possibleTrapList[0]);
        trapsToShow.Add(possibleTrapList[0]);
        trapsToShow.Add(possibleTrapList[0]);
        trapsToShow.Add(possibleTrapList[0]);
        trapsToShow.Add(possibleTrapList[0]);
        return trapsToShow;
    }

    public PlaceableObject returnRandomTrap()
    {
        int index = Random.Range(0, possibleTrapList.Count - 1);
        PlaceableObject trapToReturn = possibleTrapList[index];
        possibleTrapList.RemoveAt(index);
        return trapToReturn;
    }
}

