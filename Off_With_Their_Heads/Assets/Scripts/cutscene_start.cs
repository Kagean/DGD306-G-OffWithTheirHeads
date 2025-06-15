using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cutscene_start : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            manager_prefab_fade();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            manager_prefab_fade();
            var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
            script_manager_game.is_coop = true;
        }
    }
    void manager_prefab_fade()
    {
        var script_prefab_fade = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
        script_prefab_fade.fade_out = true;
    }
}