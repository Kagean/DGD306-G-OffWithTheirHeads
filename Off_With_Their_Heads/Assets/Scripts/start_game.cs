using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_game : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            manager_prefab_fade();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            manager_prefab_fade();
            GameObject object_manager_game = GameObject.Find("manager_game");
            manager_game script_manager_game = object_manager_game.GetComponent<manager_game>();
            script_manager_game.is_coop = true;
        }
    }
    void manager_prefab_fade()
    {
        GameObject object_prefab_fade = GameObject.Find("prefab_fade");
        prefab_fade script_prefab_fade = object_prefab_fade.GetComponent<prefab_fade>();
        script_prefab_fade.fade_out = true;
    }
}