using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_game : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager_prefab_fade();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
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