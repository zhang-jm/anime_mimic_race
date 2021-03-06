﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public GameObject bearTrap;
    public Sprite bearTrapSprite;

    public GameObject tentacleField;
    public Sprite tentacleFieldSprite;

    public GameObject goodChest;
    public Sprite goodChestSprite;

    public GameObject badChest;
    public Sprite badChestSprite;

    public GameObject spaghettiTrap;
    public Sprite spaghettiTrapSprite;

    public GameObject buttonTrap;
    public Sprite buttonTrapSprite;

    public GameObject coinTrap;
    public Sprite coinTrapSprite;

    public GameObject badCoinTrap;
    public Sprite badCoinTrapSprite;

    public GameObject knifeTrap;
    public Sprite knifeTrapSprite;

    public GameObject deathNoteTrap;
    public Sprite deathNoteTrapSprite;

    public GameObject glassesTrap;
    public Sprite glassesTrapSprite;

    public GameObject starTrap;
    public Sprite starTrapSprite;

    public GameObject pillowTrap;
    public Sprite pillowTrapSprite;

    public GameObject magnetTrap;
    public Sprite magnetTrapSprite;

    public GameObject badMagnetTrap;
    public Sprite badMagnetTrapSprite;

    public GameObject stopwatchTrap;
    public Sprite stopwatchTrapSprite;

    public GameObject badStopwatchTrap;
    public Sprite badStopwatchTrapSprite;

    public GameObject ufoTrap;
    public Sprite ufoTrapSprite;

    public GameObject toast;
    public Sprite toastSprite;

    public GameObject poisonToast;
    public Sprite poisonToastSprite;
           

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
        /* Big Red Button
	Will you press this button? 

Box of Spaghetti
	This is a box of spaghetti. It says "Bring 4 - 6 quarts of water to a rolling boil, add salt to taste. Add contents of the package to boiling water. Return to a boil. For authentic "al dente" pasta, boil uncovered, stirring occasionally for 9 minutes. ... Remove from heat. Serve immediately with your favorite Barilla sauce."

Coin
Are you feeling lucky, punk?

Yandere Knife
the best naifu for your waifu

Death Note
Light did nothing wrong

Glasses
Look with your special eyes
	
Ninja Star
We had a ninja but we ran out of time.

Pillow
	Pillow fight! 

Senpai Magnet
	Notice Me Senpai! Do you have a strong attraction to senpai? Now you can get all of the Senpai to notice you.  

Stopwatch
	Za Wārudo!

UFO
“ZzZ ZzZ zZz beep bop” Did you hear that?!
*/
        possibleTrapList.Add(new PlaceableObject("Bear Trap", "Stops any player who steps on this trap for 3 seconds.", bearTrap, bearTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Tentacle Field", "ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn", tentacleField, tentacleFieldSprite));
        possibleTrapList.Add(new PlaceableObject("Toast", "Gives a 1 second speed boost for the first player to pick it up.", toast, toastSprite));
        possibleTrapList.Add(new PlaceableObject("Poison Toast", "Slows down any player who steps on this trap for 3 seconds.", poisonToast, poisonToastSprite));
        possibleTrapList.Add(new PlaceableObject("Box of Spaghetti", "This is a box of spaghetti. It says Bring 4 - 6 quarts of water to a rolling boil, add salt to taste.Add contents of the package to boiling water.Return to a boil. For authentic al dente pasta, boil uncovered, stirring occasionally for 9 minutes. ... Remove from heat. Serve immediately with your favorite Barilla sauce.", spaghettiTrap, spaghettiTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Button", "Will you push the big red button?", buttonTrap, buttonTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Coin", "Everything for a price", coinTrap, coinTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Coin", "Everything for a price", badCoinTrap, badCoinTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Knife of Greater Yandere Prowess", "The best naifu of you have ever seen", knifeTrap, knifeTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Death Note", "Light did nothing wrong", deathNoteTrap, deathNoteTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Glasses", "Look with your special eyes", glassesTrap, glassesTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Throwing Star", "We had a ninja but we ran out of time", starTrap, starTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Pillow", "Pillow fight!", pillowTrap, pillowTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Senpai Magnet", "Surely I can get closer to senpai with this", magnetTrap, magnetTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Senpai Magnet", "Surely I can get closer to senpai with this", badMagnetTrap, badMagnetTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Stopwatch", "ZA WARUDO!!!!", stopwatchTrap, stopwatchTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Stopwatch", "ZA WARUDO!!!!", badStopwatchTrap, badStopwatchTrapSprite));
        possibleTrapList.Add(new PlaceableObject("UFO", "The truth is out there", ufoTrap, ufoTrapSprite));
        possibleTrapList.Add(new PlaceableObject("Chest", "What gachapon debauchery is this?", goodChest, goodChestSprite));
        possibleTrapList.Add(new PlaceableObject("Chest", "What gachapon debauchery is this?", badChest, badChestSprite));


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

