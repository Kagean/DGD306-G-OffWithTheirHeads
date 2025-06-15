using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class manager_level : MonoBehaviour
{
    public bool lock_timer = false;
    public float timer_level;
    public float timer_level_limit;
    void Start()
    {
        
    }
    void Update()
    {
        var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
        if (timer_level >= timer_level_limit)
        {
            manager_game_script.count_credit -= 1;
            if (manager_game_script.count_credit == 0)
            {
                lock_timer = true;
                manager_game_script.count_score_total += manager_game_script.count_score;
                var script_prefab_fade = GameObject.Find("prefab_fade (1)").GetComponent<prefab_fade>();
                script_prefab_fade.fade_out = true;
            }
            else
            {
                timer_level = 0;
                timer_level_limit = 30f;
            }
        }
        if (!lock_timer)
        {
            timer_level += Time.deltaTime;
        }
    }
}