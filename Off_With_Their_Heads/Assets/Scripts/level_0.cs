using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class level_0 : MonoBehaviour
{
    private bool is_coop;
    private bool lock_p1 = false;
    private bool lock_p2 = false;
    void Start()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        is_coop = manager_game_script.is_coop;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (is_coop)
            {
                lock_p1 = true;
            }
            else
            {
                var script_prefab_fade = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
                script_prefab_fade.fade_out = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick2Button7))
        {
            if (is_coop)
            {
                lock_p2 = true;
            }
        }
        if (lock_p2 && lock_p1)
        {
            var script_prefab_fade = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
            script_prefab_fade.fade_out = true;
        }
    }
}