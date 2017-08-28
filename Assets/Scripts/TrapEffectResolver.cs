using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrapEffectResolver : MonoBehaviour {

    private GameManager gm;
    public PlayerController pc;
    public float showCanvasLength = 2.0f;

    private GameObject canvasToShow;
    private bool showingCanvas = false;
    private float showCanvasTimer = 0;

    private GameObject player;
    private GameObject temp;

    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;

    private GameObject cameraRef;
    private bool hidingCamera = false;
    private float hidingCameraTimer = 0;

    private bool randomButton = false;

    private GameObject winner;


    List<KeyCode> buttons;

    // Use this for initialization
    void Start () {
        gm = GameManager.Instance;

        canvasToShow = canvas2;

        if(gm.playerCount == 2)
        {
            canvasToShow = canvas2;
        }
        else if (gm.playerCount == 3)
        {
            canvasToShow = canvas3;
        }
        else if (gm.playerCount == 4)
        {
            canvasToShow = canvas4;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(showingCanvas)
        {
            showCanvasTimer += Time.deltaTime;

            if(showCanvasTimer >= showCanvasLength)
            {
                canvasToShow.SetActive(false);
                showingCanvas = false;
            }
        }

        if(hidingCamera)
        {
            hidingCameraTimer += Time.deltaTime;

            if (hidingCameraTimer >= showCanvasLength)
            {
                cameraRef.SetActive(true);
                hidingCamera = false;
            }
        }

        if(randomButton)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                checkValidInput(KeyCode.Alpha0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                checkValidInput(KeyCode.Alpha1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                checkValidInput(KeyCode.Alpha2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                checkValidInput(KeyCode.Alpha3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                checkValidInput(KeyCode.Alpha4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                checkValidInput(KeyCode.Alpha5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                checkValidInput(KeyCode.Alpha6);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                checkValidInput(KeyCode.Alpha7);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                checkValidInput(KeyCode.Alpha8);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                checkValidInput(KeyCode.Alpha9);
            }
        }
	}

    private void checkValidInput(KeyCode key)
    {
        for (int i = 0; i < 4; i++)
        {
            if (buttons[i] == key && i < pc.players.Count)
            {
                if (temp != null)
                {
                    Destroy(temp);
                }

                temp = new GameObject();
                temp.AddComponent<Trap>();
                temp.GetComponent<Trap>().trapType = Trap.TrapType.speed_up;

                resolveEffect(pc.players[i], temp);

                for (int j = 0; j < pc.players.Count; j++)
                {
                    if(i != j)
                    {
                        if (temp != null)
                        {
                            Destroy(temp);
                        }

                        temp = new GameObject();
                        temp.AddComponent<Trap>();
                        temp.GetComponent<Trap>().trapType = Trap.TrapType.slow_player_fixed;

                        resolveEffect(pc.players[j], temp);
                    }
                }

                randomButton = false;
            }
        }
    }

    public void resolveEffect(GameObject player, GameObject trap)
    {
        Trap t = trap.gameObject.GetComponent<Trap>();
        if(t ==  null)
        {
            return;
        }

        if(player == null)
        {
            return;
        }

        Player thisPlayer = player.GetComponent<Player>();

        canvasToShow.SetActive(false);
        showingCanvas = false;

        Debug.Log(t.trapType);
        switch (t.trapType)
        {
            case Trap.TrapType.stop_player:
                thisPlayer.resetStatusCounter();
                player.transform.position = new Vector3(trap.transform.position.x, player.transform.position.y, player.transform.position.z);
                thisPlayer.status = Player.Status.stopped;
                thisPlayer.controller.SetTrigger("tripped");
                break;

            case Trap.TrapType.slow_player_fixed:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.slowedForTime;
                break;

            case Trap.TrapType.slow_player_dynamic:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.slowed;
                break;

            case Trap.TrapType.speed_up:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.speedy;
                break;

            case Trap.TrapType.move_player_forward:
                player.transform.position += new Vector3(10, 0, 0);
                break;

            case Trap.TrapType.move_player_backward:
                player.transform.position -= new Vector3(10, 0, 0);
                break;

            case Trap.TrapType.switch_jump_buttons:
                showCanvasTimer = 0;
                showingCanvas = true;
                canvasToShow.SetActive(true);
                setUpCanvas(Trap.TrapType.switch_jump_buttons);
                break;

            case Trap.TrapType.fight_for_mouse:
                showCanvasTimer = 0;
                showingCanvas = true;
                canvasToShow.SetActive(true);
                setUpCanvas(Trap.TrapType.fight_for_mouse);
                break;

            case Trap.TrapType.press_random_button:
                showCanvasTimer = 0;
                showingCanvas = true;
                canvasToShow.SetActive(true);
                setUpCanvas(Trap.TrapType.press_random_button);
                randomButton = true;
                break;

            case Trap.TrapType.good:
                player.transform.position += new Vector3(10, 0, 0);

                foreach (GameObject p in pc.players)
                {
                    if (p != player)
                    {
                        player.transform.position -= new Vector3(10, 0, 0);
                    }
                }
                break;

            case Trap.TrapType.hide_screen:
                hidingCameraTimer = 0;
                cameraRef = player.transform.Find("Main Camera").gameObject;
                if(cameraRef != null)
                {
                    cameraRef.SetActive(false);
                    hidingCamera = true;
                }

                break;

            case Trap.TrapType.kill:
                if(temp != null)
                {
                    Destroy(temp);
                }

                temp = new GameObject();
                temp.AddComponent<Trap>();
                temp.GetComponent<Trap>().trapType = Trap.TrapType.stop_player;

                GameObject firstPlayer = getFirstPlayer();
                resolveEffect(firstPlayer, temp);
                break;

            case Trap.TrapType.switch_positions:
                List<int> playersLeft = new List<int>();
                playersLeft.Add(0);
                playersLeft.Add(1);
                playersLeft.Add(2);

                foreach (GameObject p in pc.players)
                {
                    int index = Random.Range(0, playersLeft.Count - 1);
                    int playerToSwapWith = playersLeft[index];
                    playersLeft.Remove(index);

                    p.transform.position = pc.players[playerToSwapWith].transform.position;
                }
                break;

            case Trap.TrapType.freeze_other:
                foreach(GameObject p in pc.players) {
                    if(p != player)
                    {
                        if (temp != null)
                        {
                            Destroy(temp);
                        }

                        temp = new GameObject();
                        temp.AddComponent<Trap>();
                        temp.GetComponent<Trap>().trapType = Trap.TrapType.freeze_self;

                        resolveEffect(p, temp);
                    }
                }
                break;

            case Trap.TrapType.freeze_self:
                thisPlayer.resetStatusCounter();
                thisPlayer.status = Player.Status.stopped;
                break;

            case Trap.TrapType.tentacle:
                if (t.wasHit == false)
                {
                    player.transform.position += new Vector3(10, 0, 0);
                }
                else
                {
                    thisPlayer.resetStatusCounter();
                    thisPlayer.status = Player.Status.slowed;
                }
                break;

            case Trap.TrapType.go_to_first_player:
                GameObject fp = getFirstPlayer();
                if(fp != null)
                {
                    player.transform.position = fp.transform.position;
                }
                break;

            case Trap.TrapType.go_to_last_player:
                GameObject lp = getLastPlayer();
                if (lp != null)
                {
                    player.transform.position = lp.transform.position;
                }
                break;

            case Trap.TrapType.finish:
                thisPlayer.status = Player.Status.finished;
                thisPlayer.setVelocityX(0);
                break;
        }

        t.wasHit = true;
    }

    public void resolveEffectOnExit(GameObject player, GameObject trap)
    {
        Trap t = trap.gameObject.GetComponent<Trap>();
        if (t == null)
        {
            return;
        }

        Player thisPlayer = player.GetComponent<Player>();

        switch (t.trapType)
        {
            case Trap.TrapType.slow_player_dynamic:
                thisPlayer.status = Player.Status.normal;
                break;

            case Trap.TrapType.tentacle:
                thisPlayer.status = Player.Status.normal;
                break;
        }

        t.wasHit = true;
    }

    private void setUpCanvas(Trap.TrapType trapType)
    {
        temp = new GameObject();
        temp.AddComponent<Trap>();

        switch (trapType)
        {
            case Trap.TrapType.fight_for_mouse:
                canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = "Player 1";
                canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = "Player 2";

                if (canvasToShow.transform.Find("P3") != null)
                {
                    canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = "Player 3";
                }

                if (canvasToShow.transform.Find("P4") != null)
                {
                    canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = "Player 4";
                }

                canvasToShow.transform.Find("Button").gameObject.SetActive(false);
                canvasToShow.transform.Find("Instructions").gameObject.SetActive(true);

                float val = Random.value;
                Debug.Log(val);

                if(val < 0.5)
                {
                    temp.GetComponent<Trap>().trapType = Trap.TrapType.speed_up;
                    canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Quick! Click the player you want to speed up!";
                }
                else
                {
                    temp.GetComponent<Trap>().trapType = Trap.TrapType.slow_player_fixed;
                    canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Quick! Click the player you want to slow down!";
                }
                break;

            case Trap.TrapType.press_random_button:
                List<KeyCode> possibleButtons = new List<KeyCode>();
                possibleButtons.Add(KeyCode.Alpha0);
                possibleButtons.Add(KeyCode.Alpha1);
                possibleButtons.Add(KeyCode.Alpha2);
                possibleButtons.Add(KeyCode.Alpha3);
                possibleButtons.Add(KeyCode.Alpha4);
                possibleButtons.Add(KeyCode.Alpha5);
                possibleButtons.Add(KeyCode.Alpha6);
                possibleButtons.Add(KeyCode.Alpha7);
                possibleButtons.Add(KeyCode.Alpha8);
                possibleButtons.Add(KeyCode.Alpha9);

                buttons = new List<KeyCode>();
                List<string> buttonStrings = new List<string>();

                for (int i = 0; i < 4; i++)
                {
                    int index = Random.Range(0, possibleButtons.Count - 1);
                    if (possibleButtons[index] == KeyCode.Alpha0)
                    {
                        buttonStrings.Add("0");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha1)
                    {
                        buttonStrings.Add("1");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha2)
                    {
                        buttonStrings.Add("2");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha3)
                    {
                        buttonStrings.Add("3");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha4)
                    {
                        buttonStrings.Add("4");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha5)
                    {
                        buttonStrings.Add("5");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha6)
                    {
                        buttonStrings.Add("6");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha7)
                    {
                        buttonStrings.Add("7");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha8)
                    {
                        buttonStrings.Add("8");
                    }
                    else if (possibleButtons[index] == KeyCode.Alpha9)
                    {
                        buttonStrings.Add("9");
                    }

                    buttons.Add(possibleButtons[index]);
                    possibleButtons.Remove(possibleButtons[index]);
                }

                canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = "Player 1: Press " + buttonStrings[0] + " to jump.";
                canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = "Player 2: Press " + buttonStrings[1] + " to jump.";

                if (canvasToShow.transform.Find("P3") != null)
                {
                    canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = "Player 3: Press " + buttonStrings[2] + " to jump.";
                }

                if (canvasToShow.transform.Find("P4") != null)
                {
                    canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = "Player 4: Press " + buttonStrings[3] + " to jump.";
                }

                canvasToShow.transform.Find("Button").gameObject.SetActive(false);
                canvasToShow.transform.Find("Instructions").gameObject.SetActive(true);

                canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Press your button as quickly as possible!";
                break;

            case Trap.TrapType.switch_jump_buttons:
                List<KeyCode> possibleJumpButtons = new List<KeyCode>(pc.jumpCodes);

                List<KeyCode> newJumpKeys = new List<KeyCode>();
                List<string> newJumpKeyStrings = new List<string>();

                for (int i = 0; i < 4; i++)
                {
                    int index = Random.Range(0, possibleJumpButtons.Count - 1);
                    if(possibleJumpButtons[index] == KeyCode.LeftControl)
                    {
                        newJumpKeyStrings.Add("LEFT CTRL");
                    }
                    else if (possibleJumpButtons[index] == KeyCode.Space)
                    {
                        newJumpKeyStrings.Add("SPACE");
                    }
                    else if (possibleJumpButtons[index] == KeyCode.UpArrow)
                    {
                        newJumpKeyStrings.Add("UP ARROW");
                    }
                    else if (possibleJumpButtons[index] == KeyCode.RightControl)
                    {
                        newJumpKeyStrings.Add("RIGHT CTRL");
                    }

                    newJumpKeys.Add(possibleJumpButtons[index]);
                    possibleJumpButtons.Remove(possibleJumpButtons[index]);
                }

                for (int i = 0; i < pc.players.Count; i++)
                { 
                    Player play = pc.players[i].GetComponent<Player>();
                    play.jumpKey = newJumpKeys[i];
                }

                canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = "Player 1: Press " + newJumpKeyStrings[0] + " to jump.";
                canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = "Player 2: Press " + newJumpKeyStrings[1] + " to jump.";

                if (canvasToShow.transform.Find("P3") != null)
                {
                    canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = "Player 3: Press " + newJumpKeyStrings[2] + " to jump.";
                }

                if (canvasToShow.transform.Find("P4") != null)
                {
                    canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = "Player 4: Press " + newJumpKeyStrings[3] + " to jump.";
                }

                canvasToShow.transform.Find("Button").gameObject.SetActive(false);
                canvasToShow.transform.Find("Instructions").gameObject.SetActive(true);

                canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Your jump buttons have switched!";
                break;

            case Trap.TrapType.finish:
                if(winner == pc.players[0])
                {
                    canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = "Winner!";
                } else
                {
                    canvasToShow.transform.Find("P1/Text").gameObject.GetComponent<Text>().text = ":(";
                }

                if (winner == pc.players[1])
                {
                    canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = "Winner!";
                }
                else
                {
                    canvasToShow.transform.Find("P2/Text").gameObject.GetComponent<Text>().text = ":(";
                }

                if (winner == pc.players[2])
                {
                    canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = "Winner!";
                }
                else
                {
                    canvasToShow.transform.Find("P3/Text").gameObject.GetComponent<Text>().text = ":(";
                }

                if (winner == pc.players[3])
                {
                    canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = "Winner!";
                }
                else
                {
                    canvasToShow.transform.Find("P4/Text").gameObject.GetComponent<Text>().text = ":(";
                }

                canvasToShow.transform.Find("Button").gameObject.SetActive(false);
                canvasToShow.transform.Find("Instructions").gameObject.SetActive(true);

                canvasToShow.transform.Find("Instructions/Text").gameObject.GetComponent<Text>().text = "Your jump buttons have switched!";
                break;

        }
    }

    public void onClick(int player)
    {
        Debug.Log(player + " click");
        resolveEffect(pc.players[player], temp);
    }

    private GameObject getFirstPlayer()
    {
        GameObject firstPlayer = null;
        float largestX = 0;

        foreach(GameObject player in pc.players) {
            if(player.transform.position.x > largestX)
            {
                largestX = player.transform.position.x;
                firstPlayer = player;
            }
        }

        return firstPlayer;
    }

    private GameObject getLastPlayer()
    {
        GameObject lastPlayer = null;
        float smallestX = 10000;

        foreach (GameObject player in pc.players)
        {
            if (player.transform.position.x < smallestX)
            {
                smallestX = player.transform.position.x;
                lastPlayer = player;
            }
        }

        return lastPlayer;
    }
}