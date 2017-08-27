using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public TrapType trapType;
    public bool wasHit = false;

    public enum TrapType
    {
        stop_player, 
        slow_player_fixed,
        slow_player_dynamic, 
        speed_up,
        move_player_forward,
        move_player_backward,
        switch_space_buttons,
        fight_for_mouse,
        press_random_button,
        hide_screen,
        switch_positions,
        freeze_self,
        freeze_others,
        tentacle
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
