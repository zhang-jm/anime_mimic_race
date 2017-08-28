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
        switch_jump_buttons,
        fight_for_mouse,
        press_random_button,
        good,
        hide_screen,
        kill,
        switch_positions,
        freeze_other,
        freeze_self,
        tentacle,
        go_to_first_player,
        go_to_last_player,
        finish
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
