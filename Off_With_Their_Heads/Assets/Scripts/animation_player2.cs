using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class animation_player2 : MonoBehaviour
{
    public int change_animation;
    public int index;
    public List<string> data_p2 = new List<string>();
    public string state_animation;
    void Start()
    {
        var script_manager_game = GameObject.Find("manager_game").GetComponent<manager_game>();
        data_p2 = script_manager_game.data_p2;
        var script_prefab_player2 = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
        change_animation = script_prefab_player2.change_animation;
        state_animation = script_prefab_player2.state_animation;
    }
    void Update()
    {
        if (change_animation != 3)
        {
            var script_prefab_player2 = GameObject.Find("prefab_player2(Clone)").GetComponent<prefab_player2>();
            script_prefab_player2.change_animation += 1;
            change_animation += 1;
            Animator animator = GetComponent<Animator>();
            animator.CrossFade(data_p2[index] + state_animation, 0f);
        }
    }
}