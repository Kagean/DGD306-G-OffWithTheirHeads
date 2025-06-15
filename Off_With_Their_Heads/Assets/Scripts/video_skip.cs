using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class video_skip : MonoBehaviour
{
    private float timer_skip = 0;
    public bool reset_game;
    public float timer_skip_limit;
    void Update()
    {
        if (timer_skip >= timer_skip_limit)
        {
            if (reset_game)
            {
                reset_game = false;
                var manager_game_script = GameObject.Find("manager_game").GetComponent<manager_game>();
                manager_game_script.is_coop = false;
                manager_game_script.count_credit = 3;
                manager_game_script.count_score = 0;
                manager_game_script.count_score_total = 0;
                manager_game_script.data_p1 = new List<string>();
                manager_game_script.data_p2 = new List<string>();
            }
            var script_prefab_fade = GameObject.Find("prefab_fade").GetComponent<prefab_fade>();
            script_prefab_fade.fade_out = true;
        }
        timer_skip += Time.deltaTime;
    }
}